using CareerHub.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("----------------------------Welcome to the CarrerHub Menu-----------------------");
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
                            Console.WriteLine("Welcome to the OrderDetail Interface");
                            Console.WriteLine("1.CalculateSubtotal\n2.GetOrderDetailInfo\n3.UpdateQuantity\n4.AddDiscount\n5.back to MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    ods.CalculateSubtotal();
                                    break;

                                case 2:
                                    ods.GetOrderDetailInfo();
                                    break;
                                case 3:
                                    ods.UpdateQuantity();
                                    break;
                                case 4:
                                    Console.WriteLine("Not done yet");
                                    break;

                                case 5:
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
                            Console.WriteLine("Welcome to the Inventory Interface");
                            Console.WriteLine(@"1.GetProduct\n2.GetQuantityInStock\n3.AddToInventory\n4.RemoveFromInventory
                                \n5.UpdateStockQuantity\n6.IsProductAvailable\n7.GetInventoryValue\n8.ListLowStockProducts\n9.ListOutOfStockProducts\n10.ListAllProducts\n11.back to MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    ins.GetProduct();
                                    break;

                                case 2:
                                    ins.GetQuantityInStock();
                                    break;
                                case 3:
                                    ins.AddToInventory();
                                    break;
                                case 4:
                                    ins.RemoveFromInventory();
                                    break;

                                case 5:
                                    ins.UpdateStockQuantity();
                                    break;
                                case 6:
                                    ins.IsProductAvailable();
                                    break;
                                case 7:
                                    ins.GetInventoryValue();
                                    break;
                                case 8:
                                    ins.ListLowStockProducts();
                                    break;
                                case 9:
                                    ins.ListOutOfStockProducts();
                                    break;
                                case 10:
                                    ins.ListAllProducts();
                                    break;
                                case 11:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;


                    case 6:
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
