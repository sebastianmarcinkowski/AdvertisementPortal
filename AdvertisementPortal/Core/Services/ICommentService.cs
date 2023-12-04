using AdvertisementPortal.Core.Models.Domains;

namespace AdvertisementPortal.Core.Services
{
	public interface ICommentService
	{
		IEnumerable<Comment> GetComments(int advertisementId);
		void Add(Comment comment);
		void Delete(int id, int advertisementId, string userId);
	}
}
