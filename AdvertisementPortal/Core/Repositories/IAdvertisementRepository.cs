using AdvertisementPortal.Core.Models.Domains;

namespace AdvertisementPortal.Core.Repositories
{
	public interface IAdvertisementRepository
	{
		Advertisement GetAdvertisement(int advertisementId);
		IEnumerable<Advertisement> GetAdvertisements();
		void Delete(int id, string userId);
	}
}
