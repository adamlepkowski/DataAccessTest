using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccessTest.Specyfication;

namespace DataAccessTest.GenericRepositoryByType
{
    //NOTE: This repository can be easly extended
    public interface IGenericRepositoryByType<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        TEntity FindById(int id);
        void Add(TEntity newEntity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void SaveChanges();
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Single(ISpecification<TEntity> criteria);
        IEnumerable<TEntity> Find(ISpecification<TEntity> criteria);
    }
}