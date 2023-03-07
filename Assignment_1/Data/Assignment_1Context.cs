﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment_1.Models;

namespace Assignment_1.Data
{
    public class Assignment_1Context : DbContext
    {
        public Assignment_1Context (DbContextOptions<Assignment_1Context> options)
            : base(options)
        {
        }

        public DbSet<Assignment_1.Models.ValueKey> ValueKey { get; set; } = default!;
    }
}