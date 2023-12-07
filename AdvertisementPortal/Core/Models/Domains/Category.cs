using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AdvertisementPortal.Core.Models.Domains
{
	public class Category
	{
		public Category()
		{
			Advertisements = new Collection<Advertisement>();
		}

		[Required(ErrorMessage = "Pole Kategoria jest wymagane.")]
		[Display(Name = "Kategoria")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
		[Display(Name = "Nazwa")]
		public string Name { get; set; }

		public ICollection<Advertisement> Advertisements { get; set; }
	}
}
