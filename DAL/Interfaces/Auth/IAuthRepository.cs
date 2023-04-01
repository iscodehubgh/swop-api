using DAL.CustomModel.Auth;

namespace DAL.Interfaces.Auth
{
    public interface IAuthRepository
    {
        public Task<UserRegistrationModel> Register(UserRegistrationModel user);
    }
}
