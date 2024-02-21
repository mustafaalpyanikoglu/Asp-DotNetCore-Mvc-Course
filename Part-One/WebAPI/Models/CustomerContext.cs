using System.Collections.Generic;

namespace WebAPI.Models
{
	public static class CustomerContext
	{
		public static List<Customer> Customers = new List<Customer>()
		{
			new Customer() {Id = 1, FirstName = "Yavuz", LastName = "Kahraman", Age= 27},
			new Customer() {Id = 2, FirstName = "Oğuz", LastName = "Kahraman", Age= 20}
		};
	}
}
