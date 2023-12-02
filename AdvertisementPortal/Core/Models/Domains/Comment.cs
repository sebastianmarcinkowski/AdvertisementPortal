using System.ComponentModel.DataAnnotations;

namespace AdvertisementPortal.Core.Models.Domains
{
	public class Comment
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Pole Zawartość jest wymagane.")]
		[Display(Name = "Zawartość")]
		public string Content { get; set; }

		public int AdvertisementId { get; set; }
		public string UserId { get; set; }

		public Advertisement Advertisement { get; set; }
		public User User { get; set; }
	}
}
