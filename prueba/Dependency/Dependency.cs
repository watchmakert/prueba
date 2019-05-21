using Busisnes.AerolineasBusisness.Class;
using Busisnes.AerolineasBusisness.Interfaces;
using Busisnes.AeronavesBusisness.Class;
using Busisnes.AeronavesBusisness.Interfaces;
using Busisnes.Paises.Class;
using Busisnes.Paises.Interfaces;
using Busisnes.RutasBusisness.Class;
using Busisnes.RutasBusisness.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Dependency
{
    public class Dependency
    {
        public void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton(configuration);

            
            services.AddScoped<IAeronavesServices, AeronavesServices>();
            services.AddScoped<IRutaServices, RutasServices>();
            services.AddScoped<IAerolineasServices, AerolineasServices>();
            services.AddScoped<IPaisesServices, PaisesServices>();

        }

        internal void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
