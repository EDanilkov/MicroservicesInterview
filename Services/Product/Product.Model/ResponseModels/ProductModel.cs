using System;

namespace Product.Model.ResponseModels
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
