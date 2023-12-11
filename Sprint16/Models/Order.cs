using System.ComponentModel.DataAnnotations;

namespace Sprint16.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public int Supermarket_Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime Order_Date { get; set;}

        public Customer Customers { get; set; }
        public Supermarket Supermarkets { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
