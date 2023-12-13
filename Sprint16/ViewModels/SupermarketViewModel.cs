using System.ComponentModel.DataAnnotations;

namespace Sprint16.ViewModels
{
	public class SupermarketViewModel
	{
		[MaxLength(50)]
		public string Name { get; set; }
		[MaxLength(100)]
		public string Address { get; set; }
	}
}
