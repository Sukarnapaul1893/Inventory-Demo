using System.ComponentModel.DataAnnotations;

namespace InventoryDemo.Models.ViewModels
{
    public class RegisterView
    {
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string Email { set; get; }

        [Required]
        public string PhoneNumber { set; get; }
        public string Password { set; get; }
    }
}
