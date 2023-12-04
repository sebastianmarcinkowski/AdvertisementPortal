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
		private readonly ICommentService _commentService;

		public AdvertisementController(
			IAdvertisementService advertisementService,
			ICommentService commentService)
		{
			_advertisementService = advertisementService;
			_commentService = commentService;
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
						_commentService.GetComments(id)
						);
			}
			catch (Exception)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(advertisement);
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
