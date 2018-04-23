using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProject
{
    public class Person
    {
        public Person(long id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public long Id { get; set; }

        public string UserName { get; set; }
    }
}
