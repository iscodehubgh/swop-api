using AutoMapper;
using DAL.CustomModel.Auth;
using DAL.Interfaces.Auth;
using DAL.Models;

namespace DAL.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ExchangeContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(ExchangeContext context,
                              IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserRegistrationModel> Register(UserRegistrationModel user)
        {
            var databaseUser = new ApplicationUser
            {

            };

            UserRegistrationModel userRegistrationModel = _mapper.Map<UserRegistrationModel>(databaseUser);

            return userRegistrationModel;
        }
    }
}
