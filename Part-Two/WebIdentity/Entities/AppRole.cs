using Microsoft.AspNetCore.Identity;
using System;

namespace WebIdentity.Entities
{
	public class AppRole : IdentityRole<int>
	{
		public DateTime CreatedTime { get; set; }

	}
}
