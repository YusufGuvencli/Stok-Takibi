using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StokTakibi.DAL.EntitiyFramework.Repository
{
    public interface IRepositoryBase<T> where T : class, new()
    {
        int Add(T entity);
        int Update(T entity);
        int Remove(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        T FirstOrDefault(Expression<Func<T, bool>> expression);

        bool Any(Expression<Func<T, bool>> expression);
        int RemoveRange(IEnumerable<T> entity);
        int InsertWithProcedure(string query, params object[] parameters);
        void SqlQuery(string query);
    }
}
