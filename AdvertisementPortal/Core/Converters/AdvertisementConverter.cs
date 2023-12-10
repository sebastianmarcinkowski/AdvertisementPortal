using AdvertisementPortal.Core.Models.Domains;
using AdvertisementPortal.Core.ViewModels;

namespace AdvertisementPortal.Core.Converters
{
	public static class AdvertisementConverter
	{
		public static AdvertisementViewModel ToViewModel(
			this Advertisement model,
			string userId,
			IEnumerable<Comment> comments,
			IEnumerable<Category> categories)
		{
			var commentsViewModel = new List<CommentViewModel>();

			foreach (var comment in comments)
			{
				commentsViewModel.Add(new CommentViewModel
				{
					Id = comment.Id,
					Content = comment.Content,
					CreatedDate = comment.CreatedDate,
					CommentUserId = comment.UserId,
					CommentUserName = comment.User.Email
				});
			}

			return new AdvertisementViewModel
			{
				Id = model.Id,
				Title = model.Title,
				Content = model.Content,
				CreatedTime = model.CreatedTime,
				LastUpdatedTime = model.LastUpdatedTime,
				Category = model.Category,
				Categories = categories,
				AdvertisementUserId = model.UserId,
				CurrentUserId = userId,
				AdvertisementUserName = model.User.Email,
				Comments = commentsViewModel
			};
		}

		public static Advertisement NewAdvertisement(this AdvertisementViewModel model, string userId)
		{
			return new Advertisement
			{
				Title = model.Title,
				Content = model.Content,
				CategoryId = model.Category.Id,
				CreatedTime = DateTime.Now,
				LastUpdatedTime = null,
				UserId = userId
			};
		}

		public static Advertisement UpdateAdvertisement(this AdvertisementViewModel model)
		{
			return new Advertisement
			{
				Id = model.Id,
				Title = model.Title,
				Content = model.Content,
				CategoryId = model.Category.Id,
				LastUpdatedTime = DateTime.Now,
				UserId = model.AdvertisementUserId
			};
		}

		public static Comment NewComment(this AdvertisementViewModel model, string userId)
		{
			return new Comment
			{
				Content = model.CommentContent,
				AdvertisementId = model.Id,
				UserId = userId,
				CreatedDate = DateTime.Now
			};
		}
	}
}
