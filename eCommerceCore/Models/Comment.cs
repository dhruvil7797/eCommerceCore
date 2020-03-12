using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCommerceCore.Models
{
    public class Comment
    {
        public Comment(int userId, int productId, string productComment, int ratings)
        {
            UserId = userId;
            ProductId = productId;
            ProductComment = productComment;
            Ratings = ratings;
        }

        public int Id { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users User { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public string ProductComment { get; set; }

        [Required]
        public int Ratings { get; set; }
    }
}
