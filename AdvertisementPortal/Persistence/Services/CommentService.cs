using AdvertisementPortal.Core;
using AdvertisementPortal.Core.Models.Domains;
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

		public IEnumerable<Comment> GetComments(int advertisementId)
			=> _unitOfWork.Comment.GetComments(advertisementId);

		public void Add(Comment comment)
		{
			_unitOfWork.Comment.Add(comment);
			_unitOfWork.Complete();
		}

		public void Delete(int id, int advertisementId, string userId)
		{
			_unitOfWork.Comment.Delete(id, advertisementId, userId);
			_unitOfWork.Complete();
		}
	}
}
