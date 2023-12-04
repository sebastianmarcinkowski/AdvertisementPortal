using AdvertisementPortal.Core.Models.Domains;

namespace AdvertisementPortal.Core.Services
{
	public interface IAdvertisementService
	{
		Advertisement GetAdvertisement(int advertisementId);
		IEnumerable<Advertisement> GetAdvertisements();
		void Delete(int id, string userId);
	}
}
