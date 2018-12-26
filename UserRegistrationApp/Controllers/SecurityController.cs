using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using UserRegistrationApp.Models;

namespace UserRegistrationApp.Controllers
{
    public class SecurityController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserName,Password")] LoginViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(userLogin.UserName,true);
                return Redirect(Url.Action("Index", "Home"));
            }

            return View(userLogin);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return Login();
        }
    }
}
