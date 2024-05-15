using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Model
{
    internal class JobApplication
    {
        public int ApplicationID { get; set; }
        public int JobID { get; set; }
        public int ApplicantID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string CoverLetter { get; set; }

        public JobApplication(int applicationId, int jobId, int applicantId, DateTime applicationDate, string coverLetter)
        {
            ApplicationID = applicationId;
            JobID = jobId;
            ApplicantID = applicantId;
            ApplicationDate = applicationDate;
            CoverLetter = coverLetter;
        }

        public JobApplication()
        {
        }

        public override string ToString()
        {
            return $"ApplicationID: {ApplicationID}, JobID: {JobID}, ApplicantID: {ApplicantID}, ApplicationDate: {ApplicationDate}, CoverLetter: {CoverLetter}";
        }
    }
}
