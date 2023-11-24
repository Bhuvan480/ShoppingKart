using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ShoppingKart.Data;
using ShoppingKart.Models;
using ShoppingKart.Repository;
using ShoppingKart.Service;

namespace ShoppingKart.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] UserModel user)
        {
            try
            {
                _registerService.RegisterUser(user.Name, user.Email, user.Password);

                string redirectUrl = Url.Action("Index", "Login");

                return Json(new { success = true, redirectUrl });
            }

            catch (SqlException e)
            {
                if (e.Message.Contains("duplicate"))
                {
                    return Json(new { success = false, e.Message });
                }
                return StatusCode(500, e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
