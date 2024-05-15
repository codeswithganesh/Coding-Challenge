using CareerHub.Exceptions;
using CareerHub.Model;
using CareerHub.Util;
using System.Data.SqlClient;

namespace CareerHub.Repository
{
    
    
    internal class AllMethodimplementation : IAllMethodImplementation
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public AllMethodimplementation()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public int Apply(int applicantid, int jobid, string coverLetter)
        {
            try
            {
                cmd.CommandText = "Insert into Applications values(@jobid,@applicantid,@adate,@coverletter)";
                cmd.Parameters.AddWithValue("@jobid", jobid);
                cmd.Parameters.AddWithValue("@applicantid", applicantid);
                cmd.Parameters.AddWithValue("@adate", DateTime.Now);
                cmd.Parameters.AddWithValue("@coverletter", coverLetter);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();

                return result;

            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Database connection error: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();

            }


        }

        public int PostJob(int companyid,string jobTitle, string jobDescription, string jobLocation, double salary, string jobType)
        {
            try
            {
                cmd.CommandText = "insert into Jobs values(@companyid,@jobtitle,@jobdesc,@jobloc,@salary,@jobtype,@posteddate)";
                cmd.Parameters.AddWithValue("@companyid", companyid);
                cmd.Parameters.AddWithValue("@jobtitle", jobTitle);
                cmd.Parameters.AddWithValue("@jobdesc", jobDescription);
                cmd.Parameters.AddWithValue("@jobloc", jobLocation);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@jobtype", jobType);
                cmd.Parameters.AddWithValue("@posteddate", DateTime.Now);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();

                return result;

            }
            
            catch(SqlException ex)
            {
                throw new DatabaseConnectionException("Database connection error: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();

            }
        }


        public List<Double> GetSalary()
        {
            List<Double> salary = new List<Double>();
            cmd.CommandText = "Select Salary from Jobs;";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                salary.Add((double)reader["Salary"]);

            }
            return salary;
        }
    }
}
