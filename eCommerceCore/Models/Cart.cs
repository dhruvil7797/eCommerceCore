using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCommerceCore.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public string SessionId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("ProductVariation")]
        public int ProductId { get; set; }
        public ProductVariation ProductVariation { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsRegistered { get; set; }
    }
}
