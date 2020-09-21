using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookstore.Models
{
    public class Order
    {
		[Key]
		public int Id { get; set; }

		//[Required(ErrorMessage = "Please select a book")]
		public int BookId { get; set; }


		[Required(ErrorMessage = "Client name is required.")]
		[DataType(DataType.Text), MaxLength(120)]
		public string ClientName { get; set; }

		[Required(ErrorMessage = "Street is required.")]
		[DataType(DataType.Text), MaxLength(256)]
		public string Street { get; set; }

		[Required(ErrorMessage = "City is required.")]
		[DataType(DataType.Text)]
		public string City { get; set; }

		public string State { get; set; }

		[Required(ErrorMessage = "Country is required.")]
		[DataType(DataType.Text)]
		public string Country { get; set; }

		[DataType(DataType.PostalCode)]
		[Required(ErrorMessage = "Client name is required.")]
		public string Zip { get; set; }

		[Required(ErrorMessage = "Phone number is required")]
		[DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
		public string Email { get; set; }

	}
}
