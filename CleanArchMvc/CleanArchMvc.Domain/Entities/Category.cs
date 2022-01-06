using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; } // A Collection of the products

        #region builders
        public Category(string name)
        {
            ValidationDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidationDomain(name);
        }
        #endregion

        #region Methods
        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is a value required");

            DomainExceptionValidation.When(name.Length < 3, "The lenght is small, minimum is 3 characters");

            Name = name;
        }
        public void Update(string name)
        {
            ValidationDomain(name);
        }
        #endregion
    }
}
