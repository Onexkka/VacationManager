using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VacationManager.BLL.DataModels;
using VacationManager.WEB.Models;

namespace VacationManager.WEB.Mappings
{
    public class RoleVMMap : Profile
    {
        public RoleVMMap()
        {
            CreateMap<RoleDTO, RoleViewModel>();
        }
    }
}