using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H1_Bilforhandler_Projekt
{
    class Customer
    {
        private string fName;
        private string lName;
        private string regDate;
        private string Adr;
        private int pNumber;

        //Create Customer
        public void createCustomer()
        {
            Console.Clear();
            Console.Write(" Type Firstname : ");
            fName = Console.ReadLine();

            Console.Write(" Type Lastname : ");
            lName = Console.ReadLine();

            Console.Write(" Type Registration Date : ");
            regDate = Console.ReadLine();

            Console.Write(" Type Address : ");
            Adr = Console.ReadLine();

            Console.Write(" Type Phone Number : ");
            pNumber = Int32.Parse(Console.ReadLine());

            string statement = "insert into Customer values ('" + fName + "','" + lName+ "','" + regDate + "','" + Adr + "'," + pNumber + ")";

            SQL.sqlconnection(statement);

            Console.WriteLine("\n Customer has been created");

            Thread.Sleep(3000);
        }

        //Update Customer
        public void updateCustomer()
        {
            Console.Clear();
            string input1, input2="", column="";
            Console.Write(" \nType Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1); 
            Console.WriteLine(" 1. First Name");
            Console.WriteLine(" 2. Last Name");
            Console.WriteLine(" 3. Registration Date");
            Console.WriteLine(" 4. Adress");
            Console.WriteLine(" 5. Phone Number");
            Console.Write(" What information do you want to update : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    {
                        Console.Write(" Input new first name : ");
                        input2 = Console.ReadLine();
                        column = "fName";
                        break;
                    }
                case "2":
                    {
                        Console.Write(" Input new last name : ");
                        input2 = Console.ReadLine();
                        column = "lName";
                        break;
                    }
                case "3":
                    {
                        Console.Write(" Input new Registration Date : ");
                        input2 = Console.ReadLine();
                        column = "regDate";
                        break;
                    }
                case "4":
                    {
                        Console.Write(" Input new adress : ");
                        input2 = Console.ReadLine();
                        column = "adr";
                        break;
                    }
                case "5":
                    {
                        Console.Write(" Input new phone number : ");
                        input2 = Console.ReadLine();
                        column = "pNumber";
                        break;
                    }
            }
            string statement = ("update Customer set " + column + " = " + "'" + input2 + "'" + " where pNumber = " + input1);
            SQL.sqlconnection(statement);

            Console.WriteLine(" \nCustomer info updated");
            Thread.Sleep(3000);
        }

        //Delete Customer
        public void deleteCustomer()
        {
            Console.Clear();
            string input1 = "";
            Console.Write(" \n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1 + "\n");
            Console.WriteLine(" Is this the customer you want to delete ? y/n");
            string choice = Console.ReadLine();

            if (choice == "y")
            {
                string statement = ("delete from Cars Where customerID=" + input1 + "\n");
                SQL.sqlconnection(statement);
                string statement2 = ("delete from Customer Where pNumber=" + input1 + "\n");
                SQL.sqlconnection(statement2);
                Console.WriteLine(" \nCustomer has been erased!\n Returning to main menu...");
            }
            if (choice == "n")
            {
                Console.WriteLine(" Returning to main menu...");
            }
            Thread.Sleep(2000);
        }
    }
}
