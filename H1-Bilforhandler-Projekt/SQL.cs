using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace H1_Bilforhandler_Projekt
{
    class SQL
    {
        private static string ConnectionString = "Data Source=SKAB1-PC-11;Initial Catalog=Autoshop; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        //SQL Connection /Her opretter vi en forbindelse til vores SQL database.
        public static void sqlconnection(string SQL)
        {
            //Using sørger for at lukke forbindelsen efter brug
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.ExecuteNonQuery();
            }
        }

        //Select /Metode til og vælge customers
        public static void selectCustomers(string SQL)
        {
            //Der oprettes et nyt datatable
            DataTable table = new DataTable();
            //Bruger SQL connection metoden til og oprette ny forbindelse
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                //Adapter til at fylde det nyoprettede table op
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, con);
                adapter.Fill(table);

                
                foreach (DataRow Customer in table.Rows)
                {
                    //For hvert entry i table.Rows skal der udskrives nedenstående
                    Console.WriteLine("\n Customer information");
                    Console.WriteLine("\n ID : " + Customer["id"].ToString());
                    Console.WriteLine(" First name : " + Customer["fName"].ToString());
                    Console.WriteLine(" Last name : " + Customer["lName"].ToString());
                    Console.WriteLine(" Registration date : " + Customer["customerDate"].ToString());
                    Console.WriteLine(" Adress : " + Customer["adr"].ToString());
                    Console.WriteLine(" Phone number : " + Customer["pNumber"].ToString());
                    Console.WriteLine("_____________________________________");
                }
            }
            Console.ReadKey();
        }

        //Select Cars
        public static void selectCars(string SQL)
        {
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
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, con);
                adapter.Fill(table);

                
                foreach (DataRow CustomerAndCars in table.Rows)
                {
                    Console.WriteLine("\n Customer information");
                    Console.WriteLine("\n ID : " + CustomerAndCars["id"].ToString());
                    Console.WriteLine(" First name : " + CustomerAndCars["fName"].ToString());
                    Console.WriteLine(" Last name : " + CustomerAndCars["lName"].ToString());
                    Console.WriteLine(" Registration date : " + CustomerAndCars["customerDate"].ToString());
                    Console.WriteLine(" Adress : " + CustomerAndCars["adr"].ToString());
                    Console.WriteLine(" Phone number : " + CustomerAndCars["pNumber"].ToString());
                    Console.WriteLine("\n Cars belonging to this customer : ");
                    Console.WriteLine("\n ID : " + CustomerAndCars["id"].ToString());
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

        //inputCheck /Kigger i det indtastede input efter fejl
        public static bool inputCheck(string input, string chars, int stringLength)
        {
            bool pass = true;    
            //Hvis det indtastede input er tomt(null) køres der nedenstående
            if (input == "")
            {
                //pass sættes til false og metoden starter forfra
                pass = false;
                Console.WriteLine("\n Please input something!");
                Thread.Sleep(500);
            }                
            else
            {
                if(input.Length <= stringLength) //Det indtastede inputs længde må ikke være længre end vores maximalt tilladte længde
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if ((chars).IndexOf(input.Substring(i, 1)) <0) //Checker så at hver tegn i det indtastede input er en godkendt karakter
                        {
                            pass = false;
                            Console.WriteLine("\n Invalid characters deteceted! ");
                            Thread.Sleep(1000);
                            break; // stoppor forlækken+
                        }
                    }
                }
                else
                {
                    pass = false;
                    Console.WriteLine("\n Maximum of {0} characters allowed! ", stringLength); 
                    Thread.Sleep(1000);
                }
            }
            return pass;
        }
    }
}
