using StokTakibi.Helper.TryCatch;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace StokTakibi.DAL.EntitiyFramework.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private StokContext context;
        public RepositoryBase(StokContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Koleksiyona yeni değer eklemek için kullanılır.
        /// Girilen entityi veritabanına ekler.
        /// Hata alması durumunda -1 döner.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(T entity)
        {
            int result = 0;

            DynamicTryCatch.TryCatchLogla(() =>
            {
                context.Set<T>().Add(entity);
                result = 1;
            }, "StokTakibi.DAL.EntitiyFramework.Repository.Add");

            return result;
        }
        /// <summary>
        /// Değerin var olup olmadığını kontrol amaçlı kullanılır.
        /// Boolean değer döner.
        /// Hata alması durumunda false döner.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> expression)
        {
            bool result = false;

            DynamicTryCatch.TryCatchLogla(() =>
            {
                result = expression == null ? context.Set<T>().Any()
                    : context.Set<T>().Any(expression);
            }, "StokTakibi.DAL.EntitiyFramework.Repository.Any");

            return result;
        }



        /// <summary>
        /// Girilen entityi veritabanından siler.
        /// Hata alması durumunda -1 döner.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(T entity)
        {
            int result = -1;

            DynamicTryCatch.TryCatchLogla(() =>
            {

                context.Entry(entity).State = EntityState.Modified;
                result = 1;
            }, "StokTakibi.DAL.EntitiyFramework.Repository.Update");

            return result;
        }
        /// <summary>
        /// Verilen expressiona göre ilk değeri döner. 
        /// Eğer değer yok ise default sıfır döner.
        /// Hata alması durumunda null döner.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            T result = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                result = expression == null
                    ? context.Set<T>().FirstOrDefault()
                    : context.Set<T>().FirstOrDefault(expression);
            }, "StokTakibi.DAL.EntitiyFramework.Repository.FirstOrDefault");

            return result;
        }
        /// <summary>
        /// Koleksiyondan tüm verileri çekmek için kullanılır.   
        /// Hata alması durumunda null döner.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            List<T> result = null;

            DynamicTryCatch.TryCatchLogla(() =>
            {
                result = context.Set<T>().ToList();
            }, "StokTakibi.DAL.EntitiyFramework.Repository.GetAll");

            return result;
        }
        /// <summary>
        /// Id değerina göre bulunan datayı döner.
        /// Hata alması durumunda null döner.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            T result = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                result = context.Set<T>().Find(id);
            }, "StokTakibi.DAL.EntitiyFramework.Repository.GetById");

            return result;
        }
        /// <summary>
        /// Girilen entityi veritabanından siler.
        /// Hata alması durumunda -1 döner.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Remove(T entity)
        {
            int result = -1;

            DynamicTryCatch.TryCatchLogla(() =>
            {
                context.Set<T>().Remove(entity);
                result = 1;
            }, "StokTakibi.DAL.EntitiyFramework.Repository.Remove");

            return result;
        }
        /// <summary>
        /// Girilen entity dizisini veritabanından siler.
        /// Hata alması durumunda -1 döner.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int RemoveRange(IEnumerable<T> entity)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                context.Set<T>().RemoveRange(entity);
                result = 1;
            }, "StokTakibi.DAL.EntitiyFramework.Repository.Remove");

            return result;
        }
        /// <summary>
        /// Girilen expressiona göre filtre yaparak verileri döner.
        /// OrderBy default null belirtilmiştir. 
        /// Hata alması durumunda null döner.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> result = null;

            DynamicTryCatch.TryCatchLogla(() =>
            {
                result = orderBy == null
                    ? context.Set<T>().Where(expression)
                    : orderBy(context.Set<T>().Where(expression));
            },
                "StokTakibi.DAL.EntitiyFramework.Repository.Remove");
            return result;
        }
        /// <summary>
        /// String tipinde query ve params Object alır.
        /// Transaction içerisinde çalışır. Eğer hata almaz ise 1 alırsa -1 döner.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int InsertWithProcedure(string query, params object[] parameters)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                result = context.Database.ExecuteSqlCommand(query, parameters);
            }, MethodBase.GetCurrentMethod().Name);

            return result;
        }
        /// <summary>
        /// String tipinde query alır ve veritabanında çalıştırır.
        /// </summary>
        /// <param name="query"></param>
        public void SqlQuery(string query)
        {
            DynamicTryCatch.TryCatchLogla(() =>
            {
                context.Database.ExecuteSqlCommand(query);
            }, MethodBase.GetCurrentMethod().Name);
        }
    }
}
