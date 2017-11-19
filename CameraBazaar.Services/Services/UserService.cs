namespace CameraBazaar.Services.Services
{
    using CameraBazaar.Data;
    using CameraBazaar.Data.Models;
    using CameraBazaar.Services.BusinessModels;
    using CameraBazaar.Services.Interfaces;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly CameraBazaarDbContext db;
        public UserService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public UserDTO GetUserByUsername(string username)
        => this.db
                .Users
                .Where(x => x.UserName == username)
                .Select(x => new UserDTO
                {
                    Id = x.Id,
                    Email=x.Email,
                    Phone=x.PhoneNumber
                })
                .First();

    public void Update(UserDTO user)
    {
        var dbUser = this.db.Users.Find(user.Id);
        if (db == null)
        {
            return;
        }
        //Password already hashed
        dbUser.PasswordHash = user.Password;
        dbUser.Email = user.Email;
        dbUser.PhoneNumber = user.Phone;
        this.db.Users.Update(dbUser);
        this.db.SaveChanges();
    }
}
}
