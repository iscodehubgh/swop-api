using Repository.DTOs.Users;
using Repository.Models;

namespace Services.Utils.Mappers
{
    public static class UsersMapper
    {
        public static UsersDTO MapUserFromEntityToDTO(ApplicationUser user)
        {
            return new UsersDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate ?? new DateTime(),
                Email = user.Email
            };
        }
    }
}
