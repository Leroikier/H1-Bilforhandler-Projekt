using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace H1_Bilforhandler_Projekt
{
    class SQL
    {
        private static string ConnectionString = "Data Source=SKAB1-PC-11;Initial Catalog=Autoshop; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        //Insert // husk og tilføje til klasse diagram
        public static void insert(string SQL)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.ExecuteNonQuery();
            }
        }

        //Select
        public static void select(string SQL)
        {
            Console.Clear();
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, con);
                adapter.Fill(table);

                foreach (DataRow Customer in table.Rows)
                {
                    Console.WriteLine(Customer["id"].ToString());
                    Console.WriteLine(Customer["fName"].ToString());
                    Console.WriteLine(Customer["lName"].ToString());
                    Console.WriteLine(Customer["reqDate"].ToString());
                    Console.WriteLine(Customer["adr"].ToString());
                    Console.WriteLine(Customer["pNumber"].ToString());
                    Console.WriteLine();
                }
                
                //For at få vist en bestemt kolonne i en bestemt række
                //string theFirstRow = table.Rows[0]["fName"].ToString();
            }
            Console.ReadKey();
        }

        //Update
        public static void update(string SQL)
        {
            Console.Write("Type Phone Number of a Customer : ");
            string input = Console.ReadLine();
            select("select * from Customer Where pNumber ="+ input);
            Console.Write("What information do you want to update : ");
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. Registration Date");
            Console.WriteLine("4. Adress");
            Console.WriteLine("5. Phone Number");
            string choice = Console.ReadLine();
            
            switch  (choice)
            {
                case "1":
                {
                        break;
                }
                case "2":
                {
                        break;
                }
                case "3":
                {
                        break;
                }
                case "4":
                {
                        break;
                }
                case "5":
                {
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
