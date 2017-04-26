using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataModel.GenericType
{
    public class GenericType<TEntity> where TEntity : class
    {
        /// <summary>
        /// Chứa tất cả các hàm dùng chung cho các thực thể (CRUD ...)
        /// </summary>
        // private member variables
        internal SurveyEntities Context;
        internal DbSet<TEntity> Dbset;

        //contructor
        public GenericType(SurveyEntities context)
        {
            Context = context;
            Dbset = context.Set<TEntity>();
        }
        // member method
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        public virtual IList<TEntity> Get()
        {
            IQueryable<TEntity> query = Dbset;
            return query.ToList();
        }
        /// <summary>
        /// Lấy dữ lieuj theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        /// 
        /// 
        /// 
        public virtual TEntity GetByID(object id)
        {
            return Dbset.Find(id);
        }
        /// <summary>
        /// thêm dữ liệu
        /// </summary>
        /// <param name="enity"></param>
        public virtual void Insert(TEntity enity)
        {
            Dbset.Add(enity);
        }
        /// <summary>
        /// Xóa bản ghiby id
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = Dbset.Find(id);
            Delete(entityToDelete);
        }
        /// <summary>
        /// xóa dữ liệu theo 1 đối tượng
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                Dbset.Attach(entityToDelete);
            }
            Dbset.Remove(entityToDelete);
        }
        /// <summary>
        /// generic delete method , deletes data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public void Delete(Func<TEntity, Boolean> where)
        {
            IQueryable<TEntity> objects = Dbset.Where<TEntity>(where).AsQueryable();
            foreach (TEntity obj in objects)
                Dbset.Remove(obj);
        }

        /// <summary>
        /// cập nhật bản ghi
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            Dbset.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        /// <summary>
        /// lấy dữ liệu theo điều kiện
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IList<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return Dbset.Where(where).ToList();
        }
        /// <summary>
        /// lấy 1 bản ghi theo điều kiện
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public TEntity Get(Func<TEntity, Boolean> where)
        {
            return Dbset.Where(where).FirstOrDefault<TEntity>();
        }
        /// <summary>
        /// lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        public virtual IList<TEntity> GetAll()
        {
            return Dbset.ToList();
        }
        /// <summary>
        /// kiểm tra tồn tại
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public bool Exists(object primaryKey)
        {
            return Dbset.Find(primaryKey) != null;
        }
    }
}
