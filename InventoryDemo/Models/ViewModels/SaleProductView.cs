using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryDemo.Models.ViewModels
{
    public class SaleProductView
    {
        public SaleProductView()
        {
            Image = "";
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Instock { get; set; }
        public double InstockWeight { get; set; }
        public string Image { get; set; }
        public bool IsPurchased { get; set; }

    }
}
