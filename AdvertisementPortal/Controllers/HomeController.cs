using AdvertisementPortal.Core.Services;
using AdvertisementPortal.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdvertisementPortal.Controllers
{
	public class HomeController : Controller
	{
		private readonly IAdvertisementService _advertisementService;

		public HomeController(IAdvertisementService advertisementService)
		{
			_advertisementService = advertisementService;
		}

		public IActionResult Index()
		{
			var articles = _advertisementService.GetAdvertisements();

			return View(articles);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
