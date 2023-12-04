using AdvertisementPortal.Core.Models.Domains;

namespace AdvertisementPortal.Core.Services
{
	public interface IAdvertisementService
	{
		IEnumerable<Advertisement> GetAdvertisements();
		Advertisement GetAdvertisement(int advertisementId);
		void Delete(int id, string userId);
	}
}
