using AdvertisementPortal.Core;
using AdvertisementPortal.Core.Repositories;
using AdvertisementPortal.Persistence.Repositories;

namespace AdvertisementPortal.Persistence
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IApplicationDbContext _context;

		public UnitOfWork(IApplicationDbContext context)
		{
			_context = context;

			Advertisement = new AdvertisementRepository(context);
			Category = new CategoryRepository(context);
			Comment = new CommentRepository(context);
		}

		public IAdvertisementRepository Advertisement { get; }
		public ICategoryRepository Category { get; }
		public ICommentRepository Comment { get; }

		public void Complete()
		{
			_context.SaveChanges();
		}
	}
}
