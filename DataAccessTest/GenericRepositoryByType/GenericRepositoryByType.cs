using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccessTest.Specyfication;

namespace DataAccessTest.GenericRepositoryByType
{
    public class GenericRepositoryByType<TEntity> : IGenericRepositoryByType<TEntity> where TEntity : class, new()
    {
        private readonly DatabaseContext _databaseContext;

        public GenericRepositoryByType(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<TEntity> FindAll()
        {
            return _databaseContext.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _databaseContext.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity FindById(int id)
        {
            return _databaseContext.Set<TEntity>().Find(id);
        }

        public void Add(TEntity newEntity)
        {
            _databaseContext.Set<TEntity>().Add(newEntity);
        }

        public void Update(TEntity entity)
        {
            _databaseContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            _databaseContext.Set<TEntity>().Remove(entity);
        }

        public void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _databaseContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity Single(ISpecification<TEntity> criteria)
        {
            return _databaseContext.Set<TEntity>().Single<TEntity>(criteria.IsSatisfiedBy);
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> criteria)
        {
            return _databaseContext.Set<TEntity>().Where<TEntity>(criteria.IsSatisfiedBy);
        }
    }
}