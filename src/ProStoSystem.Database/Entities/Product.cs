namespace ProStoSystem.Database.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using EntitiesMetadata;

    [MetadataType(typeof(ProductMetadata))]
    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }


        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
