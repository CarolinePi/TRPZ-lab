using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly DataDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DataDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public TEntity GetById(int entityId)
        {
            return _dbSet.Find(entityId);
        }

        public void DeleteById(int entityId)
        {
            var tEntity = _dbSet.Find(entityId);

            if (tEntity != null)
            {
                _dbSet.Remove(tEntity);
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
