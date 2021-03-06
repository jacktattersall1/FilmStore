﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FilmStore.core.Properties;
using FilmStore.core.Models;

namespace FilmStore.core
{
    class FilmStoreContext : DbContext
    {
        public FilmStoreContext() : base(new Settings().connectionString)
        {

        }
        public DbSet<Film> Films { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
