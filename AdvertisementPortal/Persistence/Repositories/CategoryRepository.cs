using AdvertisementPortal.Core;
using AdvertisementPortal.Core.Repositories;

namespace AdvertisementPortal.Persistence.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly IApplicationDbContext _context;

		public CategoryRepository(IApplicationDbContext context)
		{
			_context = context;
		}
	}
}
