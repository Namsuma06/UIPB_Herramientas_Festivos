using IUPBFestivos.Dominio.Dtos;
using IUPBFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Core.Servicios
{
    public interface ITipoServicio
    {
        Task<Tipo> Agregar(Tipo tipo);
        Task<IEnumerable<Tipo>> Buscar(string dato);
        Task<bool> Eliminar(int id);
        Task<Tipo> Modificar(Tipo tipo);
        Task<Tipo> Obtener(int id);
        Task<IEnumerable<Tipo>> ObtenerTodos();
        Task<IEnumerable<FestivosportipoDtos>> ObtenerFestivosConNombreTipo(int tipoId);
    }
}
