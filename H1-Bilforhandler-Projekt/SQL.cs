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
        public static void sqlconnection(string SQL)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.ExecuteNonQuery();
            }
        }

        //Select
        public static void selectCustomers(string SQL)
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
                    Console.Write(" " + Customer["id"].ToString() + " | ");
                    Console.Write(Customer["fName"].ToString() + " | ");
                    Console.Write(Customer["lName"].ToString() + " | ");
                    Console.Write(Customer["regDate"].ToString() + " | ");
                    Console.Write(Customer["adr"].ToString() + " | ");
                    Console.Write(Customer["pNumber"].ToString() + "\n");                    
                }                
                //For at få vist en bestemt kolonne i en bestemt række
                //string theFirstRow = table.Rows[0]["fName"].ToString();
            }
            Console.ReadKey();
        }

        //Select Cars
        public static void selectCars(string SQL)
        {
            //Console.Clear();
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, con);
                adapter.Fill(table);

                foreach (DataRow Customer in table.Rows)
                {
                    Console.Write(" " + Customer["id"].ToString() + " | ");
                    Console.Write(Customer["brand"].ToString() + " | ");
                    Console.Write(Customer["model"].ToString() + " | ");
                    Console.Write(Customer["age"].ToString() + " | ");
                    Console.Write(Customer["regNumber"].ToString() + " | ");
                    Console.Write(Customer["regDate"].ToString() + " | ");
                    Console.Write(Customer["miles"].ToString() + " | ");
                    Console.Write(Customer["fuelType"].ToString() + " | ");
                    Console.Write(Customer["customerID"].ToString() + "\n");
                }
            }
            Console.ReadKey();
        }

        //Select Appointments
        public static void selectAppointments(string SQL)
        {
            //Console.Clear();
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, con);
                adapter.Fill(table);

                Console.WriteLine("\n id");
                foreach (DataRow Customer in table.Rows)
                {
                    Console.Write(" " + Customer["id"].ToString() + " | ");
                    Console.Write(Customer["arrivalDate"].ToString() + " | ");
                    Console.Write(Customer["leavingDate"].ToString() + " | ");
                    Console.Write(Customer["carID"].ToString() + "\n");
                }
            }
            Console.ReadKey();
        }
    }
}
