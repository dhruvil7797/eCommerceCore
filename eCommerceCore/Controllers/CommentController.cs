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
    public class CommentController : ControllerBase
    {

        private readonly AppDbContext context;

        public CommentController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/Comment/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Comment
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        public class AddCommentResponse
        {
            public bool Success { get; set; }
            public int commentId { get; set; }
        }

        public class FetchCommentResponse
        {
            public bool Success { get; set; }
            public List<Comment> ListOfProducts { get; set; }
        }
    }
}
