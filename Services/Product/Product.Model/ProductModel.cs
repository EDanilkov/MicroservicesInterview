using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Model
{
    public class ProductModel
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
