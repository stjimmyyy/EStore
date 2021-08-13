namespace E_Store.Data.Interfaces.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    using Data;
    using Microsoft.EntityFrameworkCore;
    
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly EStoreDbContext context;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(EStoreDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<TEntity>();
        }
        
        public List<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public TEntity FindById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (dbSet.Contains(entity))
            {
                dbSet.Update(entity);
            }
            else
            {
                dbSet.Add(entity);
            }

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity entity = dbSet.Find(id);

            try
            {
                dbSet.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                context.Entry(entity).State = EntityState.Unchanged;
                throw;
            }
        }
    }
}