using AdvertisementPortal.Core.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace AdvertisementPortal.Core.ViewModels
{
	public class AdvertisementViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Pole Tytuł jest wymagane.")]
		[Display(Name = "Tytuł")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Pole Treść jest wymagane.")]
		[Display(Name = "Treść")]
		public string Content { get; set; }

		public DateTime CreatedTime { get; set; }
		public DateTime? LastUpdatedTime { get; set; }
		public Category Category { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public IEnumerable<CommentViewModel> Comments { get; set; }
		public string AdvertisementUserId { get; set; }
		public string CurrentUserId { get; set; }
		public string AdvertisementUserName { get; set; }
		public string ViewHeading { get; set; }


		[Required(ErrorMessage = "Aby dodać komentarz należy uzupełnić jego treść.")]
		public string CommentContent { get; set; }
	}
}
