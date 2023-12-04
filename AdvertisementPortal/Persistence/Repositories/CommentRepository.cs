using AdvertisementPortal.Core;
using AdvertisementPortal.Core.Models.Domains;
using AdvertisementPortal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdvertisementPortal.Persistence.Repositories
{
	public class CommentRepository : ICommentRepository
	{
		private readonly IApplicationDbContext _context;

		public CommentRepository(IApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Comment> GetComments(int advertisementId)
			=> _context.Comments
				.Include(c => c.User)
				.Where(c => c.AdvertisementId == advertisementId)
				.ToList();

		public void Add(Comment comment)
		{
			_context.Comments.Add(comment);
		}

		public void Delete(int id, int advertisementId, string userId)
		{
			var commentToDelete = _context.Comments
				.First(
				c => c.Id == id
				&&
				c.AdvertisementId == advertisementId
				&&
				c.UserId == userId);

			_context.Comments.Remove(commentToDelete);
		}
	}
}
