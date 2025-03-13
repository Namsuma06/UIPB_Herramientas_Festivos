using Festivos.Core.Repositorios;
using Festivos.Persistencia.Contexto;
using IUPBFestivos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Infraestructura
{
    public class FestivosRepositorio : IFestivoRepositorio
    {
        private readonly FestivosContext contexto;
        private Festivo festivo;

        public FestivosRepositorio(FestivosContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Festivo> Agregar(Festivo festivo)
        {
            contexto.Festivos.Add(festivo);
            await contexto.SaveChangesAsync();
            return festivo;
        }
        public async Task<IEnumerable<Festivo>> Buscar(int tipo, string dato)
        {
            return await contexto.Festivos
                .Where(f => f.IdTipo == tipo && f.Nombre.Contains(dato))
                .ToListAsync();
        }
        public async Task<bool> Eliminar(int id)
        {
            contexto.Festivos.Remove(festivo);
            await contexto.SaveChangesAsync();
            return true;
        }
        public async Task<Festivo> Modificar(Festivo festivo)
        {
            contexto.Festivos.Update(festivo);
            await contexto.SaveChangesAsync();
            return festivo;
        }
        public async Task<Festivo> Obtener(int id)
        {
            return await contexto.Festivos.Include(f => f.Tipo)
                              .FirstOrDefaultAsync(f => f.Id == id);
        }
        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await contexto.Festivos.Include(f => f.Tipo).ToListAsync();
        }
    }
}
