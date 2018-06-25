using SLEntities;
using System;

namespace ConsolePoc
{
    class Program
    {
        static void Main(string[] args)
        {


            User u = new User
            {
                CreateBy = new User { Name = "samir" },
                CreationDate = new DateTime(2018, 6, 25),
                Name = "samir",
                Email = "samir@hotmail.fr",
                Password = "samir",
                Login = "samir",
                Id = 1
            };


            Console.ReadLine();
        }
    }
}
