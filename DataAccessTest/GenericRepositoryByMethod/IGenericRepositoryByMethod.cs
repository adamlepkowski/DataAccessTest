using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccessTest.Specyfication;

namespace DataAccessTest.GenericRepositoryByMethod
{
    //NOTE: This repository can be easly extended
    public interface IGenericRepositoryByMethod : IDisposable
    {
        IEnumerable<TEntity> FindAll<TEntity>() where TEntity : class;
        IEnumerable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity FindById<TEntity>(int id) where TEntity : class;
        void Add<TEntity>(TEntity newEntity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        void SaveChanges();
        TEntity FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity Single<TEntity>(ISpecification<TEntity> criteria) where TEntity : class;
        IEnumerable<TEntity> Find<TEntity>(ISpecification<TEntity> criteria) where TEntity : class;
    }
}