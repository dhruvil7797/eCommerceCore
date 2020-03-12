using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace eCommerceCore.Models
{
    public class Product
    {
        public Product(string name, string description, double price, string brand, string image, double shippingCost)
        {
            Name = name;
            Description = description;
            Price = price;
            Brand = brand;
            Image = image;
            ShippingCost = shippingCost;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Image { get; set; }

        public double ShippingCost { get; set; }

    }
}
