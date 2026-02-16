using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Student1
{
    //SUMMARY: StudentDAL class is responsible for data access layer operations related to Student entities. It will contain methods for CRUD operations (Create, Read, Update, Delete) and any other database interactions required for managing student data.
    internal class StudentDAL
    {
        
        SqlConnection con=null;
        SqlCommand cmd=null;
        SqlDataReader sdr=null;
        public StudentDAL()
        {
            string conStr = "Data Source= Intial Catalog=LPU_Db;Integrated Security= True";
            con = new SqlConnection();
            con.ConnectionString = "Server=.\\Sqlexpress;Integrated Security=SSPI;Database=LPU_DB;TrustServerCertificate=true";
        }

        public List<Studentt> GetAllStudents()
        {
            List<Studentt> students = new List<Studentt>();

            try
            {
                cmd = new SqlCommand("SELECT * FROM Student", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Studentt obj = new Studentt();
                    obj.Roll_Number = Convert.ToInt32(sdr[0]);
                    obj.Name = sdr[1].ToString();
                    obj.Age = Convert.ToInt32(sdr[2]);
                    obj.City = sdr[3].ToString();
                    students.Add(obj);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (sdr != null && !sdr.IsClosed)
                    sdr.Close();
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return students;
        }
        public Studentt searchByName(string name)
        {
            Studentt student = null;

            try
            {
                cmd = new SqlCommand("SELECT * FROM Student WHERE Name = @Name", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", name);

                con.Open();
                sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    student = new Studentt();
                    student.Roll_Number = Convert.ToInt32(sdr[0]);
                    student.Name = sdr[1].ToString();
                    student.Age = Convert.ToInt32(sdr[2]);
                    student.City = sdr[3].ToString();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (sdr != null && !sdr.IsClosed)
                    sdr.Close();
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return student;
        }

        public Studentt searchById(int id)
        {
            Studentt student = null;

            try
            {
                cmd = new SqlCommand("SELECT * FROM Student WHERE Roll_Number = @RollNumber", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@RollNumber", id);
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    student = new Studentt();
                    student.Roll_Number = Convert.ToInt32(sdr[0]);
                    student.Name = sdr[1].ToString();
                    student.Age = Convert.ToInt32(sdr[2]);
                    student.City = sdr[3].ToString();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (sdr != null && !sdr.IsClosed)
                    sdr.Close();
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return student;
        }

        public bool InsertStudent(Studentt student)
        {
            bool isInserted = false;

            try
            {
                cmd = new SqlCommand("INSERT INTO Student VALUES (@RollNumber, @Name, @Age, @City)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@RollNumber", student.Roll_Number);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@City", student.City);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    isInserted = true;
                    Console.WriteLine("Student inserted successfully!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return isInserted;
        }
    }
}
