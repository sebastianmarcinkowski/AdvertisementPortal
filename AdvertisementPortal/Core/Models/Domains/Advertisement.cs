using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AdvertisementPortal.Core.Models.Domains
{
	public class Advertisement
	{
		public Advertisement()
		{
			Comments = new Collection<Comment>();
		}

		public int Id { get; set; }

		[Required(ErrorMessage = "Pole Tytuł jest wymagane.")]
		[Display(Name = "Tytuł")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Pole Zawartość jest wymagane.")]
		[Display(Name = "Zawartość")]
		public string Content { get; set; }

		[Required(ErrorMessage = "Pole Kategoria jest wymagane.")]
		[Display(Name = "Kategoria")]
		public int CategoryId { get; set; }

		public DateTime CreatedTime { get; set; }
		public DateTime? LastUpdatedTime { get; set; }
		public byte[]? Image { get; set; }
		public string UserId { get; set; }

		public Category Category { get; set; }
		public User User { get; set; }
		public ICollection<Comment> Comments { get; set; }
	}
}
