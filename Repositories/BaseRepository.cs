using CasaDoCodigo.Data;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly AppDbContext context;
        protected  readonly DbSet<T> dbSet;
        public BaseRepository(AppDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

    }
}
