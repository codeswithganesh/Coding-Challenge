using CareerHub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Service
{
    internal interface IDatabaseService
    {
        public void InsertJobListing();
        public void InsertCompany();
        public void InsertApplicant();
        public void InsertJobApplication();
        public void GetJobListings();
        public void GetCompanies();
        public void GetApplicants();
        public void GetApplicationsForJob();
        public void GetJobListing();
        public void GetJobListingSalary();


    }
}
