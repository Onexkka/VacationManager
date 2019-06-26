using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacationManager.WEB.Models
{
    public class VacationViewModel
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string UserName { get; set; }
    }
}