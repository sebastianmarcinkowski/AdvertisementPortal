using AdvertisementPortal.Core.Models.Domains;

namespace AdvertisementPortal.Core.Repositories
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> GetCategories();
	}
}
