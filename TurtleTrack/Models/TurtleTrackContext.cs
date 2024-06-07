using Microsoft.EntityFrameworkCore;

namespace TurtleTrack.Models
{
    public class TurtleTrackContext : DbContext
    {
        public TurtleTrackContext(DbContextOptions<TurtleTrackContext> options)
        : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<RegistroIncidentes> RegistroIncidentes { get; set; } = null!;
        public DbSet<RegiaoMonitorada> RegiaoMonitoradas { get; set; } = null!;
    }
}
