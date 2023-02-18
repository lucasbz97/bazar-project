using Dev.Business.Interfaces;
using Dev.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Data.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Dev.Business.Models.Entity, new()
    {
        protected readonly EfContext Db;
        protected readonly DbSet<TEntity> DbSet;


        protected RepositoryBase(EfContext db)
        {
            Db = db;
            DbSet = db.Set < TEntity >();
        }
        public  virtual async System.Threading.Tasks.Task Add(TEntity model)
        {
            DbSet.Add(model);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Delete(TEntity model)
        {
            DbSet.Remove(model);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges(); ;
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public virtual async Task<TEntity> GeById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GeById(string id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GeById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity model)
        {
            DbSet.Update(model);
            await SaveChanges();
        }
    }
}
