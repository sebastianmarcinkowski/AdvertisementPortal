using AdvertisementPortal.Core;
using AdvertisementPortal.Core.Models.Domains;
using AdvertisementPortal.Core.Repositories;

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
		{
			return _context.Advertisements.ToList();
		}
	}
}
