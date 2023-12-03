using AdvertisementPortal.Core;
using AdvertisementPortal.Core.Services;

namespace AdvertisementPortal.Persistence.Services
{
	public class CommentService : ICommentService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CommentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
