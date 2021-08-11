namespace E_Store.Data.Interfaces.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    using Data;

    using Microsoft.Extensions.Configuration;
    using Microsoft.EntityFrameworkCore;
    

    public abstract class BaseRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        protected readonly DbContext context;
        protected DbSet<TEntity> dbSet;

        public BaseRepository()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            context = new EStoreDbContext(new DbContextOptionsBuilder<EStoreDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .Options);

            dbSet = context.Set<TEntity>();
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