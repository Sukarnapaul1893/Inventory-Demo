using System.ComponentModel.DataAnnotations;

namespace InventoryDemo.Models.DataModels
{
    public class CompanyInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
    }
}
