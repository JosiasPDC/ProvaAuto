using Domain.Implementation.Classes;
using Domain.Implementation.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Modules
{
    public static class DomainModule
    {
        public static void Start(IServiceCollection services, IConfiguration configurations)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}
