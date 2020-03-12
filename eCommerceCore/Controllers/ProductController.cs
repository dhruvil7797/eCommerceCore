using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerceCore.Models;

namespace eCommerceCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly AppDbContext context;

        public ProductController(AppDbContext context)
        {
            this.context = context;
        }



        // GET: api/Product
        [HttpGet]
        public ProductsResponse Get()
        {
            var productsResponse = new ProductsResponse();
            productsResponse.ListOfProducts = new List<Product>();
            productsResponse.Success = false;
            foreach(Product eachProduct in context.Product.ToList())
            {
                productsResponse.ListOfProducts.Add(eachProduct);
            }
            productsResponse.Success = true;
            return productsResponse;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ProductsResponse Get(int id)
        {
            var productsResponse = new ProductsResponse();
            productsResponse.ListOfProducts = new List<Product>();
            productsResponse.Success = false;
            var product = context.Product.FirstOrDefault(u => u.Id == id);
            if (product != null)
            {
                productsResponse.ListOfProducts.Add(product);
            }
            productsResponse.Success = true;
            return productsResponse;
        }

        // GET : api/Product/add
        [HttpGet("insert/All")]
        public string AddProduct()
        {
            Product product1 = new Product("Product 1", "Description 1", 3.4, "Brand 1", "Url1", 1.2);
            Product product2 = new Product("Product 2", "Description 2", 5.4, "Brand 1", "Url1", 0.7);
            Product product3 = new Product("Product 3", "Description 3", 2.7, "Brand 1", "Url1", 2.2);
            Product product4 = new Product("Product 4", "Description 4", 1.9, "Brand 1", "Url1", 1.2);
            Product product5 = new Product("Product 5", "Description 5", 21.4, "Brand 1", "Url1", 4.2);
            context.Add(product1);
            context.Add(product2);
            context.Add(product3);
            context.Add(product4);
            context.Add(product5);
            context.SaveChanges();
            return "Product Added Successfully";
        }

        

        
    }

    public class ProductsResponse
    {
        public bool Success { get; set; }
        public List<Product> ListOfProducts { get; set; }
    }
}
