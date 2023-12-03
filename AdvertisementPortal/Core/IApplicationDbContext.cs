using AdvertisementPortal.Core.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace AdvertisementPortal.Core
{
	public interface IApplicationDbContext
	{
		DbSet<Advertisement> Advertisements { get; set; }
		DbSet<Category> Categories { get; set; }
		DbSet<Comment> Comments { get; set; }
		int SaveChanges();
	}
}
