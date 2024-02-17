//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using ZeroOnzeTour.Models;

namespace ZeroOnzeTour.DB
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {

        }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ImagensTour> ImagensTour { get; set; }
        public DbSet<ViagemTour> ViagemTour { get; set; }
        public DbSet<Contrato> Contrato { get; set; }

    }
}
