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
                    Console.WriteLine("\n Customer information");
                    Console.WriteLine("\n ID : " + Customer["id"].ToString());
                    Console.WriteLine(" First name : " + Customer["fName"].ToString());
                    Console.WriteLine(" Last name : " + Customer["lName"].ToString());
                    Console.WriteLine(" Registration date : " + Customer["customerDate"].ToString());
                    Console.WriteLine(" Adress : " + Customer["adr"].ToString());
                    Console.WriteLine(" Phone number : " + Customer["pNumber"].ToString());
                    Console.WriteLine("_____________________________________");
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
                    
                    Console.WriteLine(" \n ID : " + Customer["id"].ToString());
                    Console.WriteLine(" Brand :  " + Customer["brand"].ToString());
                    Console.WriteLine(" Model :  " + Customer["model"].ToString());
                    Console.WriteLine(" Age :  " + Customer["age"].ToString());
                    Console.WriteLine(" Registration number :  " + Customer["regNumber"].ToString());
                    Console.WriteLine(" Registration date :  " + Customer["carDate"].ToString());
                    Console.WriteLine(" Miles :  " + Customer["miles"].ToString());
                    Console.WriteLine(" Fuel type :  " + Customer["fuelType"].ToString());
                    Console.WriteLine(" Customer reference :  " + Customer["customerID"].ToString());
                    Console.WriteLine("_____________________________________");
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
                    Console.Clear();
                    Console.WriteLine("\n Car Appointment\n");
                    Console.WriteLine(" ID : " + Customer["id"].ToString());
                    Console.WriteLine(" Arrival date :  " + Customer["arrivalDate"].ToString());
                    Console.WriteLine(" Leaving date :  " + Customer["leavingDate"].ToString());
                    Console.WriteLine(" Registration number :  " + Customer["carID"].ToString());
                    Console.WriteLine("_____________________________________");
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

                
                foreach (DataRow CustomerAndCars in table.Rows)
                {
                    Console.WriteLine("\n Customer information");
                    Console.WriteLine(" ID : " + CustomerAndCars["id"].ToString());
                    Console.WriteLine(" First name : " + CustomerAndCars["fName"].ToString());
                    Console.WriteLine(" Last name : " + CustomerAndCars["lName"].ToString());
                    Console.WriteLine(" Registration date : " + CustomerAndCars["customerDate"].ToString());
                    Console.WriteLine(" Adress : " + CustomerAndCars["adr"].ToString());
                    Console.WriteLine(" Phone number : " + CustomerAndCars["pNumber"].ToString());
                    Console.WriteLine("\n Cars belonging to this customer");
                    Console.WriteLine(" ID : " + CustomerAndCars["id"].ToString());
                    Console.WriteLine(" Brand : " + CustomerAndCars["brand"].ToString());
                    Console.WriteLine(" Model : " + CustomerAndCars["model"].ToString());
                    Console.WriteLine(" Age : " + CustomerAndCars["age"].ToString());
                    Console.WriteLine(" Registration number : " + CustomerAndCars["regNumber"].ToString());
                    Console.WriteLine(" Registration date : " + CustomerAndCars["carDate"].ToString());
                    Console.WriteLine(" Miles : " + CustomerAndCars["miles"].ToString());
                    Console.WriteLine(" Fuel type : " + CustomerAndCars["fuelType"].ToString());
                    Console.WriteLine(" Customer reference : " + CustomerAndCars["customerID"].ToString());
                    Console.WriteLine("_____________________________________");

                }
                //For at få vist en bestemt kolonne i en bestemt række
                //string theFirstRow = table.Rows[0]["fName"].ToString();
            }
            Console.ReadKey();
        }
    }
}
