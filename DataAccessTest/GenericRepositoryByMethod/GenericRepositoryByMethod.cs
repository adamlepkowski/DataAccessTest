using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccessTest.Specyfication;

namespace DataAccessTest.GenericRepositoryByMethod
{
    public class GenericRepositoryByMethod : IGenericRepositoryByMethod
    {
        private readonly DatabaseContext _databaseContext;

        public GenericRepositoryByMethod(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<TEntity> FindAll<TEntity>() where TEntity : class
        {
            return _databaseContext.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _databaseContext.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity FindById<TEntity>(int id) where TEntity : class
        {
            return _databaseContext.Set<TEntity>().Find(id);
        }

        public void Add<TEntity>(TEntity newEntity) where TEntity : class
        {
            _databaseContext.Set<TEntity>().Add(newEntity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _databaseContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            _databaseContext.Set<TEntity>().Remove(entity);
        }

        public void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }

        public TEntity FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _databaseContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity Single<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
        {
            return _databaseContext.Set<TEntity>().Single<TEntity>(criteria.IsSatisfiedBy);
        }

        public IEnumerable<TEntity> Find<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
        {
            return _databaseContext.Set<TEntity>().Where<TEntity>(criteria.IsSatisfiedBy);
        }

        public void Dispose()
        {
            if (_databaseContext != null)
            {
                _databaseContext.Dispose();
            }
        }
    }
}