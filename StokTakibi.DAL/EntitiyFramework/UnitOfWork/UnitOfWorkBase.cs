using StokTakibi.DAL.EntitiyFramework.Repository;
using StokTakibi.Helper.TryCatch;
using System.Collections;
using System.Data.Entity;
using System.Linq;

namespace StokTakibi.DAL.EntitiyFramework.UnitOfWork
{
    public class UnitOfWorkBase
    {
        private readonly StokContext _context;
        private Hashtable _repositories;

        public UnitOfWorkBase(StokContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public IRepositoryBase<T> GenericRepository<T>() where T : class, new()
        {
            if (!_repositories.Contains(typeof(T)))
            {
                _repositories.Add(typeof(T), new RepositoryBase<T>(_context));
            }
            return (IRepositoryBase<T>)_repositories[typeof(T)];
        }
        /// <summary>
        /// Repositoryleri database'e gonderir.
        /// Hata olmasi durumunda -1 doner.
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            int result = -1;

            DynamicTryCatch.TryCatchLogla(() =>
            {
                result = _context.SaveChanges();
            }, "StokTakibi.DAL.EntitiyFramework.UnitOfWork.Commit");

            return result;
        }
        public void RejectChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
