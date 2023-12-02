using AdvertisementPortal.Core;

namespace AdvertisementPortal.Persistence
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IApplicationDbContext _context;

		public UnitOfWork(IApplicationDbContext context)
		{
			_context = context;
		}
	}
}
