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

                Console.WriteLine("\n id | Name | Lastname | RegDate | Adress | Phone");
                foreach (DataRow Customer in table.Rows)
                {
                    Console.Write(" " + Customer["id"].ToString() + " | ");
                    Console.Write(Customer["fName"].ToString() + " | ");
                    Console.Write(Customer["lName"].ToString() + " | ");
                    Console.Write(Customer["customerDate"].ToString() + " | ");
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

                Console.WriteLine("\n id | Brand | Model | Age | RegNumber | RegDate | Mileage | Fueltype | Owner");
                foreach (DataRow Customer in table.Rows)
                {
                    Console.Write(" " + Customer["id"].ToString() + " | ");
                    Console.Write(Customer["brand"].ToString() + " | ");
                    Console.Write(Customer["model"].ToString() + " | ");
                    Console.Write(Customer["age"].ToString() + " | ");
                    Console.Write(Customer["regNumber"].ToString() + " | ");
                    Console.Write(Customer["carDate"].ToString() + " | ");
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

        //Select Customers And Cars
        public static void selectCustomersAndCars(string SQL)
        {
            Console.Clear();
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, con);
                adapter.Fill(table);

                Console.WriteLine("\n id | Name | Lastname | RegDate | Adress | Phone | id | Brand | Model | Age | RegNumber | RegDate | Mileage | Fueltype | Owner ");
                foreach (DataRow CustomerAndCars in table.Rows)
                {
                    Console.Write(" " + CustomerAndCars["id"].ToString() + " | ");
                    Console.Write(CustomerAndCars["fName"].ToString() + " | ");
                    Console.Write(CustomerAndCars["lName"].ToString() + " | ");
                    Console.Write(CustomerAndCars["customerDate"].ToString() + " | ");
                    Console.Write(CustomerAndCars["adr"].ToString() + " | ");
                    Console.Write(CustomerAndCars["pNumber"].ToString() + " | ");
                    Console.Write(CustomerAndCars["id"].ToString() + " | ");
                    Console.Write(CustomerAndCars["brand"].ToString() + " | ");
                    Console.Write(CustomerAndCars["model"].ToString() + " | ");
                    Console.Write(CustomerAndCars["age"].ToString() + " | ");
                    Console.Write(CustomerAndCars["regNumber"].ToString() + " | ");
                    Console.Write(CustomerAndCars["carDate"].ToString() + " | ");
                    Console.Write(CustomerAndCars["miles"].ToString() + " | ");
                    Console.Write(CustomerAndCars["fuelType"].ToString() + " | ");
                    Console.Write(CustomerAndCars["customerID"].ToString() + "\n");

                }
                //For at få vist en bestemt kolonne i en bestemt række
                //string theFirstRow = table.Rows[0]["fName"].ToString();
            }
            Console.ReadKey();
        }
    }
}
