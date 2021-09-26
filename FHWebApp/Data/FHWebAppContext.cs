using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FHWebApp.Models;

namespace FHWebApp.Data
{
    public class FHWebAppContext : DbContext
    {
        public FHWebAppContext (DbContextOptions<FHWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CardInfo> CardInfo { get; set; }
    }
}
