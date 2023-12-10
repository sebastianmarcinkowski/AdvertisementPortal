using AdvertisementPortal.Core;
using AdvertisementPortal.Core.Models.Domains;
using AdvertisementPortal.Core.Services;

namespace AdvertisementPortal.Persistence.Services
{
	public class AdvertisementService : IAdvertisementService
	{
		private readonly IUnitOfWork _unitOfWork;

		public AdvertisementService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public Advertisement GetAdvertisement(int advertisementId)
			=> _unitOfWork.Advertisement.GetAdvertisement(advertisementId);

		public IEnumerable<Advertisement> GetAdvertisements(
				string title = null,
				int categoryId = 0)
			=> _unitOfWork.Advertisement.GetAdvertisements(title, categoryId);

		public void Add(Advertisement advertisement)
		{
			_unitOfWork.Advertisement.Add(advertisement);
			_unitOfWork.Complete();
		}

		public void Update(Advertisement advertisement, string userId)
		{
			_unitOfWork.Advertisement.Update(advertisement, userId);
			_unitOfWork.Complete();
		}

		public void Delete(int id, string userId)
		{
			_unitOfWork.Advertisement.Delete(id, userId);
			_unitOfWork.Complete();
		}
	}
}
