using IUPBFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Core.Servicios
{
    public interface IFestivoServicio
    {
        Task<Festivo> Agregar(Festivo festivo);
        Task<IEnumerable<Festivo>> Buscar(int tipo, string dato);
        Task<bool> Eliminar(int id);
        Task<Festivo> Modificar(Festivo festivo);
        Task<Festivo> Obtener(int id);
        Task<IEnumerable<Festivo>> ObtenerTodos();
    }
}

