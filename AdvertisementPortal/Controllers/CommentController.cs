using AdvertisementPortal.Core.Converters;
using AdvertisementPortal.Core.Services;
using AdvertisementPortal.Core.ViewModels;
using AdvertisementPortal.Persistence.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementPortal.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;

		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(AdvertisementViewModel advertisement)
		{
			ModelState.Remove("Title");
			ModelState.Remove("Content");
			ModelState.Remove("CreatedTime");
			ModelState.Remove("LastUpdatedTime");
			ModelState.Remove("CategoryName");
			ModelState.Remove("Comments");
			ModelState.Remove("AdvertisementUserId");
			ModelState.Remove("CurrentUserId");
			ModelState.Remove("AdvertisementUserName");


			if (!ModelState.IsValid)
				return RedirectToAction("Index", "Advertisement", new { id = advertisement.Id });

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
