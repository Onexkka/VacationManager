﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacationManager.WEB.Models
{
    public class MonthViewModel
    {
        public DateTime Date { get; set; }
        public DayViewModel[,] Days { get; set; }
    }
}