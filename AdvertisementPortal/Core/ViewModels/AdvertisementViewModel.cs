using System.ComponentModel.DataAnnotations;

namespace AdvertisementPortal.Core.ViewModels
{
	public class AdvertisementViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime? LastUpdatedTime { get; set; }
		public string CategoryName { get; set; }
		public IEnumerable<CommentViewModel> Comments { get; set; }
		public string AdvertisementUserId { get; set; }
		public string CurrentUserId { get; set; }
		public string AdvertisementUserName { get; set; }

		[Display(Name = "Zawartość komentarza")]
		public string CommentContent { get; set; }
	}
}
