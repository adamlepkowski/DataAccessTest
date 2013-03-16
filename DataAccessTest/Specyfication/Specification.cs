using System;
using System.Linq.Expressions;

namespace DataAccessTest.Specyfication
{
    public class Specification<TEntity> : ISpecification<TEntity>
    {
        private readonly Expression<Func<TEntity, bool>> _predicate;

        protected Specification(Expression<Func<TEntity, bool>> predicate)
        {
            _predicate = predicate;
        }

        public bool IsSatisfiedBy(TEntity entity)
        {
            return _predicate.Compile().Invoke(entity);
        }
    }
}