using AutoMapper;
using ECommerce.Api.Data;
using ECommerce.Api.DTOs;
using ECommerce.Api.Models;
using ECommerce.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//https://localhost:44363/swagger/index.html

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }



        [HttpGet("{id}")]
        public  async Task<IActionResult> GetProductById(int id)
        {

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPost]
        public  async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var product =   await _productService.CreateProductAsync(dto);
            return CreatedAtAction(
                    nameof(GetProductById),
                    new { id = product.Id },
                    product);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, CreateProductDto dto)
        {
            var product = await _productService.UpdateProductAsync(id, dto);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            var deleted = await _productService.DeleteProductAsync(id);
            if(!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
