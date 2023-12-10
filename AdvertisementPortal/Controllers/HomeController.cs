using AdvertisementPortal.Core.Services;
using AdvertisementPortal.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdvertisementPortal.Controllers
{
	public class HomeController : Controller
	{
		private readonly IAdvertisementService _advertisementService;
		private readonly ICommentService _commentService;
		private readonly ICategoryService _categoryService;

		public HomeController(
			IAdvertisementService advertisementService,
			ICommentService commentService,
			ICategoryService categoryService)
		{
			_advertisementService = advertisementService;
			_commentService = commentService;
			_categoryService = categoryService;
		}

		public IActionResult Index()
		{
			var homeViewModel = new HomeViewModel
			{
				Advertisements = _advertisementService.GetAdvertisements(),
				Categories = _categoryService.GetCategories()
			};

			return View(homeViewModel);
		}

		[HttpPost]
		public IActionResult Index(HomeViewModel viewModel)
		{
			var homeViewModel = new HomeViewModel
			{
				Advertisements = _advertisementService.GetAdvertisements(
					viewModel.Filter.Title,
					viewModel.Filter.CategoryId),
				Categories = _categoryService.GetCategories()
			};

			return View(homeViewModel);
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
