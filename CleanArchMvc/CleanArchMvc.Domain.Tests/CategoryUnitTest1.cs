using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests.CategoryTests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValueParameters_ResultObjectValidState() 
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id Value.");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(-1, "Ca");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("The lenght is small, minimum is 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(-1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Name is a value required");
        }

        [Fact]
        public void CreateCategory_WithNullValueName_DomainExceptionInvalidName()
        {
            Action action = () => new Category(-1, null);
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
