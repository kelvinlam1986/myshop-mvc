using Microsoft.AspNetCore.Mvc;

namespace shop.ViewComponents {

    public class ProfileMenu : ViewComponent {
        public ProfileMenu () { }

        public IViewComponentResult Invoke () {
            var userName = (User.Identity != null) ? User.Identity.Name : "";
            return View ("ProfileMenu", userName);
        }

    }
}