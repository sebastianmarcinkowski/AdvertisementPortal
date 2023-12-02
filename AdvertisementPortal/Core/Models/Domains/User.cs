using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;

namespace AdvertisementPortal.Core.Models.Domains
{
	public class User : IdentityUser
	{
		public User()
		{
			Advertisements = new Collection<Advertisement>();
			Comments = new Collection<Comment>();
		}

		public ICollection<Advertisement> Advertisements { get; set; }
		public ICollection<Comment> Comments { get; set; }
	}
}
