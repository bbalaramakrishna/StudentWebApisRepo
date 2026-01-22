
using Microsoft.Data.SqlClient;
using Dapper;
using StudentInformation.Dto;
using System.Data;
using StudentInformation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace StudentInformation.Logic
{
    public class Studentlogic : studentInterface
    {
        static string connectionstring
      = "data source=(localdb)\\MSSQLLocalDB;Initial Catalog=student;Integrated Security=true;";



        public List<studentdto> studentdetails(int id)

        {
            IDbConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            var dto = conn.Query<studentdto>("select * from studentinformation where Id = @idval", new { idval = id });
            conn.Close();
            return dto.ToList();




        }
        public int UpdateData(int id, string firstName)
        {
            IDbConnection conn = new SqlConnection(connectionstring);
            conn.Open();

            var rows = conn.Execute("Update studentinformation Set Firstname = @fname where id = @id", new { Id = id, fname = firstName });
            conn.Close();

           
            return rows;
        }


        public int DeleteData(int Id)
        {
            IDbConnection conn = new SqlConnection(connectionstring);
            conn.Open();

            int rows = conn.Execute("DELETE FROM studentinformation WHERE id = @Idval",
                new { Idval = Id});
            conn.Close();
            return rows;
        }
        public int InsertData(studentdto dtostudent)
        {
            IDbConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            var rows = conn.Execute("INSERT INTO studentinformation (Firstname, Lastname,id,marks) VALUES (@FirstName, @LastName,@Id,@marks)",
                new { FirstName = dtostudent.Firstname, LastName = dtostudent.Lastname,Id=dtostudent.Id ,marks=dtostudent.Marks 
                });
            conn.Close();
            
            return rows ;
        }








    }

}
