using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda
{
    public class AgendaDbContext : DbContext
    {
        DbSet<Pessoa> Pessoas { get; set; }
        DbSet<Telefone> Telefones { get; set; }
        DbSet<Endereco> Enderecos { get; set; }

        public AgendaDbContext(DbContextOptions options) : base(options)
        {

        }

        public AgendaDbContext()
        {
            
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(entity => {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Nome).HasMaxLength(100);
                entity.Property(o => o.Sobrenome).HasMaxLength(200);
                entity.Property(o => o.Nascimento).HasColumnType("date");
            });

            modelBuilder.Entity<Endereco>(entity => {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Logradouro).HasMaxLength(100);
                entity.Property(o => o.Cidade).HasMaxLength(30);
                entity.Property(o => o.Estado).HasMaxLength(30);
                entity.Property(o => o.Numero).HasMaxLength(10);
                entity.Property(o => o.CEP).HasMaxLength(10);
            });

            modelBuilder.Entity<Telefone>(entity => {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Numero).HasMaxLength(20);
            });
        }
    }
}