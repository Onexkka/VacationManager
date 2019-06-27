using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VacationManager.BLL.DataModels;
using VacationManager.Data.Entities;

namespace VacationManager.BLL.Mappings
{
    public class VacationDTOMap : Profile
    {
        public VacationDTOMap()
        {
            CreateMap<Vacation, VacationDTO>()
                .ForMember(d => d.UserName, 
                    opt => opt.MapFrom(s => s.User.FirstName + " " + s.User.LastName)).ReverseMap();
        }
    }
}
