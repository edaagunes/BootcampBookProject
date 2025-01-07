using Microsoft.AspNetCore.Mvc;

namespace BootcampBookProject.ViewComponents
{
	public class _FooterLayout:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
