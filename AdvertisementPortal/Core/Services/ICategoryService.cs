using AdvertisementPortal.Core.Models.Domains;

namespace AdvertisementPortal.Core.Services
{
	public interface ICategoryService
	{
		IEnumerable<Category> GetCategories();
	}
}
