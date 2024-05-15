using CareerHub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CareerHub.Repository
{
    internal interface IDatabaseManager
    {
        public int InsertJobListing(JobListing joblisting);
        public int InsertCompany(Company company);
        public int InsertApplicant(Applicant applicant);
        public int InsertJobApplication(JobApplication jobApplication);
        public List<JobListing> GetJobListings();
        public List<Company> GetCompanies();
        public List<Applicant> GetApplicants();
        public List<JobApplication> GetApplicationsForJob(int jobid);
        public List<Object> GetJobListing();
        public List<object> GetJobListingSalary(double salary1, double salary2);
    }
}
