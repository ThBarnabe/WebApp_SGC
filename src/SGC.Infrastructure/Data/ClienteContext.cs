using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.Data
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; } 
        //public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configurações das Tabelas

            modelBuilder.Entity<Cliente>().ToTable("Cliente"); 
            modelBuilder.Entity<Contato>().ToTable("Contato");

            #endregion

            #region Configurações de Cliente

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.ClienteId);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Contatos)
                .WithOne(c => c.Cliente)
                .HasForeignKey(c => c.ClienteId)
                .HasPrincipalKey(c => c.ClienteId);

            modelBuilder.Entity<Cliente>().Property(e => e.Cpf)
                .HasColumnType("varchar(11)")
                .IsRequired();

            modelBuilder.Entity<Cliente>().Property(e => e.Nome)
               .HasColumnType("varchar(200)")
               .IsRequired();

            #endregion

            #region Configurações de Contato

            modelBuilder.Entity<Contato>().Property(e => e.Nome)
               .HasColumnType("varchar(200)")
               .IsRequired();

            modelBuilder.Entity<Contato>().Property(e => e.Email)
               .HasColumnType("varchar(200)")
               .IsRequired();

            modelBuilder.Entity<Contato>().Property(e => e.Telefone)
               .HasColumnType("varchar(15)");
            #endregion
        }
    }
}
