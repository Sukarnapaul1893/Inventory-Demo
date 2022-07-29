namespace InventoryDemo.Models.DataModels
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int SalesmanId { get; set; }
        
    }
}
