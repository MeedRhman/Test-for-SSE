using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repostories
{
    public interface IRepostory<TEntity>
    {
        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(int Id);

        TEntity Get(int Id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAllByFilter(Func<TEntity,bool> lambda);

    }
}
