using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore1.Models.Repository
{
    public class Repository<T> where T : class
    {

        private bool disposed = false;

        private MusicStoreDbContext context;
        protected DbSet<T> DBSet { get; set; }

        public Repository()
        {
            context = new MusicStoreDbContext();
            DBSet = context.Set<T>();
        }

        public Repository(MusicStoreDbContext context)
        {
            this.context = context;
        }
        public List<T> GetAll()
        {
            return DBSet.ToList();
        }

        public T Get(int id)
        {
            return DBSet.Find(id);
        }

        public void Add(T entity)
        {
            DBSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Delete(int i)
        {
            DBSet.Remove(DBSet.Find(i));
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (!disposed)
            {
                context.Dispose();
                disposed = true;
            }
        }
    }
}