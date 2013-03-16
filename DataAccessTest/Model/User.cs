using System;

namespace DataAccessTest.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsActive { get; set; }
    }
}