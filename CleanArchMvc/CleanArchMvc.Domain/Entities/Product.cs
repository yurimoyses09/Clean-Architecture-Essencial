using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        // the category is related to a product
        public int IdCategory { get; set; } // is understood as a foreign key
        public Category Category { get; set; }

        # region Builders
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid value id");
            Id = id;
            ValidationDomain(name, description, price, stock, image);
        }
        # endregion

        #region Methods
        private void ValidationDomain(string name, string description, decimal price, int stock, string image)
        {
            // Validating  Name
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is a value required");
            DomainExceptionValidation.When(name.Length < 3, "The lenght is small, minimum is 3 characters");

            // Validating Description
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Name is a value required");
            DomainExceptionValidation.When(description.Length < 3, "The lenght is small, minimum is 3 characters");

            // Validating Price
            DomainExceptionValidation.When(price < 0, "Invalide price value");

            // Validating Stock
            DomainExceptionValidation.When(stock < 0, "Invalide stock value");

            // Validating Image
            DomainExceptionValidation.When(image?.Length > 250, "Invalide image value, too long, maximum 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        private void Update(string name, string description, decimal price, int stock, string image, int categoryId) 
        {
            ValidationDomain(name, description, price, stock, image);
            IdCategory = categoryId;
        }
        #endregion
    }
}
