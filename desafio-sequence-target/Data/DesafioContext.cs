using desafio_sequence_target.Classes;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace desafio_sequence_target.Data
{
    public class DesafioContext : DbContext
    {
        public DbSet<Desafio> Desafio { get; set; }

        public DesafioContext(DbContextOptions<DesafioContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Desafio>().HasKey(x => x.Id);
            modelBuilder.Entity<Desafio>()
                .Property(x => x.Sequencia)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<List<int>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            modelBuilder.Entity<Desafio>()
                .Property(x => x.Sequencia)
                .IsUnicode(true)
                .HasMaxLength(int.MaxValue);
        }
    }
}
