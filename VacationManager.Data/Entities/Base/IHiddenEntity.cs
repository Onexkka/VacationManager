﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationSystem.Data.Entities.Base
{
    public interface IHiddenEntity
    {
        bool IsHidden { get; set; }
    }
}
