using AdvertisementPortal.Core;
using AdvertisementPortal.Core.Models.Domains;
using AdvertisementPortal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdvertisementPortal.Persistence.Repositories
{
	public class AdvertisementRepository : IAdvertisementRepository
	{
		private readonly IApplicationDbContext _context;

		public AdvertisementRepository(IApplicationDbContext context)
		{
			_context = context;
		}

		public Advertisement GetAdvertisement(int advertisementId)
			=> _context.Advertisements
				.Include(a => a.Category)
				.Include(a => a.Comments)
				.Include(a => a.User)
				.First(a => a.Id == advertisementId);

		public IEnumerable<Advertisement> GetAdvertisements(
			string title = null,
			int categoryId = 0)
		{

			 IQueryable<Advertisement> advertisements = _context.Advertisements
						.Include(a => a.Category);

			if (!string.IsNullOrWhiteSpace(title))
				advertisements = advertisements.Where(a => a.Title.Contains(title));

			if (categoryId != 0)
				advertisements = advertisements.Where(a => a.CategoryId == categoryId);

			return advertisements.ToList();
		}

		public void Add(Advertisement advertisement)
			=> _context.Advertisements.Add(advertisement);

		public void Update(Advertisement advertisement, string userId)
		{
			var advertisementToUpdate = _context.Advertisements
				.First(
					a => a.Id == advertisement.Id
					&&
					a.UserId == userId);

			advertisementToUpdate.Title = advertisement.Title;
			advertisementToUpdate.Content = advertisement.Content;
			advertisementToUpdate.CategoryId = advertisement.CategoryId;
			advertisementToUpdate.LastUpdatedTime = advertisement.LastUpdatedTime;

			_context.Advertisements.Update(advertisementToUpdate);
		}

		public void Delete(int id, string userId)
		{
			var advertisementToDelete = _context.Advertisements
				.Include(a => a.Comments)
				.First(
				a => a.Id == id
				&&
				a.UserId == userId);

			_context.Advertisements.Remove(advertisementToDelete);
		}
	}
}
