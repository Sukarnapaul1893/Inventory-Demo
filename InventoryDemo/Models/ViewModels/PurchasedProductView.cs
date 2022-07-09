namespace InventoryDemo.Models.ViewModels
{
    public class PurchasedProductView
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
    }
}
