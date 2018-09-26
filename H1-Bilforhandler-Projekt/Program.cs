using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace H1_Bilforhandler_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer();

            bool quit = false;

            do
            {
                Console.Clear();
            

            Console.WriteLine();
            Console.WriteLine(" Welcome too AutoShop 1.0\n");
            Console.WriteLine(" 1. Create Customer");
            Console.WriteLine(" 2. Edit Customer");
            Console.WriteLine(" 3. Delete Customer");
            Console.WriteLine(" 4. Show Customers");
            Console.WriteLine();
            Console.WriteLine(" 5. Create Car");
            Console.WriteLine(" 6. Edit Car");
            Console.WriteLine(" 7. Delete Car");
            Console.WriteLine(" 8. Show Car");
            Console.WriteLine();
            Console.WriteLine(" 9. Create Appointment");
            Console.WriteLine(" 10. Edit Appointment");
            Console.WriteLine(" 11. Delete Appointment");
            Console.WriteLine(" 12. Show Appointment");
            Console.WriteLine();
            Console.WriteLine(" 13. Exit/Close\n");
            Console.Write(" Chose a number : ");
            string valg = Console.ReadLine();
            
            switch (valg)
            {
                case "1":
                    {
                        c1.createCustomer();
                        break;
                    }
                case "2":
                    {
                        SQL.update("");
                        
                        break;
                    }
                case "3":
                    {
                        break;
                    }
                case "4":
                    {
                        SQL.select("select * from Customer ORDER BY id");
                        break;
                    }
                case "5":
                    {
                        break;
                    }
                case "6":
                    {
                        break;
                    }
                case "7":
                    {
                        break;
                    }
                case "8":
                    {
                        break;
                    }
                case "9":
                    {
                        break;
                    }
                case "10":
                    {
                        break;
                    }
                case "11":
                    {
                        break;
                    }
                case "12":
                    {
                        break;
                    }
                case "13":
                    {
                            quit = true;
                        break;
                    }
            }

            } while (quit == false);
        }
    }
}
