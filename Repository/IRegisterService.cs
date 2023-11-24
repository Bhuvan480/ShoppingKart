namespace ShoppingKart.Repository
{
    public interface IRegisterService
    {
        void RegisterUser(string name, string email, string password);
    }
}
