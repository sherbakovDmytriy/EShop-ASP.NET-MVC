using System;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int SaveChanges();
        int ExecuteSqlCommand(string sql, params object[] parameters);
    }
}
