using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
	public class Customer
	{
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad Alanı boş geçilemez")]
        public string FirstName { get; set; }
        [MinLength(2, ErrorMessage ="Soyad alanı en az 2 karakter olmalı")]
        public string LastName { get; set; }
        public int Age { get; set; }

        public Customer()
        {
            
        }
        public Customer(string firstName, string lastName, int age)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
		}
	}
}
