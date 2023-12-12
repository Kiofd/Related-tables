using System.ComponentModel.DataAnnotations;

namespace Sprint16.Models
{
    public class Supermarket
    {
        public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
		[MaxLength(100)]
		public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
