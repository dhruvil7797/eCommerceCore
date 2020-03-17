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
    public class CartController : ControllerBase
    {

        private readonly AppDbContext context;

        public CartController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/Cart
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cart/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cart
        [HttpPost]
        public async Task<CartResponse> Post([FromBody] Cart cart)
        {
            
            var cartresp = new CartResponse { Success = false };
            await context.Cart.AddAsync(cart);
            await context.SaveChangesAsync();
            cartresp.Success = true;
            cartresp.Message = "Cart Added Succesfully";


            return cartresp;
        }

        [HttpPost("updatecart")]
        public CartResponse UpdateCart([FromBody] Cart cart)
        {
            var cartResp = new CartResponse() { Success = false };

            if (context.Cart.Any(id => id.Id == cart.Id))
            {
                context.Cart.Remove(cart);
                context.SaveChanges();
                cartResp.Success = true;
                cartResp.Message = "cart deleted";
            }

            return cartResp;
        }


        
    }


    public class CartResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
