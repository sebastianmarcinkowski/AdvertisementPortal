using AdvertisementPortal.Core.Models.Domains;
using AdvertisementPortal.Core.ViewModels;
using System.Collections.ObjectModel;

namespace AdvertisementPortal.Core.Converters
{
	public static class AdvertisementConverter
	{
		public static AdvertisementViewModel ToViewModel(this Advertisement model, string userId)
		{
			var comments = new Collection<CommentViewModel>();

			foreach (var comment in model.Comments)
			{
				comments.Add(new CommentViewModel
				{
					Id = comment.Id,
					Content = comment.Content,
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
				CategoryName = model.Category.Name,
				AdvertisementUserId = model.UserId,
				CurrentUserId = userId,
				AdvertisementUserName = model.User.Email,
				Comments = comments
			};
		}
	}
}
