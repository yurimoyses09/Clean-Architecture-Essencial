using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task Add(ProductDTO product)
        {
            await _productRepository.CreateProductAsync(_mapper.Map<Product>(product));
        }

        public async Task<ProductDTO> GetById(int id)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetProductPerIdAsync(id));
        }

        public async Task<ProductDTO> GetProductCategory(int id)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetProductCategory(id));
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetProductsAsync());
        }

        public async Task Remove(ProductDTO product)
        {
            await _productRepository.RemoveProductAsync(_mapper.Map<Product>(product));
        }

        public async Task Update(ProductDTO product)
        {
            await _productRepository.UpdateProductAsync(_mapper.Map<Product>(product));
        }
    }
}
