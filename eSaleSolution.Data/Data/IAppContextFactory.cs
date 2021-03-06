﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Data
{
    public interface IAppContextFactory<T> where T : DbContext
    {
        T GetContext();
    }
}
