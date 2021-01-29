using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAPIMuitos_Para_MuitosDomain.Data;
using WebAPIMuitos_Para_MuitosDomain.Models;

namespace WebApiMuitos_ParaMuitosRepository
{
    public class WebApiRepository : IWebApiRepository
    {
        private readonly AppDbContext _context;

        public WebApiRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChagesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        // ========================================================

        public Task<Grupo[]> GetGrupos()
        {
            IQueryable<Grupo> query = _context.Grupos
                .Include(u => u.Usuarios);

                query = query.AsNoTracking()
                .OrderBy(g => g.Id);

            return query.ToArrayAsync();                
        }

        public Task<Grupo> GetGrupoId(int Id)
        {
            IQueryable<Grupo> query = _context.Grupos
               .Include(u => u.Usuarios);

            query = query.AsNoTracking()
                .OrderByDescending(g => g.GrupoNome)
                .Where(g => g.Id == Id);

            return query.FirstOrDefaultAsync();
        }

        public Task<Usuario[]> GetUsuarios()
        {
            IQueryable<Usuario> query = _context.Usuarios
                .Include(g => g.Grupos);

            query = query.AsNoTracking()
                .OrderBy(u => u.Id);

            return query.ToArrayAsync();
        }

        public Task<Usuario> GetUsuarioId(int Id)
        {
            IQueryable<Usuario> query = _context.Usuarios
              .Include(g => g.Grupos);

            query = query.AsNoTracking()
                .OrderByDescending(u => u.Id)
                .Where(u => u.Id == Id);

            return query.FirstOrDefaultAsync();
        }
    }
}