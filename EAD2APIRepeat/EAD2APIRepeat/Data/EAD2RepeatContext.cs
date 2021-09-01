using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EAD2APIRepeat;

namespace EAD2APIRepeat.Data
{
    public class EAD2RepeatContext : DbContext
    {
        public EAD2RepeatContext(DbContextOptions<EAD2RepeatContext> options)
           : base(options)
        {
        }

        public DbSet<EAD2APIRepeat.Forecasts> forecasts { get; set; }

    }
}
