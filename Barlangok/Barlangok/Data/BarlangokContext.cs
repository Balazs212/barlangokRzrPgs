using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Barlangok.Models;

namespace Barlangok.Data
{
    public class BarlangokContext : DbContext
    {
        public BarlangokContext(DbContextOptions<BarlangokContext> options)
            : base(options)
        {
        }

        public DbSet<Barlangok.Models.Barlang> Barlang { get; set; }
    }
}
