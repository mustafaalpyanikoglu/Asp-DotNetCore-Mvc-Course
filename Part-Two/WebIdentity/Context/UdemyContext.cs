using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebIdentity.Entities;

namespace WebIdentity.Context
{
	public class UdemyContext : IdentityDbContext<AppUser, AppRole, int>
	{
        public UdemyContext(DbContextOptions<UdemyContext> options):base(options)
        {
            
        }
    }
}
