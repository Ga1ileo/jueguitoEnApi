using Microsoft.EntityFrameworkCore;
using jueguitoEnApi.Models;

namespace jueguitoEnApi.DAL
{
    public class Contexto : DbContext
    {
   
        public DbSet<Jugador> Jugadores { get; set; }
    
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            

        }


    }
}
