using Persistance;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using UserRegistrationApp.Models;
using UserRegistrationApp.Validators;

namespace UserRegistrationApp.Controllers
{
    public class SecurityController : Controller
    {
        private readonly LoginViewModelValidator _loginViewModelValidator;
        private readonly UserRepository _userRepository;
        public SecurityController(UserRepository userRepository, 
                                  LoginViewModelValidator loginViewModelValidator)
        {
            _loginViewModelValidator = loginViewModelValidator;
            _userRepository = userRepository;
        }
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
                var user = _userRepository.GetUserBy(userLogin.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("InvalidUser", "User Not exist!");
                    return View();
                }
                else if(user.Password != userLogin.Password)
                {
                    ModelState.AddModelError("PasswordError", "Incorrect Password!");
                    return View();
                }

                FormsAuthentication.SetAuthCookie(user.Id,true);

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
