using AdvertisementPortal.Core;
using AdvertisementPortal.Core.Services;

namespace AdvertisementPortal.Persistence.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CategoryService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
