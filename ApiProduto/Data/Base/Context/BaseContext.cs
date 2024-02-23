using Data.Base.Classes;
using Data.Base.Interfaces;
using Data.Entities;
using Domain.Configuration.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configuration
{
    public class BaseContext : DbContext, IDisposable
    {
        public DbSet<Produto> Produtos { get; set; }
        public readonly string _connectionString;

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {}

        public void Dispose() => GC.SuppressFinalize(this);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Produto
            modelBuilder.Entity<Produto>().ToTable("Produtos"); // Nome da tabela no banco de dados
            modelBuilder.Entity<Produto>().HasKey(p => p.Codigo); // Chave primária
        }
    }

    public static class BaseContextFactory
    {
        public static BaseContext Create(IServiceProvider serviceProvider, Connection conn)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BaseContext>();
            optionsBuilder.UseMySQL(conn.Configuration);

            return new BaseContext(optionsBuilder.Options);
        }
    }
}
