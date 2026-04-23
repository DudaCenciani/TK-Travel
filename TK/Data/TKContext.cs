using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TK.Models;

namespace TK.Data
{
    public class TKContext : DbContext
    {
        public TKContext (DbContextOptions<TKContext> options)
            : base(options)
        {
        }

        public DbSet<TK.Models.Promocao> Promocao { get; set; } = default!;
        public DbSet<TK.Models.Lead> Lead { get; set; } = default!;
    }
}
