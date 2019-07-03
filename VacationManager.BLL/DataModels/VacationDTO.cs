using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationManager.BLL.DataModels
{
    public class VacationDTO
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
    }
}
