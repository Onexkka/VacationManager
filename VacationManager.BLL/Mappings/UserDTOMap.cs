using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using VacationManager.BLL.DataModels;
using VacationManager.Data.Entities;
using VacationManager.Data.Identity;

namespace VacationManager.BLL.Mappings
{
    public class UserDTOMap : Profile
    {
        public UserDTOMap()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
