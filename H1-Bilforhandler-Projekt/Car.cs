using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H1_Bilforhandler_Projekt
{
    class Car
    {
        private string brand;
        private string model;
        private int age;
        private string regNumber;
        private string carDate;
        private int miles;
        private string fuelType;
        private int customerID;

        private string arrivalDate = "";
        private string leavingDate = "";

        //Create Car
        public void createCar()
        {
            Console.Clear();
            Console.Write("\n Type Brand : ");
            brand = Console.ReadLine().ToUpper();

            Console.Write(" Type Model : ");
            model = Console.ReadLine().ToUpper();

            Console.Write(" Type Age : ");
            age = Int32.Parse(Console.ReadLine());

            Console.Write(" Type Registration number : ");
            regNumber = Console.ReadLine().ToUpper();

            Console.Write(" Type Registration Date : ");
            carDate = Console.ReadLine();

            Console.Write(" Type Miles : ");
            miles = Int32.Parse(Console.ReadLine());

            Console.Write(" Type Fueltype : ");
            fuelType = Console.ReadLine().ToUpper();

            Console.Write(" Type Owner's phone : ");
            customerID = Int32.Parse(Console.ReadLine());

            string statement = "insert into Cars values ('" + brand + "','" + model + "'," + age + ",'" + regNumber + "','" + carDate + "'," + miles + ",'" + fuelType + "'," + customerID + ")";

            try
            {
                SQL.sqlconnection(statement);
                Console.WriteLine("\n Car Created");
            }
            catch (Exception)
            {
                Console.WriteLine("\n ERROR : Registration number belongs to another car!");
                Console.ReadKey();
            }
            Console.WriteLine("\n Returning to main menu");

            Thread.Sleep(3000);
        }

        //Show Cars
        public void showCars()
        {
            Console.Clear();
            string input1 = "";
            Console.Write("\n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1 + "\n");
            SQL.selectCars("select * from Cars where customerID =" + input1 + "ORDER by ID");
            
            Thread.Sleep(3000);
        }

        //Delete Car
        public void deleteCar()
        {
            Console.Clear();
            string input1 = "";
            Console.Write("\n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1 + "\n");
            SQL.selectCars("select * from Cars where customerID =" + input1);
            Console.Write("\n Type the registration number of the car you want to delete : ");
            string choice = Console.ReadLine().ToUpper();

            //string statement = ("delete from carAppointments Where carID = '" + choice + "'");
            //SQL.sqlconnection(statement);

            string statement2 = ("delete from Cars Where regNumber = '" + choice + "'" + "\n");
            SQL.sqlconnection(statement2);
            Console.WriteLine("\n Car has been erased");
            Console.WriteLine("\n Returning to main menu");
            Thread.Sleep(3000);
        }

        //Update Car
        public void updateCar()
        {
            Console.Clear();
            string input1, input2 = "", column = "";
            Console.Write(" \nType Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1 + "\n");
            SQL.selectCars("select * from Cars where customerID =" + input1);
            Console.Write(" Type the registration number of the car you want to update : ");
            string choice = Console.ReadLine().ToUpper();

            Console.WriteLine(" 1. Brand");
            Console.WriteLine(" 2. Model");
            Console.WriteLine(" 3. Registration Date");
            Console.WriteLine(" 4. Registration Number");
            Console.WriteLine(" 5. Age");
            Console.WriteLine(" 6. Fueltype");
            Console.WriteLine(" 7. Miles");
            Console.WriteLine(" 8. Customer ID");
            Console.Write(" What information do you want to update : ");
            string choice1 = Console.ReadLine();

            switch (choice1)
            {
                case "1":
                    {
                        Console.Write(" Input new brand name : ");
                        input2 = Console.ReadLine().ToUpper();
                        column = "brand";
                        break;
                    }
                case "2":
                    {
                        Console.Write(" Input new model name : ");
                        input2 = Console.ReadLine().ToUpper();
                        column = "model";
                        break;
                    }
                case "3":
                    {
                        Console.Write(" Input new registration date : ");
                        input2 = Console.ReadLine().ToUpper();
                        column = "carDate";
                        break;
                    }
                case "4":
                    {
                        Console.Write(" Input new registration number : ");
                        input2 = Console.ReadLine();
                        column = "regNumber";
                        break;
                    }
                case "5":
                    {
                        Console.Write(" Input new age : ");
                        input2 = Console.ReadLine();
                        column = "age";
                        break;
                    }
                case "6":
                    {
                        Console.Write(" Input new fueltype : ");
                        input2 = Console.ReadLine().ToUpper();
                        column = "fuelType";
                        break;
                    }
                case "7":
                    {
                        Console.Write(" Input new miles : ");
                        input2 = Console.ReadLine();
                        column = "miles";
                        break;
                    }
                case "8":
                    {
                        Console.Write(" Input new customer ID : ");
                        input2 = Console.ReadLine();
                        column = "customerID";
                        break;
                    }
            }
            string statement = ("update Cars set " + column + " = " + "'" + input2 + "'" + " where regNumber = " + "'" + choice + "'");

            try
            {
                SQL.sqlconnection(statement);
                Console.WriteLine("\n Car info updated");
            }
            catch (Exception)
            {
                Console.WriteLine("\n Registration ID already exists");
                Console.ReadKey();
            }

            Console.WriteLine("\n Returning to main menu");
            Thread.Sleep(3000);
        }

        //Create Appointment
        public void createAppointment()
        {
            Console.Clear();
            string input;
            Console.Write("\n Type Phone Number of a Customer : ");
            input = Console.ReadLine();
            SQL.selectCustomers("select * from Customer Where pNumber =" + input + "\n");
            Thread.Sleep(100);
            SQL.selectCars("select * from Cars where customerID =" + input);
            Console.Write("\n Type the registration number of the car you want to create an appointment for : ");
            string choice = Console.ReadLine().ToUpper();

            Console.Write("\n Input the arrival date : ");
            arrivalDate = Console.ReadLine();
            Console.Write("\n Input the leaving date : ");
            leavingDate = Console.ReadLine();

            string statement = "insert into carAppointments values ('" + arrivalDate + "','" + leavingDate + "','" + choice + "')";
            SQL.sqlconnection(statement);

            Console.WriteLine("\n Appointment made");
            Console.WriteLine("\n Returning to main menu...");
            Thread.Sleep(3000);
        }

        //Show Appointments
        public void showAppointments()
        {
            Console.Clear();
            string input;
            Console.Write(" \nType Phone Number of a Customer : ");
            input = Console.ReadLine();
            SQL.selectCustomers("select * from Customer Where pNumber =" + input + "\n");
            Console.WriteLine(" Cars belonging to this customer:");
            SQL.selectCars("select * from Cars where customerID =" + input);
            Console.Write("\n Type the registration number of the car whose appointments you want to view : ");
            string choice = Console.ReadLine().ToUpper();

            
            Console.WriteLine("\n Appointments for this car:");
            SQL.selectAppointments("select * from carAppointments Where carID = '" + choice + "' order by id" + "\n");
            Console.ReadKey();
        }

        //Edit Appointments
        public void editAppointments()
        {
            Console.Clear();
            string input1, input2 = "", column = "";
            Console.Write(" \n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            //SQL.selectCustomers("select * from Customer Where pNumber =" + input1);
            SQL.selectCars("select * from Cars where customerID =" + input1);
            Console.Write("\n Type the registration number of the car whose appointments you want to edit : ");
            string choice1 = Console.ReadLine().ToUpper();
            SQL.selectAppointments("select * from carAppointments Where carID = '" + choice1 + "' order by id");
            Console.WriteLine("\n 1. Arrival date");
            Console.WriteLine(" 2. Leaving date");
            Console.WriteLine(" 3. Car ID\n");
            Console.Write(" What information do you want to update? : ");
            string choice2 = Console.ReadLine();

            switch (choice2)
            {
                case "1":
                    {
                        Console.Write("\n Input new arrival date : ");
                        input2 = Console.ReadLine();
                        column = "arrivalDate";
                        break;
                    }
                case "2":
                    {
                        Console.Write("\n Input new leaving date : ");
                        input2 = Console.ReadLine();
                        column = "leavingDate";
                        break;
                    }
                case "3":
                    {
                        Console.Write("\n Input new car id : ");
                        input2 = Console.ReadLine().ToUpper();
                        column = "carID";
                        break;
                    }
            }
            string statement = ("update carAppointments set " + column + " = " + "'" + input2 + "'" + " where carID = '" + choice1 + "'");
            SQL.sqlconnection(statement);
            Console.WriteLine("\n Appointment info updated!");
            Thread.Sleep(3000);
        }

        //Delete Appointments
        public void deleteAppointment()
        {
            Console.Clear();
            string input1 = "";
            Console.Write("\n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            //SQL.selectCustomers("select * from Customer Where pNumber =" + input1 + "\n");
            SQL.selectCars("select * from Cars where customerID =" + input1);
            Console.Write("\n Type the registration number of the car whose appointments you want to delete : ");
            string choice1 = Console.ReadLine().ToUpper();
            SQL.selectAppointments("select * from carAppointments Where carID = '" + choice1 + "' order by id");
            Console.Write("Select the id of the appointment you wish to delete : ");
            string choice2 = Console.ReadLine();
            string statement = ("delete from carAppointments Where id = " + choice2);
            try
            {
                SQL.sqlconnection(statement);
                Console.WriteLine("\n Appointment has been erased!");
            }
            catch (Exception)
            {
                Console.WriteLine("\n No appointment with that id exists!");
                Console.ReadKey();
            }

            Console.WriteLine("\n Returning to main menu!");

            Thread.Sleep(3000);
        }
    }

}
