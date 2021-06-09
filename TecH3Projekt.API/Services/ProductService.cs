﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;
using TecH3Projekt.API.Repositories;

namespace TecH3Projekt.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }




        // GET ALL PRODUCT
        public async Task<List<Product>> GetAllProducts()
        {
            var product = await _productRepository.GetAll();
            return product;
        }


        // GET PRODUCT BY ID
        public async Task<Product> GetProductById(int id)
        {
            var product = await _productRepository.GetById(id);
            return product;
        }


        // CREATE PRODUCT
        public async Task<Product> Create(Product product)
        {
            product = await _productRepository.Create(product);
            return product;
        }


        // UPDATE PRODUCT
        public async Task<Product> Update(int id, Product product)
        {
            await _productRepository.Update(id, product);
            return product;
        }


        // DELETE PRODUCT
        public async Task<Product> Delete(int id)
        {
            var product = await _productRepository.Delete(id);
            return product;
        }
    }
}