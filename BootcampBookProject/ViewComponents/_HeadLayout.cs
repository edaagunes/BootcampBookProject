using Microsoft.AspNetCore.Mvc;

namespace BootcampBookProject.ViewComponents
{
	public class _HeadLayout : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
