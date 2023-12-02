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

		public int Id { get; set; }

		[Required(ErrorMessage = "Pole Tytuł jest wymagane.")]
		[Display(Name = "Nazwa")]
		public string Name { get; set; }

		public ICollection<Advertisement> Advertisements { get; set; }
	}
}
