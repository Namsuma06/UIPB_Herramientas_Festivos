using Festivos.Aplicacion.Servicios;
using Festivos.Core.Repositorios;
using Festivos.Core.Servicios;
using Festivos.Infraestructura;
using Festivos.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Festivos.Presentacion.Di
{
    public static class InyeccionDependencia
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios,
    IConfiguration Configuracion)
        {
            //agregar la instancia del DbContext
            servicios.AddDbContext<FestivosContext>(opciones =>
            {
                opciones.UseSqlServer(Configuracion.GetConnectionString("Festivos"));
            });

            //agregar repositorios
            servicios.AddTransient<IFestivoRepositorio, FestivosRepositorio>();
            servicios.AddTransient<ITipoRepositorio, TipoRepositorio>();

            //agregar servicios
            servicios.AddTransient<IFestivoServicio, FestivoAplicacion>();
            servicios.AddTransient<ITipoServicio, TipoAplicacion>();

            return servicios;
        }
    }
}