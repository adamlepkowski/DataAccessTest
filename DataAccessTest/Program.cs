

using System;
using DataAccessTest.Model;

namespace DataAccessTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Create default data 
            InitiallData();
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
                    Birthday = DateTime.Now.AddYears(-17),
                    IsActive = true
                });

                context.Users.Add(new User()
                {
                    FirstName = "Marcin",
                    Birthday = DateTime.Now.AddYears(-13),
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