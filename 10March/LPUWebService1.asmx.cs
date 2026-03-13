using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _10March
{
    /// <summary>
    /// Summary description for LPUWebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LPUWebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string Greeting()
        {
            return "Suno ji , Kese ho";
        }

        // Get connection string from Web.config
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        [WebMethod]
        public DataSet GetAllRecords(string tableName)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    string query = $"SELECT * FROM {tableName}";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching records: " + ex.Message);
            }
            return ds;
        }

        [WebMethod]
        public DataSet ExecuteQuery(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing query: " + ex.Message);
            }
            return ds;
        }

        [WebMethod]
        public int ExecuteNonQuery(string query)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing command: " + ex.Message);
            }
            return rowsAffected;
        }

        [WebMethod]
        public string GetStudentById(int studentId)
        {
            string result = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = "SELECT * FROM Students WHERE StudentId = @StudentId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = $"ID: {reader["StudentId"]}, Name: {reader["StudentName"]}";
                    }
                    else
                    {
                        result = "Student not found";
                    }
                }
            }
            catch (Exception ex)
            {
                result = "Error: " + ex.Message;
            }
            return result;
        }
    }
}
