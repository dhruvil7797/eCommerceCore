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
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext context;

        public OrderController(AppDbContext context)
        {
            this.context = context;
        }
        


        //// GET: api/Order
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Order/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Order
        [HttpPost]
        public async Task<OrderResponse> Post([FromBody] OrderRecord orderRecord)
        {
            var orderResponse = new OrderResponse() { Success = false };

            try
            {

                await context.OrderRecord.AddAsync(orderRecord);
                await context.SaveChangesAsync();
                orderResponse.Success = true;
                orderResponse.Message = "Order Added Successfully";

            }
            catch (Exception e)
            {
                orderResponse.Message = e.StackTrace;
                orderResponse.Success = false;
            }
            return orderResponse;
        }

        


    }

    public class OrderResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
