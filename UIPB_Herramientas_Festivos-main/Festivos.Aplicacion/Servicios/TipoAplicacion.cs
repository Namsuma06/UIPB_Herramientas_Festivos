using Festivos.Core.Repositorios;
using Festivos.Core.Servicios;
using IUPBFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Aplicacion.Servicios
{
    public class TipoAplicacion : ITipoServicio
    {
        private readonly ITipoRepositorio repositorio;

        public TipoAplicacion(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Tipo> Agregar(Tipo tipo)
        {
            return await repositorio.Agregar(tipo);
        }

        public async Task<IEnumerable<Tipo>> Buscar(string dato)
        {
            return await repositorio.Buscar(dato);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }

        public async Task<Tipo> Modificar(Tipo tipo)
        {
            return await repositorio.Modificar(tipo);
        }

        public async Task<Tipo> Obtener(int id)
        {
            return await repositorio.Obtener(id);
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
    }

}