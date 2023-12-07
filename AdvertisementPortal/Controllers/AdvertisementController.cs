using AdvertisementPortal.Core.Converters;
using AdvertisementPortal.Core.Models.Domains;
using AdvertisementPortal.Core.Services;
using AdvertisementPortal.Core.ViewModels;
using AdvertisementPortal.Persistence.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace AdvertisementPortal.Controllers
{
	public class AdvertisementController : Controller
	{
		private readonly IAdvertisementService _advertisementService;
		private readonly ICommentService _commentService;
		private readonly ICategoryService _categoryService;

		public AdvertisementController(
			IAdvertisementService advertisementService,
			ICommentService commentService,
			ICategoryService categoryService)
		{
			_advertisementService = advertisementService;
			_commentService = commentService;
			_categoryService = categoryService;
		}

		public IActionResult Index(int id)
		{
			AdvertisementViewModel advertisement = new AdvertisementViewModel();

			try
			{
				advertisement = _advertisementService
					.GetAdvertisement(id)
					.ToViewModel(
						User.GetUserId(),
						_commentService.GetComments(id),
						new Collection<Category>()
						);
			}
			catch (Exception)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(advertisement);
		}

		public IActionResult AddEdit(int id = 0)
		{
			var advertisement = new AdvertisementViewModel();

			if (id == 0)
			{
				advertisement.ViewHeading = "Dodawanie artykułu";
				advertisement.Categories = _categoryService.GetCategories();
			}
			else
			{
				try
				{
					advertisement = _advertisementService
						.GetAdvertisement(id)
						.ToViewModel(
							User.GetUserId(),
							new Collection<Comment>(),
							_categoryService.GetCategories()
							);
				}
				catch (Exception)
				{
					advertisement = new AdvertisementViewModel();
					advertisement.ViewHeading = "Dodawanie artykułu";
					advertisement.Categories = _categoryService.GetCategories();

					return View(advertisement);
				}

				advertisement.ViewHeading =
					"Edycja artykułu - " + advertisement.Title;
			}

			return View(advertisement);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddEdit(AdvertisementViewModel advertisement)
		{
			if (!ModelState.IsValid)
			{
				advertisement.ViewHeading = "Dodawanie artykułu";
				advertisement.Categories = _categoryService.GetCategories();

				return View(advertisement);
			}

			//	if (advertisement.Id == 0)
			//	{
			//		advertisement.AdvertisementUserId = User.GetUserId();
			//		_advertisementService.Add(advertisement);
			//	}
			//	else
			//	{
			//		_advertisementService.Update(advertisement);
			//	}

			return RedirectToAction("Index", "Home");
		}

		public IActionResult Delete(int id)
		{
			try
			{
				_advertisementService.Delete(id, User.GetUserId());
			}
			catch (Exception)
			{
				return RedirectToAction("Index", "Advertisement", new { id = id });
			}

			return RedirectToAction("Index", "Home");
		}
	}
}
