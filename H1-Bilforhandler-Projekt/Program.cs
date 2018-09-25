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

            c1.createCustomer();
            SQL.select("select * from Customer");
            Console.ReadKey();
        }
    }
}
