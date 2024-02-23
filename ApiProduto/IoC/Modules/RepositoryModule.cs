using Data.Repository.Classes;
using Data.Repository.Interfaces;
using Domain.Configuration;
using Domain.Configuration.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Modules
{
    public static class RepositoryModule
    {
        public static void Start(IServiceCollection services, Connection conn)
        {
            //Configuration
            services.AddDbContext<BaseContext>(options => options.UseMySQL(conn.Configuration));
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
