using AdvertisementPortal.Core;
using AdvertisementPortal.Core.Repositories;

namespace AdvertisementPortal.Persistence.Repositories
{
	public class CommentRepository : ICommentRepository
	{
		private readonly IApplicationDbContext _context;

		public CommentRepository(IApplicationDbContext context)
		{
			_context = context;
		}
	}
}
