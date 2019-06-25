using System;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task<int> SaveChanges();
        int ExecuteSqlCommand(string sql, params object[] parameters);
    }
}
