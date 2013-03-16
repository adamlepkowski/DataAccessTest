using System;
using System.Linq.Expressions;
using DataAccessTest.Model;

namespace DataAccessTest.Specyfication
{
    public class UserWithActiveAccountSpecyfication : Specification<User>
    {
        public UserWithActiveAccountSpecyfication()
            : base(x => x.IsActive == true)
        {
        }
    }
}