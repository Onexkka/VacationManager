using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Data.Entities;
using VacationManager.Data.Identity;

namespace VacationManager.BLL.DataModels
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public IEnumerable<RoleDTO> Roles { get; set; }
    }
}
