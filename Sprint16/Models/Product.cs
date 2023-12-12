using System.ComponentModel.DataAnnotations;

namespace Sprint16.Models
{
    public class Product
    {
        public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
        public float Price {  get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
