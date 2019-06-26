using AutoMapper;
using VacationManager.BLL.DataModels;
using VacationManager.Data.Entities;

namespace VacationManager.BLL.Mappings
{
    public class UserDTOMap : Profile
    {
        public UserDTOMap()
        {
            CreateMap<User, UserDTO>()
                .ForMember(d => d.FullName, 
                    opt => opt.MapFrom(s => s.FirstName + " " + s.LastName));
        }
    }
}
