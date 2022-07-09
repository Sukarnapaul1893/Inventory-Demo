using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryDemo.Models.ViewModels
{
    public class SalesmanView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalSellCustomer { get; set; }
        public double TotalSellPrice { get; set; }
        public double Salary { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile FileUpload { get; set; }
    }
}
