using Microsoft.AspNetCore.Mvc;
using ShoppingKart.Models;
using ShoppingKart.Repository;

namespace ShoppingKart.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService service;

        public LoginController(ILoginService loginService)
        {
            service = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ValidateLogin(string email, string password) 
        {
            string message;
            try
            {
                UserModel user = service.FindUserByEmail(email);

                if (user == null)
                {
                    message = "Email doesn't exist, Please Register!";

                    return Ok(new { status = false, message });
                }
                else
                {
                    message = "Login success!";
                    var redirectUrl = Url.Action("Index", "Home");

                    var IsValid = service.ValidateLogin(user, password);

                    if (!IsValid)
                    {
                        message = "Invalid password!";
                        redirectUrl = string.Empty;
                    }
                    return Ok(new { status = IsValid, message, redirectUrl });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
