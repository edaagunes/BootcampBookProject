using Microsoft.AspNetCore.Mvc;

namespace BootcampBookProject.ViewComponents
{
	public class _SidebarLayout:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
