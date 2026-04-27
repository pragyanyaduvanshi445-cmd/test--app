using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using test__app.Models;

namespace test__app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductApiController : ControllerBase
    {
        private readonly string _jsonFilePath = "./repo/Data/StaticProductStore.json";

        private List<Product> ReadProducts()
        {
            if (!System.IO.File.Exists(_jsonFilePath))
            {
                return new List<Product>();
            }
            var json = System.IO.File.ReadAllText(_jsonFilePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        private void WriteProducts(List<Product> products)
        {
            var json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_jsonFilePath, json);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = ReadProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var products = ReadProducts();
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            var products = ReadProducts();
            product.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
            products.Add(product);
            WriteProducts(products);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product updatedProduct)
        {
            var products = ReadProducts();
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;
            WriteProducts(products);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var products = ReadProducts();
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            WriteProducts(products);
            return NoContent();
        }
    }
}