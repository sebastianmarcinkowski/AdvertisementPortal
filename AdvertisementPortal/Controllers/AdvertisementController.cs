using AdvertisementPortal.Core.Converters;
using AdvertisementPortal.Core.Services;
using AdvertisementPortal.Core.ViewModels;
using AdvertisementPortal.Persistence.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementPortal.Controllers
{
	public class AdvertisementController : Controller
	{
		private readonly IAdvertisementService _advertisementService;

		public AdvertisementController(IAdvertisementService advertisementService)
		{
			_advertisementService = advertisementService;
		}

		public IActionResult Index(int id)
		{
			var advertisementId = id;
			AdvertisementViewModel advertisement = new AdvertisementViewModel();

			try
			{
				advertisement = _advertisementService
					.GetAdvertisement(advertisementId)
					.ToViewModel(User.GetUserId());
			}
			catch (Exception)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(advertisement);
		}
	}
}
