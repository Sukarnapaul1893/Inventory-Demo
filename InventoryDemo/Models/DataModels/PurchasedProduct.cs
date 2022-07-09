namespace InventoryDemo.Models.DataModels
{
    public class PurchasedProduct
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
    }
}
