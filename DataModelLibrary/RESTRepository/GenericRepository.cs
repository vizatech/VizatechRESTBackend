#region Задаем пространство имен

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using DataModelLibrary;

#endregion

namespace DataModelLibrary.RESTRepository
{
    /// <summary>
    /// Создаем класс для операций над сущностями коллекций данных 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> where TEntity : class
    {
        #region Создаем закрытую коллекцию нашего контекста данных
        internal WebAPIDataModel Context;
        internal DbSet<TEntity> DbSet;
        #endregion

        #region Создаем открытый коннектор конструктора коллекции для нашего контекста данных 
        /// <summary>
        /// Открытый конструктор, инициализирующий коллекцию данных
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(WebAPIDataModel context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }
        #endregion

        #region Открытые методы конструктора коллекции данных

        /// <summary>
        /// Метод GET ALL, возвращающий все записи коллекции в виде очереди
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = DbSet;
            return query.ToList();
        }

        /// <summary>
        /// Метод GET, возвращает запись по ее ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Метод POST, добавляет новую запись
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// Метод DELETE, удаляет запись по ее ID
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Метод DELETE ALL удаляет все записи коллекции
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Метод PUT, вносит изменения в выбранную запись
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// Метод GET, возвращающий полный список записей, отвечающих условию WHERE
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).ToList();
        }

        /// <summary>
        /// Метод GET, возвращающий записи, отвечающие условию WHERE - в виде очереди
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).AsQueryable();
        }

        /// <summary>
        /// Метод GET, возвращающий запись согласно условия WHERE - первое значение
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public TEntity Get(Func<TEntity, Boolean> where)
        {
            return DbSet.Where(where).FirstOrDefault<TEntity>();
        }

        /// <summary>
        /// Метод DELETE, удаляющий записи согласно условия WHERE
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public void Delete(Func<TEntity, Boolean> where)
        {
            IQueryable<TEntity> objects = DbSet.Where<TEntity>(where).AsQueryable();
            foreach (TEntity obj in objects)
                DbSet.Remove(obj);
        }

        /// <summary>
        /// Метод GET ALL - возвращает все записи коллекции
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        /// <summary>
        /// Метод GET, возвращающий коллекцию записей, отвечающих признаку, вместе с присоединенными коллекциями
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetWithInclude(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = this.DbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        /// <summary>
        /// Метод GET, возвращающий факт существования записи с заданным ID
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public bool Exists(object primaryKey)
        {
            return DbSet.Find(primaryKey) != null;
        }

        /// <summary>
        /// Метод GET, возвращающий запись по уникальному признаку
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return DbSet.Single<TEntity>(predicate);
        }

        /// <summary>
        /// Метод GET, возвращающий первое значение записи, удовлетворяющее признаку
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return DbSet.First<TEntity>(predicate);
        }


        #endregion
    }
}