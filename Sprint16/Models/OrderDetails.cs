namespace Sprint16.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Product_Id { get; set; } 
        public float Quantity { get; set; }


        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
