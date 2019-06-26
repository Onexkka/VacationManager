using AutoMapper;
using VacationManager.BLL.DataModels;
using VacationManager.WEB.Models;

namespace VacationManager.WEB.Mappings
{
    public class UserVMMap : Profile
    {
        public UserVMMap()
        {
            CreateMap<UserDTO, UserViewModel>();
        }
    }
}