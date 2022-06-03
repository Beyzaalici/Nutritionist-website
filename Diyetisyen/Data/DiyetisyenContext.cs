using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Diyetisyen.Models;

namespace Diyetisyen.Data
{
    public class DiyetisyenContext : DbContext
    {
        public DiyetisyenContext(DbContextOptions<DiyetisyenContext> options)
             : base(options)
        {
        }

        public DbSet<Diyetisyen.Models.Kullanicilar> Kullanicilar { get; set; }
    }
}
