﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passports
{
    public interface IDatabaseContext
    {
        string ConnectionString { get; }
    }
}
