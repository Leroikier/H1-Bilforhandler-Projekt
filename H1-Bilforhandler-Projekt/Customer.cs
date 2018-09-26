using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Console.Write("Type Firstname : ");
            fName = Console.ReadLine();

            Console.Write("Type Lastname : ");
            lName = Console.ReadLine();

            Console.Write("Type Registration Date : ");
            regDate = Console.ReadLine();

            Console.Write("Type Address : ");
            Adr = Console.ReadLine();

            Console.Write("Type Phone Number : ");
            pNumber = Int32.Parse(Console.ReadLine());

            string statement = "insert into Customer values ('" + fName + "','" + lName+ "','" + regDate + "','" + Adr + "'," + pNumber + ")";

            SQL.sqlconnection(statement);
        }
        public void updateCustomer()
        {
            Console.Clear();
            string input1, input2="", column="";
            Console.Write("Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1); 
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. Registration Date");
            Console.WriteLine("4. Adress");
            Console.WriteLine("5. Phone Number");
            Console.Write("What information do you want to update : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    {
                        Console.Write("Input new first name : ");
                        input2 = Console.ReadLine();
                        column = "fName";
                        break;
                    }
                case "2":
                    {
                        Console.Write("Input new last name : ");
                        input2 = Console.ReadLine();
                        column = "lName";
                        break;
                    }
                case "3":
                    {
                        Console.Write("Input new Registration Date : ");
                        input2 = Console.ReadLine();
                        column = "regDate";
                        break;
                    }
                case "4":
                    {
                        Console.Write("Input new adress : ");
                        input2 = Console.ReadLine();
                        column = "adr";
                        break;
                    }
                case "5":
                    {
                        Console.Write("Input new phone number : ");
                        input2 = Console.ReadLine();
                        column = "pNumber";
                        break;
                    }
            }
            string statement = ("update Customer set " + column + " = " + "'" + input2 + "'" + " where pNumber = " + input1);
            SQL.sqlconnection(statement);

            Console.ReadKey();
        }        
    }
}
