using AdvertisementPortal.Core.Models;
using AdvertisementPortal.Core.Models.Domains;

namespace AdvertisementPortal.Core.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<Advertisement> Advertisements { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public Filter Filter { get; set; }
	}
}
