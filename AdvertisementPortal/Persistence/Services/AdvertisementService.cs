using AdvertisementPortal.Core;
using AdvertisementPortal.Core.Models.Domains;
using AdvertisementPortal.Core.Services;
using System.Collections.ObjectModel;

namespace AdvertisementPortal.Persistence.Services
{
	public class AdvertisementService : IAdvertisementService
	{
		private readonly IUnitOfWork _unitOfWork;

		public AdvertisementService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IEnumerable<Advertisement> GetAdvertisements()
			=> _unitOfWork.Advertisement.GetAdvertisements();

		public Advertisement GetAdvertisement(int advertisementId)
			=> _unitOfWork.Advertisement.GetAdvertisement(advertisementId);


	}
}
