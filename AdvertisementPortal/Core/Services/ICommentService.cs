using AdvertisementPortal.Core.Models.Domains;

namespace AdvertisementPortal.Core.Services
{
	public interface ICommentService
	{
		void Add(Comment comment);
		void Delete(int id, int advertisementId, string userId);
		IEnumerable<Comment> GetComments(int advertisementId);
	}
}
