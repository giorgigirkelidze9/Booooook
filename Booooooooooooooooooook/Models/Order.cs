using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Booooooooooooooooooook.Models
{
	public class Order
	{
		[ScaffoldColumn(false)]
		public int OrderId { get; set; }
		[ScaffoldColumn(false)]
		public int CartId { get; set; }
		[ScaffoldColumn(false)]
		public string User { get; set; }
		[Required(ErrorMessage = "First Name is required")]
		[StringLength(100)]
		[DisplayName("First Name")]
		public string First { get; set; }
		[Required(ErrorMessage = "Last Name is required")]
		[StringLength(100)]
		[DisplayName("Last Name")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Country is required")]
		[StringLength(50)]
		public string Country { get; set; }
		[Required(ErrorMessage = "Phone Number is required")]
		[StringLength(50)]
		public string Phone { get; set; }
		[Required(ErrorMessage = "Email Address is required")]
		[DisplayName("Email Address")]
		[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
		ErrorMessage = "Email is is not valid.")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		
		
	}
}