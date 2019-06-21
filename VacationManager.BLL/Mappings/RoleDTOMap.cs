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
            #region RoleRegion
            CreateMap<AspnetUserRole, RoleDTO>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Role.Name));
            #endregion
        }
    }
}
