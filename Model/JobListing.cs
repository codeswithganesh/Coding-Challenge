

namespace CareerHub.Model
{
    internal class JobListing
    {
        public int JobID { get; set; }
        public int CompanyID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobLocation { get; set; }
        public double Salary { get; set; }
        public string JobType { get; set; }
        public DateTime PostedDate { get; set; }

        
        public JobListing(int jobId, int companyId, string jobTitle, string jobDescription, string jobLocation, double salary, string jobType, DateTime postedDate)
        {
            JobID = jobId;
            CompanyID = companyId;
            JobTitle = jobTitle;
            JobDescription = jobDescription;
            JobLocation = jobLocation;
            Salary = salary;
            JobType = jobType;
            PostedDate = postedDate;
        }

        public JobListing()
        {
        }

        // ToString() method to represent the object as a string
        public override string ToString()
        {
            return $"JobID: {JobID}, CompanyID: {CompanyID}, JobTitle: {JobTitle}, JobDescription: {JobDescription}, JobLocation: {JobLocation}, Salary: {Salary}, JobType: {JobType}, PostedDate: {PostedDate}";
        }
    }
}
