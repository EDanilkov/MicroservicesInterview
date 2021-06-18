using System;
using System.ComponentModel.DataAnnotations;

namespace Product.Data.Models
{
    public class Product
    {
        [Key]
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
