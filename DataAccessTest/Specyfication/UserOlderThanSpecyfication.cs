using System;
using System.Linq.Expressions;
using DataAccessTest.Model;

namespace DataAccessTest.Specyfication
{
    public class UserOlderThanSpecyfication : Specification<User>
    {
        public UserOlderThanSpecyfication(int age)
            : base(x => x.Birthday.Year < DateTime.Now.Year - age)
        {
        }
    }
}