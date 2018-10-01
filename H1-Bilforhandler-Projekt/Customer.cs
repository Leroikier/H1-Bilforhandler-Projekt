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
        private string customerDate;
        private string Adr;
        private int pNumber;

        private string check = "OK";

        //Create Customer
        public void createCustomer()
        {
            Console.Clear();
            Console.Write("\n Type Firstname : ");
            fName = Console.ReadLine().ToUpper();

            Console.Write(" Type Lastname : ");
            lName = Console.ReadLine().ToUpper();

            Console.Write(" Type Registration Date dd-mm-yyyy : ");
            customerDate = Console.ReadLine();

            Console.Write(" Type Address : ");
            Adr = Console.ReadLine().ToUpper();
            do
            {
                check = "OK";
                Console.Write(" Type Phone Number : ");
                string input = Console.ReadLine();
                if (input.Length != 8)
                {
                    Console.WriteLine("Phone number must be 8 characters long!");
                    Console.ReadKey();
                    check = "not OK";
                }
                else if (Int32.TryParse(input, out pNumber))
                    pNumber = Int32.Parse(input);
                else
                {
                    Console.WriteLine("Only numbers allowed!");
                    check = "not OK";
                }
            }
            while (check == "not OK");


            string statement = "insert into Customer values ('" + fName + "','" + lName+ "','" + customerDate + "','" + Adr + "'," + pNumber + ")";
            try
            {
                SQL.sqlconnection(statement);
                Console.WriteLine("\n Customer has been created");
            }
            catch (Exception)
            {   
                Console.WriteLine("\n ERROR : Phone number belongs to another customer!");
                Console.ReadKey();
            }
            Console.WriteLine("\n Returning to main menu");

            Thread.Sleep(3000);
        }

        //Update Customer
        public void updateCustomer()
        {
            Console.Clear();
            string input1, input2="", column="", statement="";
            Console.Write("\n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1); 
            Console.WriteLine("\n 1. First Name");
            Console.WriteLine(" 2. Last Name");
            Console.WriteLine(" 3. Registration Date");
            Console.WriteLine(" 4. Adress");
            Console.WriteLine(" 5. Phone Number\n");
            Console.Write(" What information do you want to update : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    {
                        Console.Write("\n Input new first name : ");
                        input2 = Console.ReadLine().ToUpper();
                        column = "fName";
                        break;
                    }
                case "2":
                    {
                        Console.Write("\n Input new last name : ");
                        input2 = Console.ReadLine().ToUpper();
                        column = "lName";
                        break;
                    }
                case "3":
                    {
                        Console.Write("\n Input new Registration Date : ");
                        input2 = Console.ReadLine();
                        column = "customerDate";
                        break;
                    }
                case "4":
                    {
                        Console.Write("\n Input new adress : ");
                        input2 = Console.ReadLine().ToUpper();
                        column = "adr";
                        break;
                    }
                case "5":
                    {
                        Console.Write("\n Input new phone number : ");
                        input2 = Console.ReadLine();
                        column = "pNumber";
                        statement = ("update Customer set " + column + " = " + input2 + " where pNumber = " + input1);
                        break;
                    }
            }
            //string statement = ("update Customer set " + column + " = " + "'" + input2 + "'" + " where pNumber = " + input1);
            try
            {
                SQL.sqlconnection(statement);
                Console.WriteLine("\n Customer info updated");
            }
            catch (Exception)
            {
                Console.Write("\n ERROR : Phone number belongs to another customer!");
                Console.ReadKey();
            }
            Console.WriteLine("\n Returning to main menu");
            Thread.Sleep(3000);
        }

        //Delete Customer
        public void deleteCustomer()
        {
            Console.Clear();
            string input1 = "";
            Console.Write("\n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1 + "\n");
          
            Console.Write("\n Is this the customer you want to delete ? y/n : ");
            string choice = Console.ReadLine().ToUpper();

            if (choice == "Y")
            {
                string statement2 = ("delete from Customer Where pNumber=" + input1 + "\n");
                SQL.sqlconnection(statement2);
                Console.WriteLine("\n Customer has been erased!\n Returning to main menu...");
            }
            else
            {
                Console.WriteLine("\n Returning to main menu...");
            }
            
            Thread.Sleep(2000);
        }
    }
}
