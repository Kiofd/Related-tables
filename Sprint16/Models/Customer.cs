namespace Sprint16.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Fname {  get; set; }
        public string Lname { get; set; }   
        public string Address {  get; set; }
        public double Discount {  get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
