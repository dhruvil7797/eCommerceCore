using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceCore.Models
{
    public class OrderRecord
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("ProductVariation")]
        public int ProductVariationID { get; set; }
        public ProductVariation ProductVariation { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int PaymentToken { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string OrderStatus { get; set; }

    }
}
