namespace Sprint16.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public float Price {  get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
