

using CareerHub.Model;
using System.Data;
using System.Data.SqlClient;

namespace CareerHub.Repository
{
    internal interface IAllMethodImplementation 
    {
        
        
        public int Apply(int applicantid, int jobid, string coverLetter);
        public int PostJob(int companyid,string jobTitle, string jobDescription, string jobLocation, double salary, string jobType);
        public List<Double> GetSalary();
    }
}
