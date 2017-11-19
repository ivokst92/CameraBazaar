namespace CameraBazaar.Services.Interfaces
{
    using CameraBazaar.Services.BusinessModels;

    public interface IUserService
    {
        UserDTO GetUserByUsername(string username);
        void Update(UserDTO user);
    }
}
