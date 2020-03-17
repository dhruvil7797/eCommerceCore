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
        [HttpGet("{id}")]
        public FetchCommentResponse Get(int id)
        {
            var response = new FetchCommentResponse();
            response.Success = false;
            response.ListOfComments = new List<Comment>();
            response.AvgRating = 0;
            foreach(var comments in context.Comment.Where(u => u.ProductId == id).ToList())
            {
                response.ListOfComments.Add(comments);
                response.AvgRating = comments.Ratings;
            }
            response.AvgRating = (float)response.AvgRating/response.ListOfComments.Count;
            response.Success = true;
            return response;
        }

        // POST: api/Comment
        [HttpPost]
        public AddCommentResponse Post([FromBody] Comment commentArg)
        {
            var response = new AddCommentResponse();
            response.Success = false;
            if(context.OrderRecord.Where(o => o.ProductVariationID == commentArg.ProductId && o.UserId == commentArg.UserId).Count() != 0)
            {
                context.Comment.Add(commentArg);
                context.SaveChanges();
                response.Success = true;
                response.Message = "Comment Added Successfully";
            }
            else
            {
                response.Message = "User has not purchase this product. Cannot comment";
            }
            return response;
        }

        public class AddCommentResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }

        public class FetchCommentResponse
        {
            public bool Success { get; set; }
            public List<Comment> ListOfComments { get; set; }
            public float AvgRating { get; set; }

        }

    }
}
