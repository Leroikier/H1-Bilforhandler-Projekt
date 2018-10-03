using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace H1_Bilforhandler_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            //Oprettelse af instancer /Customer /Car
            Customer customer1 = new Customer();
            Car car1 = new Car();

            bool quit = false;

            //Hovedmenuen //Switchase //Do while //Metode kald
            do
            {
                Console.Clear();

                Console.WriteLine(" \n Welcome to AutoShop 1.0");
                Console.WriteLine("___________________________\n");
                Console.WriteLine(" 1. Create Customer");
                Console.WriteLine(" 2. Edit Customer");
                Console.WriteLine(" 3. Delete Customer");
                Console.WriteLine(" 4. Show Customers");
                Console.WriteLine("___________________________\n");
                Console.WriteLine(" 5. Create Car");
                Console.WriteLine(" 6. Edit Car");
                Console.WriteLine(" 7. Delete Car");
                Console.WriteLine(" 8. Show a customer's cars");
                Console.WriteLine("___________________________\n");
                Console.WriteLine(" 9. Create Appointment");
                Console.WriteLine(" 10. Edit Appointment");
                Console.WriteLine(" 11. Delete Appointment");
                Console.WriteLine(" 12. Show Appointments");
                Console.WriteLine("___________________________\n");
                Console.WriteLine(" 13. Exit/Close\n");
                Console.Write(" Choose a number : ");
                string valg = Console.ReadLine();

                switch (valg)
                {
                    case "1":
                        {
                            customer1.createCustomer();
                            break;
                        }
                    case "2":
                        {
                            customer1.updateCustomer();
                            break;
                        }
                    case "3":
                        {
                            customer1.deleteCustomer();
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            Console.WriteLine("\n Show customers");
                            Console.WriteLine("___________________");
                            Console.WriteLine("\n 1. Order by First name");
                            Console.WriteLine(" 2. Order by Car Brand");
                            Console.Write("\n Choose how to order the list : ");
                            string input = Console.ReadLine();

                            switch (input)
                            {
                                case "1":
                                    {
                                        Console.WriteLine("\n Show customers");
                                        Console.WriteLine("___________________");
                                        SQL.selectCustomersAndCars("select * from Customer left join Cars on pNumber = customerID Order BY fName");
                                        break;
                                    }
                                case "2":
                                    {
                                        Console.WriteLine("\n Show customers");
                                        Console.WriteLine("___________________");
                                        SQL.selectCustomersAndCars("select * from Customer left join Cars on pNumber = customerID Order BY brand");
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("\n Show customers");
                                        Console.WriteLine("___________________");
                                        Console.WriteLine("\n Invalid input! Returning to main menu...");
                                        Thread.Sleep(2000);
                                        break;
                                    }
                            }
                            break;
                        }
                    case "5":
                        {
                            car1.createCar();
                            break;
                        }
                    case "6":
                        {
                            car1.updateCar();
                            break;
                        }
                    case "7":
                        {
                            car1.deleteCar();
                            break;
                        }
                    case "8":
                        {
                            car1.showCars();
                            break;
                        }
                    case "9":
                        {
                            car1.createAppointment();
                            break;
                        }
                    case "10":
                        {
                            car1.editAppointments();
                            break;
                        }
                    case "11":
                        {
                            car1.deleteAppointment();
                            break;
                        }
                    case "12":
                        {
                            car1.showAppointments();
                            break;
                        }
                    case "13":
                        {
                            quit = true;
                            break;
                        }
                }
            }            
            while (quit == false);
        }
    }
}
