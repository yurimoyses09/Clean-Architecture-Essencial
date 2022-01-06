using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValueParameters_ResultObjectValidState() 
        {
            Action action = () => new Product("Name product", "Product", 12, 12, "Product Image");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

    }
}
