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
        private string reqDate;
        private string Adr;
        private int pNumber;

        public string ReqDate { get; set; }


        public void createCustomer()
        {
            Console.Write("Type Firstname : ");
            fName = Console.ReadLine();

            Console.Write("Type Lastname : ");
            lName = Console.ReadLine();

            Console.Write("Type Registration Date : ");
            ReqDate = Console.ReadLine();

            Console.Write("Type Address : ");
            Adr = Console.ReadLine();

            Console.Write("Type Phone Number : ");
            pNumber = Int32.Parse(Console.ReadLine());

            string statement = "insert into Customer values ('" + fName + "','" + lName+ "','" + ReqDate + "','" + Adr + "'," + pNumber + ")";

            SQL.insert(statement);
        }
        
    }
}
