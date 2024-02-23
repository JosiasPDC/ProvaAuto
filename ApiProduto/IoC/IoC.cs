using Domain.Configuration.Dto;
using IoC.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IoC
{
    public static class IoC
    {
        public static void Start(IServiceCollection Services, IConfiguration Configurations)
        {
            Connection Conn = new Connection();
            Conn.Configuration = Configurations.GetSection("Data:Connection:Configuration").Value ?? string.Empty;
            
            DomainModule.Start(Services, Configurations);
            RepositoryModule.Start(Services, Conn);
        }
    }
}
