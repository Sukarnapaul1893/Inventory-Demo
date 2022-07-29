using InventoryDemo.Models.DataModels;

namespace InventoryDemo.Models.ViewModels
{
    public class SaleView
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int SalesmanId { get; set; }
        public List<CustomerView> Customers { get; set; }
        public List<SaleProductView> Products { get; set; }
    }
}
