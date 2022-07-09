using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryDemo.Models.DataModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Instock { get; set; }
        public double InstockWeight { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile FileUpload { get; set; }
    }
}
