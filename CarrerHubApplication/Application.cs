using CareerHub.Service;

namespace CareerHub.CarrerHubApplication
{
    internal class Application
    {
        DataBaseService ds=new DataBaseService();
        MethodService ms=new MethodService();
        public void Run()
        {
            bool flag = true;
            while (flag)
            {

                bool flag1 = true;
                Console.WriteLine("----------------------------Welcome to the CarrerHub Menu-----------------------:)");
                Console.WriteLine("CarrerHub is a digital platform or system that facilitates the process of job searching and recruitment");
                Console.WriteLine("1.JobListingInterface\n2.CompanyInterface\n3.ApplicantInterface\n4.DataBaseManagerInterface\n5.DatabaseTasks\n6.Exit");
                Console.WriteLine("Choose any One Option");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:

                        while (flag1)
                        {
                            Console.WriteLine("Welcome to the JobListing Interface");
                            Console.WriteLine("1.ApplyJob\n2.GetApplicants\n3.Back to MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    ms.Apply();
                                    break;

                                case 2:
                                    ds.GetApplicants();
                                    break;
                               
                                case 3:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;

                    case 2:
                        while (flag1)
                        {
                            Console.WriteLine("Welcome to the Company Interface");
                            Console.WriteLine("1.PostJobs\n2.GetJobs\n3.back to MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    ms.PostJob();
                                    break;

                                case 2:
                                    ds.GetJobListings();
                                    break;
                                
                                case 3:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        while (flag1)
                        {
                            Console.WriteLine("Welcome to the Applicant Interface");
                            Console.WriteLine("1.CreateProfile\n2.ApplyJobs\n3.back to MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    ds.InsertApplicant();
                                    break;

                                case 2:
                                    ms.Apply();
                                    break;
                               
                                case 3:
                                    flag1 = false;
                                    break;

                               
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;

                    case 4:
                        while (flag1)
                        {
                            Console.WriteLine("Welcome to the DataBase Manager Interface");
                            Console.WriteLine("1.InsertJobListing\n2.InsertCompany\n3.InsertApplicant\n4.InsertJobApplication\n5.GetJobListing\n6.GetCompanies\n7.GetApplicants\n8.GetApplicationsForJobId\n9.BackToMainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    ds.InsertJobListing();
                                    break;

                                case 2:
                                    ds.InsertCompany();
                                    break;
                                case 3:
                                    ds.InsertApplicant();
                                    break;
                                case 4:
                                    ds.InsertJobApplication();
                                    break;
                                case 5:
                                    ds.GetJobListings();
                                    break;
                                case 6:
                                    ds.GetCompanies();
                                    break;
                                case 7:
                                    ds.GetApplicants();
                                    break;
                                case 8:
                                    ds.GetApplicationsForJob();
                                    break;

                                case 9:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;
                    case 5:
                        while (flag1)
                        {
                            Console.WriteLine("Welcome to the DataBase Tasks");
                            Console.WriteLine(@"1.JobListing Retreval\n2.Applicant Profile Creation \n3.Job Application Submission \n4.Company Job Posting
                                \n5.Salary Range Query\n6.Back to Main Menu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    ds.GetJobListing();
                                    break;

                                case 2:
                                    ds.InsertApplicant();
                                    break;
                                case 3:
                                    ds.InsertJobApplication();
                                    break;
                                case 4:
                                    ms.PostJob();
                                    break;

                                case 5:
                                    ds.GetJobListingSalary();
                                    break;
                                
                                case 6:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;


                    case 6:
                        Console.WriteLine("!!!!:) Thank You Visit Agian :}!!!!");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Enter the Appropriate option");
                        break;


                }

            }

        }
    }
}
