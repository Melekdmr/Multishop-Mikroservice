using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayout:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
