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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configurações das Tabelas

            modelBuilder.Entity<Cliente>().ToTable("Cliente");

            #endregion

            #region Configurações de Cliente

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.ClienteId);
            
            modelBuilder.Entity<Cliente>().Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                 .IsRequired();

            modelBuilder.Entity<Cliente>().Property(e => e.Cpf)
                .HasColumnType("varchar(11)")
                .IsRequired();
            
            modelBuilder.Entity<Cliente>().Property(e => e.Telefone)
               .HasColumnType("varchar(15)");
            
            modelBuilder.Entity<Cliente>().Property(e => e.Email)
               .HasColumnType("varchar(200)")
               .IsRequired();

            #endregion

        }
    }
}
