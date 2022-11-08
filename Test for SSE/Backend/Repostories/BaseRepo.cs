using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repostories
{
    public class BaseRepo<TEntity, IDbContext> : IRepostory<TEntity>
        where TEntity : class
        where IDbContext : DbContext
    {
        private readonly IDbContext dbcontext;

        public BaseRepo(IDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public TEntity Add(TEntity entity)
        {
            dbcontext.Set<TEntity>().Add(entity);

            dbcontext.SaveChanges();
            return entity;
        }

        public TEntity Delete(int Id)
        {
            var entity = Get(Id);
            if (entity == null)
                return entity;
            dbcontext.Set<TEntity>().Remove(entity);
            dbcontext.SaveChanges();

            return entity;


        }

        public TEntity Get(int Id)
        {
            return dbcontext.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbcontext.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllByFilter(Func<TEntity, bool> lambda)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            dbcontext.Entry<TEntity>(entity).State = EntityState.Modified;
            dbcontext.SaveChanges();
            return entity;
        }
    }
}
