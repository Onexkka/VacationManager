using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VacationManager.BLL.DataModels;
using VacationManager.Data.Entities;
using VacationManager.Data.Identity;

namespace VacationManager.BLL.Mappings
{
    public class RoleDTOMap : Profile
    {
        public RoleDTOMap()
        {

            CreateMap<Role, RoleDTO>();
        }
    }
}
