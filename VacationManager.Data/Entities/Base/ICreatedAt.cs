﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationManager.Data.Entities.Base
{
    public interface ICreatedAt
    {
        DateTime? CreatedAt { get; set; }
    }
}
