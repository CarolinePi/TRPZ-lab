using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int entityId);
        void DeleteById(int entityId);
        IEnumerable<TEntity> GetAll();
    }
}
