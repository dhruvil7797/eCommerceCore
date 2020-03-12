using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerceCore.Models

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
            productsResponse.Success = false;

            var products = context.Product;
            foreach(Product eachProduct in products)
            {
                productsResponse.ListOfProducts.Add(eachProduct);
            }

            return productsResponse;
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // GET : api/Product/add
        public void AddProduct()
        {
            
        }

        

        
    }

    public class ProductsResponse
    {
        public bool Success { get; set; }
        public List<Product> ListOfProducts { get; set; }
    }
}
