using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore1.Models.Repository
{
    public class Repository<T> where T : class
    {

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

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}