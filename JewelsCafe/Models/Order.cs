namespace JewelsCafe.Models
{
    public class Order
    {
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}