﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Model
{
    internal class Applicant
    {
        public int ApplicantID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Resume { get; set; }

        public Applicant(int applicantId, string firstName, string lastName, string email, string phone, string resume)
        {
            ApplicantID = applicantId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Resume = resume;
        }

        public Applicant()
        {
        }

        public override string ToString()
        {
            return $"ApplicantID: {ApplicantID}, Name: {FirstName} {LastName}, Email: {Email}, Phone: {Phone}, Resume: {Resume}";
        }
    }
}
