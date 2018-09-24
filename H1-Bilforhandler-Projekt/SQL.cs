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


        public static void insert(string SQL)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.ExecuteNonQuery();
            }
        }

        public static void select(string SQL)
        {
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
                    Console.WriteLine(Customer["age"].ToString());
                    Console.WriteLine();
                }

                //For at få vist en bestemt kolonne i en bestemt række
                //string theFirstRow = table.Rows[0]["fName"].ToString();
            }
        }
    }
}
