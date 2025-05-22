using Festivos.Persistencia.Contexto;
using IUPBFestivos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Festivos.Core.Repositorios;
using IUPBFestivos.Dominio.Dtos;


namespace Festivos.Infraestructura
{
    public class TipoRepositorio : ITipoRepositorio
    {
        private readonly FestivosContext Context;

        public TipoRepositorio(FestivosContext Context)
        {
            this.Context = Context;
        }

        public async Task<Tipo> Agregar(Tipo tipo)
        {
            Context.Tipos.Add(tipo);
            await Context.SaveChangesAsync();
            return tipo;
        }

        public async Task<IEnumerable<Tipo>> Buscar(string dato)
        {
            return await Context.Tipos
                .Where(t => t.Nombre.Contains(dato))
                .ToListAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            var tipoExistente = await Context.Tipos.FindAsync(id);
            if (tipoExistente == null)
            {
                return false;
            }
            try
            {
                Context.Tipos.Remove(tipoExistente);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tipo> Modificar(Tipo tipo)
        {
            var tipoExistente = await Context.Tipos.FindAsync(tipo.Id);
            if (tipoExistente == null) return null;

            Context.Tipos.Update(tipo);
            await Context.SaveChangesAsync();
            return tipo;
        }

        public async Task<Tipo> Obtener(int id)
        {
            return await Context.Tipos.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await Context.Tipos.ToListAsync();
        }
        public async Task<IEnumerable<FestivosportipoDtos>> ObtenerFestivosConNombreTipo(int tipoId)
        {
            return await Context.Festivos
                .Where(f => f.IdTipo == tipoId)
                .Include(f => f.Tipo)
                .Select(f => new FestivosportipoDtos
                {
                    Id = f.Id,
                    Nombre = f.Nombre,
                    NombreTipo = f.Tipo.Nombre
                })
                .ToListAsync();
        }
    }
}
