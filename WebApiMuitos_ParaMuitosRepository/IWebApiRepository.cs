using System.Threading.Tasks;
using WebAPIMuitos_Para_MuitosDomain.Models;

namespace WebApiMuitos_ParaMuitosRepository
{
    public interface IWebApiRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entityRange) where T : class;

        Task<bool> SaveChagesAsync();

        //==========================================================

        Task<Grupo[]> GetGrupos();
        Task<Grupo> GetGrupoId(int Id);

        Task<Usuario[]> GetUsuarios();
        Task<Usuario> GetUsuarioId(int Id);                          
    }
}
