using CareerHub.Exceptions;
using CareerHub.Model;
using CareerHub.Repository;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Service
{
    internal class DataBaseService : IDatabaseService
    {
        readonly IDatabaseManager _databaseManager;
        public DataBaseService()
        {
            _databaseManager=new DataBaseManager();
        }
        public void GetApplicants()
        {
            List<Applicant> list = new List<Applicant>();
            list = _databaseManager.GetApplicants();
            foreach (Applicant item in list)
            {
                Console.WriteLine(item);
            }

        }

        public void GetApplicationsForJob()
        {
            Console.WriteLine("Enter the JobId");
            int id=int.Parse(Console.ReadLine());
            List<JobApplication> list = new List<JobApplication>();
            list = _databaseManager.GetApplicationsForJob(id);
            foreach (JobApplication item in list)
            {
                Console.WriteLine(item);
            }
        }

        public void GetCompanies()
        {
            List<Company> list = new List<Company>();
            list = _databaseManager.GetCompanies();
            foreach (Company item in list)
            {
                Console.WriteLine(item);
            }
        }

        public void GetJobListings()
        {
            List<JobListing> list = new List<JobListing>();
            list = _databaseManager.GetJobListings();
            foreach(JobListing item in list)
            {
                Console.WriteLine(item);
            }
        }

        public void InsertApplicant()
        {
            try
            {
                Applicant applicant = new Applicant();
                Console.WriteLine("Enter the Firstname");
                applicant.FirstName = Console.ReadLine();
                Console.WriteLine("Enter the Lastname");
                applicant.LastName = Console.ReadLine();
                Console.WriteLine("Enter the Email");
                string email = Console.ReadLine();
                if (IsValidEmail(email))
                {
                    throw new InvalidEmailFormatException("Invalid email format. Please enter a valid email address.");
                }

                applicant.Email = email;
                Console.WriteLine("Enter the Phone");
                applicant.Phone = Console.ReadLine();
                Console.WriteLine("Enter the Resume");
                applicant.Resume = Console.ReadLine();
                int result = _databaseManager.InsertApplicant(applicant);

                if (result > 0)
                {
                    Console.WriteLine("Insert Applicant sucessfull");
                }
                else
                {
                    Console.WriteLine("Insert Applicant Not Sucessfull please try after some time");
                }

            }
            catch(InvalidEmailFormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public  bool IsValidEmail(string email)
        {
            return email.Contains("@");

        }

        public void InsertCompany()
        {
            Company company = new Company();
            Console.WriteLine("Enter the CompanyName");
            company.CompanyName = Console.ReadLine();
            Console.WriteLine("Enter the Location");
            company.Location = Console.ReadLine();
            int result=_databaseManager.InsertCompany(company);
            if (result > 0)
            {
                Console.WriteLine("Insert company sucessfull");
            }
            else
            {
                Console.WriteLine("Insert company Not Sucessfull please try after some time");
            }


        }

        public void InsertJobApplication()
        {
            try
            {
                JobApplication app = new JobApplication();
                Console.WriteLine("Enter the JobId");
                app.JobID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the ApplicantId");
                app.ApplicantID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Application Date");
                DateTime applicationDate = DateTime.Parse(Console.ReadLine());
                if (applicationDate > DateTime.Now)
                {
                    throw new ApplicationDeadlineException("Application deadline has passed. Application submission is no longer accepted.");
                }

                app.ApplicationDate = applicationDate;
                Console.WriteLine("Enter the CoverLetter");
                app.CoverLetter = Console.ReadLine();
                int result = _databaseManager.InsertJobApplication(app);
                if (result > 0)
                {
                    Console.WriteLine("Insert Applicantion sucessfull");
                }
                else
                {
                    Console.WriteLine("Insert Applicantion Not Sucessfull please try after some time");
                }

            }
            catch(ApplicationDeadlineException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            


        }

        public void InsertJobListing()
        {
            JobListing app = new JobListing();
            Console.WriteLine("Enter the ComapanyID");
            app.CompanyID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the job Title");
            app.JobTitle = Console.ReadLine();
            Console.WriteLine("Enter the job Descrption");
            app.JobDescription = Console.ReadLine();
            Console.WriteLine("Enter the job Location");
            app.JobLocation = Console.ReadLine();
            Console.WriteLine("Enter the Salary");
            app.Salary = double.Parse(Console.ReadLine());
            app.JobLocation = Console.ReadLine();
            Console.WriteLine("Enter the job Type");
            app.JobType = Console.ReadLine();
            Console.WriteLine("Enter the PostedDate");
            app.PostedDate = DateTime.Parse(Console.ReadLine());
            int result=_databaseManager.InsertJobListing(app);
            if (result > 0)
            {
                Console.WriteLine("Insert JobListing sucessfull");
            }
            else
            {
                Console.WriteLine("Insert JobListing Not Sucessfull please try after some time");
            }


        }

        public void GetJobListing()
        {
            List<object> jobs=new List<object>();
            jobs = _databaseManager.GetJobListing();
            foreach (object item in jobs)
            {
                Console.WriteLine(item);
            }
        }

        public void GetJobListingSalary()
        {
            Console.WriteLine("Enter the salary 1");
            double sal1=double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the salary 2");
            double sal2 = double.Parse(Console.ReadLine());

            List<object> jobs = new List<object>();
            jobs = _databaseManager.GetJobListingSalary(sal1,sal2);
            foreach (object item in jobs)
            {
                Console.WriteLine(item);
            }

        }
    }
}
