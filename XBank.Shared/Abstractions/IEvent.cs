﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBank.Shared.Abstractions
{
    public interface IEvent
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
