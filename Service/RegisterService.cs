using Microsoft.EntityFrameworkCore;
using ShoppingKart.Data;
using ShoppingKart.Models;
using ShoppingKart.Repository;

namespace ShoppingKart.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly AppDbContext db;

        public RegisterService(AppDbContext appDb)
        {
            db = appDb;
        }

        public void RegisterUser(string name, string email, string password)
        {
            // UserModel user = new() { Name = name, Email = email, Password = password };

            //db.Add(user);
            //db.SaveChanges();

            int Rows = db.Database.ExecuteSqlInterpolated($"SP_RegisterUser {name}, {email}, {password}");



        }
    }
}
