using AdvertisementPortal.Core.Converters;
using AdvertisementPortal.Core.Services;
using AdvertisementPortal.Core.ViewModels;
using AdvertisementPortal.Persistence.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementPortal.Controllers
{
	public class CommentController : Controller
	{

		private readonly IAdvertisementService _advertisementService;
		private readonly ICommentService _commentService;
		private readonly ICategoryService _categoryService;

		public CommentController(
			IAdvertisementService advertisementService,
			ICommentService commentService,
			ICategoryService categoryService)
		{
			_commentService = commentService;
			_advertisementService = advertisementService;
			_categoryService = categoryService;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(AdvertisementViewModel advertisement)
		{
			ModelState.Remove("Title");
			ModelState.Remove("Content");
			ModelState.Remove("CreatedTime");
			ModelState.Remove("LastUpdatedTime");
			ModelState.Remove("Category");
			ModelState.Remove("Categories");
			ModelState.Remove("Comments");
			ModelState.Remove("AdvertisementUserId");
			ModelState.Remove("CurrentUserId");
			ModelState.Remove("AdvertisementUserName");
			ModelState.Remove("ViewHeading");


			if (!ModelState.IsValid)
			{
				var advertisementViewModel = _advertisementService
					.GetAdvertisement(advertisement.Id)
					.ToViewModel(
						User.GetUserId(),
						_commentService.GetComments(advertisement.Id),
						_categoryService.GetCategories()
						);

				advertisementViewModel.CommentContent = advertisement.CommentContent;

				return View("~/Views/Advertisement/Index.cshtml", advertisementViewModel);
			}


			var comment = advertisement.NewComment(User.GetUserId());
			_commentService.Add(comment);

			return RedirectToAction("Index", "Advertisement", new { id = advertisement.Id });
		}

		public IActionResult Delete(int id, int advertisementId)
		{
			try
			{
				_commentService.Delete(id, advertisementId, User.GetUserId());
			}
			catch
			{
				return RedirectToAction("Index", "Advertisement", new { id = advertisementId });
			}

			return RedirectToAction("Index", "Advertisement", new { id = advertisementId });
		}
	}
}
