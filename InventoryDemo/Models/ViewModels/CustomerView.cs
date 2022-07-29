namespace InventoryDemo.Models.ViewModels
{
    public class CustomerView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool PremiumMembership { get; set; }
        public bool IsPurchasing { get; set; }
    }
}
