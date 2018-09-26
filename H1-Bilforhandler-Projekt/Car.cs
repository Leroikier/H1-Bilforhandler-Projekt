using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Bilforhandler_Projekt
{
    class Car
    {
        private string brand;
        private string model;
        private int age;
        private string regNumber;
        private string regDate;
        private int miles;
        private string fuelType;
        private int customerID; 

        private string arrivalDate = "";
        private string leavingDate = "";

        public void createCar()
        {
            Console.Clear();
            Console.Write("Type Brand : ");
            brand = Console.ReadLine();

            Console.Write("Type Model : ");
            model = Console.ReadLine();

            Console.Write("Type Age : ");
            age = Int32.Parse(Console.ReadLine());

            Console.Write("Type Registration number : ");
            regNumber = Console.ReadLine();

            Console.Write("Type Registration Date : ");
            regDate = Console.ReadLine();

            Console.Write("Type Miles : ");
            miles = Int32.Parse(Console.ReadLine());

            Console.Write("Type Fueltype : ");
            fuelType = Console.ReadLine();

            Console.Write("Type Owner's phone : ");
            customerID = Int32.Parse(Console.ReadLine());

            string statement = "insert into Cars values ('" + brand + "','" + model + "'," + age + ",'" + regNumber + "','" + regDate + "'," + miles + ",'" + fuelType + "'," + customerID + ")";

            SQL.sqlconnection(statement);
        }
        public void showCars()
        {
            string input1="";
            Console.Write("Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1 + "\n");
            SQL.selectCars("select * from Cars where customerID =" + input1);
            Console.ReadKey();
        }
        public void createAppointment()
        {

        }
    }

}
