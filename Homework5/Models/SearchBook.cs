using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework5.Models;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Homework5.Models
{
    public class SearchBook
    {

        private static SearchBook instance;
        public String connectionString;

        public static SearchBook getInstance()
        {
            if (instance == null)
            {
                instance = new SearchBook();
            }
            return instance;
        }
        public void setConnectionString(String someConnStr)
        {
            connectionString = someConnStr;
        }
        public List<Books> getAvailableBooks()
        {
            List<Books> data = new List<Books>();

            try
            {
                SqlConnection myConnection = new SqlConnection("Data Source=DESKTOP-IVIJG8H\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True");
                myConnection.Open();
                SqlCommand command = new SqlCommand("Select b.bookId as ID,b.name as Name," + "a.surname as Author,c.name as Type,b.pagecount as PageCount,b.point as Points" +
                    "from [Library].[dbo].[books] as b" +
                    "inner join [Library].[dbo].[authors] as a on b.authorId=a.authorId" +
                    "inner join [Library].[dbo].[types] as c on b.typeId=c.typeId"
                   , myConnection);


                using (SqlDataReader rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Books book = new Books();

                        book.ID = Convert.ToInt32(rdr["ID"]);
                        book.Name = Convert.ToString(rdr["Name"]);
                        book.Author = Convert.ToString(rdr["Author"]);
                        book.Type = Convert.ToString(rdr["Type"]);
                        book.PageCount = Convert.ToInt32(rdr["PageCount"]);
                        book.Points = Convert.ToInt32(rdr["Points"]);
                        data.Add(book);
                    }
                }
                myConnection.Close();
            }
            catch
            {
                
            }
            return data;
        }

        private void BorrowBook()
        {

        }
        private void ReturnBook()
        {

        }
        public List<Students> getStudents()
        {
            List<Students> students = new List<Students>();
            try
            {
                SqlConnection myConnection = new SqlConnection("Data Source=DESKTOP-IVIJG8H\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True");
                myConnection.Open();
                SqlCommand command = new SqlCommand("Select * from [Library].[dbo].[students]", myConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Students stud = new Students();
                        stud.StudentID = Convert.ToInt32(reader["studentId"]);
                        stud.StudentName = Convert.ToString(reader["name"]);
                        stud.StudentSurname = Convert.ToString(reader["surname"]);
                        stud.Class = Convert.ToChar(reader["class"]);
                        stud.Point = Convert.ToInt32(reader["point"]);
                        students.Add(stud);

                    }
                }
                myConnection.Close();
            }
            catch
            {
            }
            return students;


        }
        public List<Borrows> getBorrows()
        {
            List<Borrows> borrows = new List<Borrows>();
            try
            {
                SqlConnection myConnection = new SqlConnection("Data Source=DESKTOP-IVIJG8H\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True");
                myConnection.Open();
                SqlCommand command = new SqlCommand("Select * from [Library].[dbo].[borrows]", myConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Borrows borrows1 = new Borrows();
                        borrows1.BorrowID = Convert.ToInt32(reader["borrowId"]);
                        borrows1.takenDate = Convert.ToDateTime(reader["takenDate"]);
                        borrows1.broughtDate = Convert.ToDateTime(reader["broughtDate"]);
                        borrows.Add(borrows1);
                    }
                }
                myConnection.Close();
            }
            catch
            { 
            }
            return borrows;
        }
    }
}