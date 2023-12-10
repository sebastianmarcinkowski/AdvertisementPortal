using AdvertisementPortal.Core.Models.Domains;

namespace AdvertisementPortal.Core.Repositories
{
	public interface IAdvertisementRepository
	{
		Advertisement GetAdvertisement(int advertisementId);
		IEnumerable<Advertisement> GetAdvertisements();
		void Add(Advertisement advertisement);
		void Update(Advertisement advertisement, string userId);
		void Delete(int id, string userId);
	}
}
