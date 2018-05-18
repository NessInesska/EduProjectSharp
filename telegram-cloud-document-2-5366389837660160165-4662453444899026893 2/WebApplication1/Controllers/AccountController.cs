using System.Web.Mvc;
using System.Web.Security;

using WebApplication1.Models;
using WebApplication1.ViewModels.Account;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (AuthLogic.CanAuthenticate(model.Login, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Login, false);
                return RedirectToAction("Index", "Note");
            }

            ModelState.AddModelError(string.Empty, "Bad login/password");
            return View(model);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("~");
        }
    }
}