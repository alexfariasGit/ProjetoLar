using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Configuração explícita do relacionamento entre Pessoa e Telefone
            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Telefones) 
                .WithOne(t => t.Pessoa)  
                .HasForeignKey(t => t.PessoaID)  
                .OnDelete(DeleteBehavior.Cascade); 

            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Pessoa>().HasKey(p => p.PessoaID);
            //modelBuilder.Entity<Telefone>().HasKey(t => t.TelefoneID);
            //modelBuilder.Entity<Pessoa>()
            //    .HasMany(p => p.Telefones)
            //    .WithOne()
            //    .HasForeignKey(t => t.PessoaID);
        }
    }
}