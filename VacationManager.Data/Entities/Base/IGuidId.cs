﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationSystem.Data.Entities.Base
{
    public interface IGuidId
    {
        Guid Id { get; set; }
    }
}
