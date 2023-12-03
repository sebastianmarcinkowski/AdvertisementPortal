using AdvertisementPortal.Core.Repositories;

namespace AdvertisementPortal.Core
{
	public interface IUnitOfWork
	{
		IAdvertisementRepository Advertisement { get; }
		ICategoryRepository Category { get; }
		ICommentRepository Comment { get; }

		public void Complete();
	}
}
