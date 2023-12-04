using AdvertisementPortal.Core.Models.Domains;

namespace AdvertisementPortal.Core.Repositories
{
	public interface ICommentRepository
	{
		IEnumerable<Comment> GetComments(int advertisementId);
		void Add(Comment comment);
		void Delete(int id, int advertisementId, string userId);
	}
}
