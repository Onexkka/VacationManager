using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VacationManager.WEB.App_LocalResources;

namespace VacationManager.WEB.Models
{
    public class BaseVacationViewModel
    {
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
    }

    public class VacationViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }
        public string UserName { get; set; }

        [StringLength(256, MinimumLength = 3, ErrorMessage = "Ну хоть немного расскажи про отпуск")]
        [Display(Name = "Description", ResourceType = typeof(Resource))]
        public string Description { get; set; }
    }
}