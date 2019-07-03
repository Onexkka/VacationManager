using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VacationManager.WEB.Models
{
    public class VacationViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
    }
}