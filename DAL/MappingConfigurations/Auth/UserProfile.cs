using AutoMapper;
using DAL.CustomModel.Auth;
using DAL.Models;

namespace DAL.MappingConfigurations.Auth
{
    public class UserProfileUserProfile : Profile
    {
        public class UserProfile : Profile
        {
            public UserProfile()
            {
                // Default mapping when property names are same
                CreateMap<ApplicationUser, UserRegistrationModel>();

                // Mapping when property names are different
                //CreateMap<User, UserViewModel>()
                //    .ForMember(dest =>
                //    dest.FName,
                //    opt => opt.MapFrom(src => src.FirstName))
                //    .ForMember(dest =>
                //    dest.LName,
                //    opt => opt.MapFrom(src => src.LastName));
            }
        }
    }
}
