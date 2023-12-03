using AdvertisementPortal.Core;
using AdvertisementPortal.Core.Models.Domains;
using AdvertisementPortal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdvertisementPortal.Persistence.Repositories
{
	public class AdvertisementRepository : IAdvertisementRepository
	{
		private readonly IApplicationDbContext _context;

		public AdvertisementRepository(IApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Advertisement> GetAdvertisements()
			=> _context.Advertisements
				.Include(a => a.Category)
				.ToList();

		public Advertisement GetAdvertisement(int advertisementId)
			=> _context.Advertisements
				.Include(a => a.Category)
				.Include(a => a.Comments)
				.Include(a => a.User)
				.First(a => a.Id == advertisementId);
	}
}
