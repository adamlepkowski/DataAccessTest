using System;
using System.Collections.Generic;
using DataAccessTest.GenericRepositoryByType;
using DataAccessTest.Model;
using DataAccessTest.Specyfication;

namespace DataAccessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create default data 
            InitiallData();

            //run generic repository by typ
            TestGenericRepositoryByType();

        }

        static void TestGenericRepositoryByType()
        {
            //create repository for User entity
            var repository = new GenericRepositoryByType<User>(new DatabaseContext());

            Action<IEnumerable<User>, string> showAllUsers = ((x, message) =>
            {
                Console.WriteLine("\n" + message);
                foreach (var user in x)
                {
                    DisplayUser(user);
                }
            });

            //retrieve all users from Table
            {
                var data = repository.FindAll();
                showAllUsers(data, "All users");
            }

            //execute query by specyfication
            {
                var data = repository.Find(new UserWithActiveAccountSpecyfication());
                showAllUsers(data, "Only Active users - using specyfication");
            }

            //execute query by specyfication with paramter
            {
                var data = repository.Find(new UserOlderThanSpecyfication(18));
                showAllUsers(data, "Only adult users");
            }
        }

        static void DisplayUser(User user)
        {
            Console.WriteLine("{0} {1} {2} {3}", user.UserId, user.FirstName, user.Birthday, user.IsActive);
        }

        static void InitiallData()
        {
            using (var context = new DatabaseContext())
            {
                //remove entire content of table
                var objCtx = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)context).ObjectContext;
                objCtx.ExecuteStoreCommand("DELETE FROM [Users]");

                context.SaveChanges();

                context.Users.Add(new User()
                {
                    FirstName = "Adam",
                    Birthday = DateTime.Now.AddYears(-26),
                    IsActive = true
                });

                context.Users.Add(new User()
                {
                    FirstName = "Kuba",
                    Birthday = DateTime.Now.AddYears(-16),
                    IsActive = true
                });

                context.Users.Add(new User()
                {
                    FirstName = "Marcin",
                    Birthday = DateTime.Now.AddYears(-10),
                    IsActive = false
                });

                context.Users.Add(new User()
                {
                    FirstName = "Darek",
                    Birthday = DateTime.Now.AddYears(-33),
                    IsActive = true
                });

                context.SaveChanges();
            }
        }
    }
}