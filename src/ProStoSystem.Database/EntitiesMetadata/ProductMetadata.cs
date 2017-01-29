namespace ProStoSystem.Database.EntitiesMetadata
{
    using System.ComponentModel.DataAnnotations;

    public class ProductMetadata
    {
        [Required(ErrorMessage = "You must specify correct name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must specify correct selling price.")]
        [Range(0, int.MaxValue, ErrorMessage = "Selling price must be greater than 0.")]
        public decimal SellingPrice { get; set; }

        [Required(ErrorMessage = "You must specify correct purchase price.")]
        [Range(0, int.MaxValue, ErrorMessage = "Purchase price must be greater than 0.")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "You must specify correct amount of products.")]
        [Range(0, int.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public int Amount { get; set; }
    }
}
