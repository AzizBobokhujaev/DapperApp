using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperApp.Models;

namespace DapperApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Users> users1 = new List<Users>();
            UserRepsitory userRepsitory = new UserRepsitory();

            users1 = userRepsitory.GetUsers();
            foreach (var item in users1)
            {
                Console.WriteLine($"ID:{item.Id}, FirstName : {item.First_Name}, LastName: {item.Last_Name}, BirthDate: {item.Birth_Date}, CreatedAt: {item.Created_At}");
            }


            Users user = new Users() { First_Name ="aaa",Last_Name="fjif",Middle_Name = "fdfd",Birth_Date = new DateTime(1999,12,04),Created_At = DateTime.Now};
            userRepsitory.Create(user);

            Users user111 = new Users() { First_Name = "aaa", Last_Name = "fjif", Middle_Name = "fdfd", Birth_Date = new DateTime(1999, 12, 04), Created_At = DateTime.Now };
            userRepsitory.Update(user111, 2);

            userRepsitory.Delete(1005);
        }



    }
}
