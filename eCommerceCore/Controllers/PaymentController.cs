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
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext context;
        

        public PaymentController(AppDbContext context)
        {
            this.context = context;
        }

        //// GET: api/Payment
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Payment/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Payment
        [HttpPost]
        public async Task<PaymentResponse> Post([FromBody] Payment payment)
        {
            var paymentResponse = new PaymentResponse { Success = false };

            try
            {
                await context.Payment.AddAsync(payment);
                await context.SaveChangesAsync();
                paymentResponse.Success = true;
                paymentResponse.Message = "Payment Done Succesfully";
            }
            catch (Exception e)
            {
                paymentResponse.Message = e.StackTrace;
                paymentResponse.Success = false;
            }
            return paymentResponse;
        }

        //// PUT: api/Payment/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

    public class PaymentResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
