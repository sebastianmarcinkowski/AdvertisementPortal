using AdvertisementPortal.Core.Models.Domains;

namespace AdvertisementPortal.Core.Repositories
{
	public interface ICommentRepository
	{
		void Add(Comment comment);
		void Delete(int id, int advertisementId, string userId);
		IEnumerable<Comment> GetComments(int advertisementId);
	}
}
