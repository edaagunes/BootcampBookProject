using Microsoft.AspNetCore.Mvc;

namespace BootcampBookProject.ViewComponents
{
	public class _NavbarLayout : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
