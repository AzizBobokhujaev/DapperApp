using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperApp.Models
{
    class UserRepsitory
    {
        public List<Users> GetUsers()
        {
            string connectionString = @"Data source = WIN-HFC12JL6G7P\SQLEXPRESS; Initial catalog = Users; Integrated security = true";

            List<Users> users = new List<Users>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                users =  db.Query<Users>("SELECT * FROM USERS").ToList();
            }
            return users;
        }
        public Users Create(Users user)
        {
            string connectionString = @"Data source = WIN-HFC12JL6G7P\SQLEXPRESS; Initial catalog = Users; Integrated security = true";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = $"INSERT INTO USERS (FIRST_NAME, LAST_NAME, MIDDLE_NAME, BIRTH_DATE, CREATED_AT) VALUES " +
                    $"(@First_Name, @Last_Name,@Middle_Name, @Birth_Date, @Created_At); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                user.Id = (int)userId;
            }
            return user;
        }

        public void Update(Users users,int id)
        {
            string connectionString = @"Data source = WIN-HFC12JL6G7P\SQLEXPRESS; Initial catalog = Users; Integrated security = true";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE USERS SET FIRST_NAME = @First_Name, " +
                    "LAST_NAME = @Last_name, " +
                    "MIDDLE_NAME =@Middle_Name," +
                    "BIRTH_DATE=@Birth_Date," +
                    $"CREATED_AT=@Created_At WHERE ID={id}";
                db.Execute(sqlQuery, users);

            }
            
        }

        public async void Delete(int id) 
        {
            string connectionString = @"Data source = WIN-HFC12JL6G7P\SQLEXPRESS; Initial catalog = Users; Integrated security = true";

            using (IDbConnection db = new SqlConnection(connectionString)) 
            { 
                var sqlQuery = "DELETE FROM Users WHERE Id = @id"; 
                await db.ExecuteAsync(sqlQuery, new { id }); 
            } 
        }
    }
}
