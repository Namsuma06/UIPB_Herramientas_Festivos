using Festivos.Core.Repositorios;
using Festivos.Core.Servicios;
using Festivos.Core.Utilidades;
using IUPBFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Aplicacion.Servicios
{
    public class FestivoAplicacion : IFestivoServicio
    {
        private readonly IFestivoRepositorio repositorio;

        public FestivoAplicacion(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Festivo> Agregar(Festivo festivo)
        {
            return await repositorio.Agregar(festivo);
        }

        public async Task<IEnumerable<Festivo>> Buscar(int tipo, string dato)
        {
            return await repositorio.Buscar(tipo, dato);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }

        public async Task<Festivo> Modificar(Festivo festivo)
        {
            return await repositorio.Modificar(festivo);
        }

        public async Task<Festivo> Obtener(int id)
        {
            return await repositorio.Obtener(id);
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }

        public async Task<string> ValidarFecha(DateTime fecha)
        {
            var festivos = await repositorio.ObtenerTodosFestivos();
            return CalcularFestivos.EsFestivo(fecha, festivos);
        }
    }
}

