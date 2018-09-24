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
            createCustomer();
            SQL.select("select * from Customer");
            Console.ReadKey();
        }

        private static void createCustomer()
        {
            string statement = "insert into Customer values ('" + "Jesper" + "','" + "Fårekylling" + "','" + "24/09-2018" + "','" + "Telegrafvej 9" + "'," + 50 + ")";

            SQL.insert(statement);
        }
        /*private static void updateCustomer()
        {
            string statement = "insert into Customer values ('" + "Jesper" + "','" + "Fårekylling" + "','" + "24/09-2018" + "','" + "Telegrafvej 9" + "'," + 50 + ")";

            SQL.insert(statement);
        }*/
    }
}
