using Microsoft.AspNetCore.Mvc;

namespace BootcampBookProject.ViewComponents
{
	public class _ScriptLayout:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
