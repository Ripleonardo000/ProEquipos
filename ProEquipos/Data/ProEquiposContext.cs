using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEquipos.Models;

namespace ProEquipos.Data
{
    public class ProEquiposContext : DbContext
    {
        public ProEquiposContext (DbContextOptions<ProEquiposContext> options)
            : base(options)
        {
        }

        public DbSet<ProEquipos.Models.Jugador> Jugador { get; set; } = default!;
        public DbSet<ProEquipos.Models.Equipo> Equipo { get; set; } = default!;
        public DbSet<ProEquipos.Models.Estadio> Estadio { get; set; } = default!;
    }
}
