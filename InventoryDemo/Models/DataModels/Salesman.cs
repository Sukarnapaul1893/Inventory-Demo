using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryDemo.Models.DataModels
{
    public class Salesman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string Email { set; get; }
        public string PhoneNumber { get; set; }
        public int TotalSellCustomer { get; set; }
        public double TotalSellPrice { get; set; }
        public double Salary { get; set; }
        public string Image { get; set; }

    }
}
