using System.ComponentModel.DataAnnotations;

namespace Sprint16.Models
{
	public enum Discount
	{
		O = 0, V = 3, R = 5
	}
	public class Customer
	{
		public int Id { get; set; }
		[MaxLength(50)]
		[Display(Name = "First name")]
		public string Fname { get; set; }
		[MaxLength(50)]
		[Display(Name = "Last name")]
		public string Lname { get; set; }
		[MaxLength(50)]
		public string Address { get; set; }
		public Discount Discount { get; set; }

		
		public ICollection<Order>? Orders { get; set; }
	}
}
