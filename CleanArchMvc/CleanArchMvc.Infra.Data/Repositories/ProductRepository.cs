using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly ApplicaionDbContext _productContext;
        public ProductRepository(ApplicaionDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _productContext.Products.Add(product);
            await _productContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetProductCategory(int? id) 
        {
            return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(c => c.Category.Id == id);
        }

        public async Task<Product> GetProductPerIdAsync(int? id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveProductAsync(Product product)
        {
            _productContext.Products.Remove(product);
            await _productContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _productContext.Products.Update(product);
            await _productContext.SaveChangesAsync();

            return product;
        }
    }
}
