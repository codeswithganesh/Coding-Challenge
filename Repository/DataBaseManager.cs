using CareerHub.Exceptions;
using CareerHub.Model;
using CareerHub.Util;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerHub.Repository
{
    internal class DataBaseManager : IDatabaseManager
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public DataBaseManager()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public List<Applicant> GetApplicants()
        {
            try
            {
                List<Applicant> lapplicant = new List<Applicant>();
                cmd.CommandText = "select * from Applicants ";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Applicant app = new Applicant();
                    app.ApplicantID = (int)reader["ApplicantId"];
                    app.FirstName = (string)reader["FirstName"];
                    app.LastName = (string)reader["LastName"];
                    app.Email = (string)reader["Email"];
                    app.Phone = (string)reader["Phone"];
                    app.Resume = (string)reader["Resume"];

                    lapplicant.Add(app);
                }
                return lapplicant;


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

        public List<JobApplication> GetApplicationsForJob(int jobid)
        {
            try
            {
                List<JobApplication> lapplication = new List<JobApplication>();
                cmd.CommandText = "select * from Applications where ApplicationId=@id";
                cmd.Parameters.AddWithValue("@id", jobid);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobApplication jobApplication = new JobApplication();
                    jobApplication.JobID = (int)reader["JobId"];
                    jobApplication.ApplicantID = (int)reader["ApplicantId"];
                    jobApplication.ApplicationDate = (DateTime)reader["ApplicationDate"];
                    jobApplication.CoverLetter = (string)reader["CoverLetter"];
                    lapplication.Add(jobApplication);

                }
                return lapplication;
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

        public List<Company> GetCompanies()
        {
            try
            {
                List<Company> lcompanies = new List<Company>();
                cmd.CommandText = "select * from Companies ";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Company c = new Company();
                    c.CompanyID = (int)reader["CompanyId"];
                    c.CompanyName = (string)reader["CompanyName"];
                    c.Location = (string)reader["location"];
                    lcompanies.Add(c);

                }
                return lcompanies;

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

        public List<JobListing> GetJobListings()
        {
            try
            {
                List<JobListing> ljobs = new List<JobListing>();
                cmd.CommandText = "select * from Jobs ";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobListing jlist = new JobListing();
                    jlist.JobID = (int)reader["JobId"];
                    jlist.CompanyID = (int)reader["CompanyId"];
                    jlist.JobTitle = (string)reader["JobTitle"];
                    jlist.JobDescription = (string)reader["JobDescrption"];
                    jlist.JobLocation = (string)reader["JobLocation"];
                    jlist.JobType = (String)reader["JobType"];
                    jlist.PostedDate = (DateTime)reader["PostedDate"];
                    ljobs.Add(jlist);

                }
                return ljobs;

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

        public int InsertApplicant(Applicant applicant)
        {
            try
            {
                cmd.CommandText = @"insert into Applicants values(@firstname,@lastname,@email,@phone,@resume)"; ;

                cmd.Parameters.AddWithValue("@firstname", applicant.FirstName);
                cmd.Parameters.AddWithValue("@lastname", applicant.LastName);
                cmd.Parameters.AddWithValue("@email", applicant.Email);
                cmd.Parameters.AddWithValue("@phone", applicant.Phone);
                cmd.Parameters.AddWithValue("@resume", applicant.Resume);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();
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

        public int InsertCompany(Company company)
        {
            try
            {
                cmd.CommandText = "Insert into Companies values(@companyname,@location)";
                cmd.Parameters.AddWithValue("@companyname", company.CompanyName);
                cmd.Parameters.AddWithValue("@location", company.Location);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();
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

        public int InsertJobApplication(JobApplication jobApplication)
        {
            try
            {
                cmd.CommandText = "Insert into Applications values(@jobid,@applicantid,@adate,@coverletter)";
                cmd.Parameters.AddWithValue("@jobid", jobApplication.JobID);
                cmd.Parameters.AddWithValue("@applicantid", jobApplication.ApplicantID);
                cmd.Parameters.AddWithValue("@adate", jobApplication.ApplicationDate);
                cmd.Parameters.AddWithValue("@coverletter", jobApplication.CoverLetter);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();
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

        public int InsertJobListing(JobListing joblisting)
        {
            try
            {
                cmd.CommandText = "insert into Jobs values(@companyid,@jobtitle,@jobdesc,@jobloc,@salary,@jobtype,@posteddate)";
                cmd.Parameters.AddWithValue("@companyid", joblisting.CompanyID);
                cmd.Parameters.AddWithValue("@jobtitle", joblisting.JobTitle);
                cmd.Parameters.AddWithValue("@jobdesc", joblisting.JobDescription);
                cmd.Parameters.AddWithValue("@jobloc", joblisting.JobLocation);
                cmd.Parameters.AddWithValue("@salary", joblisting.Salary);
                cmd.Parameters.AddWithValue("@jobtype", joblisting.JobType);
                cmd.Parameters.AddWithValue("@posteddate", joblisting.PostedDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();
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
        public List<object> GetJobListing()
        {
            try
            {
                List<object> list = new List<object>();
                cmd.CommandText = "select JobTitle,CompanyName,Salary from Jobs join Companies on Jobs.CompanyId=Companies.CompanyId ";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    string jobTitle = (string)reader["JobTitle"];
                    string companyName = (string)reader["CompanyName"];
                    double salary = (double)(decimal)reader["Salary"];


                    list.Add(new { JobTitle = jobTitle, CompanyName = companyName, Salary = salary });
                }
                return list;
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

        public List<object> GetJobListingSalary(double salary1, double salary2)
        {
            try
            {
                List<object> list = new List<object>();
                cmd.CommandText = "select JobTitle,CompanyName,Salary from Jobs join Companies on Jobs.CompanyId=Companies.CompanyId where salary between @sal1 and @sal2 ";
                cmd.Parameters.AddWithValue("@sal1", salary1);
                cmd.Parameters.AddWithValue("@sal2", salary2);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    string jobTitle = (string)reader["JobTitle"];
                    string companyName = (string)reader["CompanyName"];
                    double salary = (double)(decimal)reader["Salary"];


                    list.Add(new { JobTitle = jobTitle, CompanyName = companyName, Salary = salary });
                }
                return list;
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
    }

   
}
