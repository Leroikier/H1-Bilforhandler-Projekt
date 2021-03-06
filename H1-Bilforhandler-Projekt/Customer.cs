﻿using System;
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
            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create Customer");
                Console.WriteLine("___________________");
                Console.Write("\n Type Firstname : ");
                fName = Console.ReadLine().ToUpper();
                if (!SQL.inputCheck(fName, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNMÄÖ", 50))
                    check = "not OK";
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create Customer");
                Console.WriteLine("___________________");
                Console.Write("\n Type Lastname : ");
                lName = Console.ReadLine().ToUpper();
                if (!SQL.inputCheck(lName, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNMÄÖ", 50))
                    check = "not OK";                   
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create Customer");
                Console.WriteLine("___________________");
                Console.Write("\n Type Registration Date dd-mm-yyyy : ");
                customerDate = Console.ReadLine();
                if (!SQL.inputCheck(customerDate, "0123456789-",10))
                    check = "not OK";
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create Customer");
                Console.WriteLine("___________________");
                Console.Write("\n Type Address : ");
                Adr = Console.ReadLine().ToUpper();
                if (!SQL.inputCheck(Adr, "0123456789QWERTYUIOPÅASDFGHJKLÆØZXCVBNMÄÖ ", 50))
                    check = "not OK";
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create Customer");
                Console.WriteLine("___________________");
                Console.Write("\n Type Phone number : ");
                string testInt = Console.ReadLine().ToUpper();
                if (!SQL.inputCheck(testInt, "0123456789", 8))
                    check = "not OK";
                else
                    pNumber = Int32.Parse(testInt);
            }
            while (check == "not OK");

            string statement = "insert into Customer values ('" + fName + "','" + lName+ "','" + customerDate + "','" + Adr + "'," + pNumber + ")";
            try
            {
                SQL.sqlconnection(statement);
                Console.WriteLine("\n Customer has been created!");
            }
            catch (Exception)
            {   
                Console.WriteLine("\n ERROR : Phone number belongs to another customer!");
                Console.ReadKey();
            }
            Console.WriteLine("\n Returning to main menu...");

            Thread.Sleep(3000);
        }

        //Update Customer
        public void updateCustomer()
        {
            Console.Clear();
            string input1, input2="", column="", statement="";
            Console.WriteLine("\n Update Customer");
            Console.WriteLine("___________________");
            Console.Write("\n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n Update Customer");
            Console.WriteLine("___________________");
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1); 
            Console.WriteLine("\n 1. First Name");
            Console.WriteLine(" 2. Last Name");
            Console.WriteLine(" 3. Registration Date");
            Console.WriteLine(" 4. Adress");
            Console.WriteLine(" 5. Phone Number\n");
            Console.Write(" What information do you wish to update? : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    {
                        do
                        {
                            Console.Clear();
                            check = "OK";
                            Console.WriteLine("\n Update Customer");
                            Console.WriteLine("___________________");
                            Console.Write("\n Input new first name : ");
                            input2 = Console.ReadLine().ToUpper();
                            if (!SQL.inputCheck(input2, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNMÄÖ", 50))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "fName";
                        break;
                    }
                case "2":
                    {
                        do
                        {
                            Console.Clear();
                            check = "OK";
                            Console.WriteLine("\n Update Customer");
                            Console.WriteLine("___________________");
                            Console.Write("\n Input new last name : ");
                            input2 = Console.ReadLine().ToUpper();
                            if (!SQL.inputCheck(input2, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNMÄÖ", 50))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "lName";
                        break;
                    }
                case "3":
                    {
                        do
                        {
                            Console.Clear();
                            check = "OK";
                            Console.WriteLine("\n Update Customer");
                            Console.WriteLine("___________________");
                            Console.Write("\n Input new Registration Date : ");
                            input2 = Console.ReadLine().ToUpper();
                            if (!SQL.inputCheck(input2, "0123456789-", 10))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "customerDate"; 
                        break;
                    }
                case "4":
                    {
                        do
                        {
                            Console.Clear();
                            check = "OK";
                            Console.WriteLine("\n Update Customer");
                            Console.WriteLine("___________________");
                            Console.Write("\n Input new adress : ");
                            input2 = Console.ReadLine().ToUpper();
                            if (!SQL.inputCheck(input2, "0123456789QWERTYUIOPÅASDFGHJKLÆØZXCVBNMÄÖ ", 50))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "adr"; 
                        break;
                    }
                case "5":
                    {
                        do
                        {
                            Console.Clear();
                            check = "OK";
                            Console.WriteLine("\n Update Customer");
                            Console.WriteLine("___________________");
                            Console.Write("\n Input new phone number : ");
                            input2 = Console.ReadLine().ToUpper();
                            if (!SQL.inputCheck(input2, "0123456789", 8))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "pNumber";
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\n Invalid input!");
                        break;
                    }
            }
            statement = ("update Customer set " + column + " = " + "'" + input2 + "'" + " where pNumber = " + input1);
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
            Console.WriteLine("\n Returning to main menu...");
            Thread.Sleep(3000);
        }

        //Delete Customer
        public void deleteCustomer()
        {
            Console.Clear();
            string input1 = "";
            Console.WriteLine("\n Delete Customer");
            Console.WriteLine("___________________");
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
