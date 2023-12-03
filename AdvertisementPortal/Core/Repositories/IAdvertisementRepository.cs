using AdvertisementPortal.Core.Models.Domains;

namespace AdvertisementPortal.Core.Repositories
{
	public interface IAdvertisementRepository
	{
		IEnumerable<Advertisement> GetAdvertisements();
		Advertisement GetAdvertisement(int advertisementId);
	}
}
