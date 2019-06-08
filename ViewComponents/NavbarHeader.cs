using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Common;
using shop.Repositories;

namespace shop.ViewComponents {

    public class NavbarHeader : ViewComponent {

        private IBranchRepository _branchRepository;

        public NavbarHeader (IBranchRepository branchRepository) {
            this._branchRepository = branchRepository;
        }

        public IViewComponentResult Invoke () {
            var branchName = this.HttpContext.Session.GetString (SessionConstant.BranchNameSession);
            if (string.IsNullOrEmpty (branchName)) {
                var branch = this._branchRepository.GetOne ();
                branchName = branch.Name;
            }
            return View ("NavbarHeader", branchName);
        }

    }
}