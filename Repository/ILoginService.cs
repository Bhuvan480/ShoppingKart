using ShoppingKart.Models;

namespace ShoppingKart.Repository
{
    public interface ILoginService
    {
        UserModel FindUserByEmail(string email);

        bool ValidateLogin(UserModel user, string password);
    }
}
