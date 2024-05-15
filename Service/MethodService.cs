using CareerHub.Repository;

namespace CareerHub.Service
{
    internal class MethodService : IMethodsService
    {
        readonly IAllMethodImplementation _iallMethodImplementation;
        public MethodService()
        {
            _iallMethodImplementation=new AllMethodimplementation();
        }
        public void Apply()
        {
            
            Console.WriteLine("Enter the JobId");
            int JobID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the ApplicantId");
            int ApplicantID = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Enter the CoverLetter");
             string CoverLetter = Console.ReadLine();
            int result = _iallMethodImplementation.Apply(ApplicantID,JobID,CoverLetter);
            if (result > 0)
            {
                Console.WriteLine("Job Applied  sucessfully");
            }
            else
            {
                Console.WriteLine("Job Applied Not sucessfully");
            }
        }

        public void PostJob()
        {
            
            Console.WriteLine("Enter the ComapanyID");
            int CompanyID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the job Title");
            string JobTitle = Console.ReadLine();
            Console.WriteLine("Enter the job Descrption");
            string JobDescription = Console.ReadLine();
            Console.WriteLine("Enter the job Location");
            string JobLocation = Console.ReadLine();
            Console.WriteLine("Enter the Salary");
            double Salary = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the job Type");
            string JobType = Console.ReadLine();
            
            int result = _iallMethodImplementation.PostJob(CompanyID,JobTitle,JobDescription,JobLocation,Salary,JobType);
            if (result > 0)
            {
                Console.WriteLine("Job Posted sucessfull");
            }
            else
            {
                Console.WriteLine("Job Posted  not sucessfull");
            }
        }

        public void GetAvgSalary()
        {
            
           

            try
            {
                List<double> salaries = _iallMethodImplementation.GetSalary();

                if (salaries.Count == 0)
                {
                    Console.WriteLine("No salary data found in the database.");
                    return;
                }

                double totalSalary = 0;
                foreach (var salary in salaries)
                {
                    totalSalary += salary;
                }

                double averageSalary = totalSalary / salaries.Count;
                Console.WriteLine($"Average Salary: {averageSalary:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
