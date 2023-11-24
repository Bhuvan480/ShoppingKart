using ShoppingKart.Data;
using ShoppingKart.Models;
using ShoppingKart.Repository;

namespace ShoppingKart.Service
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext db;

        public LoginService(AppDbContext appDbContext) 
        {
            db = appDbContext;
        }
        public UserModel FindUserByEmail(string email)
        {
            UserModel user = db.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }

        public bool ValidateLogin(UserModel user, string password)
        {
            if(user.Password.Equals(password))
            {
                return true;
            }

            return false;
        }
    }
}
