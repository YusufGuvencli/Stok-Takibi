using StokTakibi.DAL.EntitiyFramework.Repository;

namespace StokTakibi.DAL.EntitiyFramework.UnitOfWork
{
    public interface IUnitOfWorkBase
    {
        IRepositoryBase<T> GenericRepository<T>() where T : class, new();
        int Commit();
        void RejectChanges();
        void Dispose();

    }
}
