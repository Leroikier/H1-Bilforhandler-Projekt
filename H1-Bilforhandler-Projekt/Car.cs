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

        private string check = "OK";

        //Create Car
        public void createCar()
        {
            Console.Clear();

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create car");
                Console.WriteLine("___________________");
                Console.Write("\n Type Brand : ");
                brand = Console.ReadLine().ToUpper();
                if (!SQL.inputCheck(brand, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNM", 50))
                    check = "not OK";
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create car");
                Console.WriteLine("___________________");
                Console.Write("\n Type Model : ");
                model = Console.ReadLine().ToUpper();
                if (!SQL.inputCheck(model, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNM0123456789- ", 50))
                    check = "not OK";
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create car");
                Console.WriteLine("___________________");
                Console.Write("\n Type Age : ");
                string testInt = Console.ReadLine();
                if (!SQL.inputCheck(testInt, "0123456789", 50))
                    check = "not OK";
                else
                    age = Int32.Parse(testInt);
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create car");
                Console.WriteLine("___________________");
                Console.Write("\n Type Registration number : ");
                regNumber = Console.ReadLine().ToUpper();
                if (!SQL.inputCheck(regNumber, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNM0123456789 ", 50))
                    check = "not OK";
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create car");
                Console.WriteLine("___________________");
                Console.Write("\n Type Registration Date : ");
                carDate = Console.ReadLine().ToUpper();
                if (!SQL.inputCheck(carDate, "0123456789-", 50))
                    check = "not OK";
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create car");
                Console.WriteLine("___________________");
                Console.Write("\n Type Miles : ");
                string testInt = Console.ReadLine().ToUpper();
                if (!SQL.inputCheck(testInt, "0123456789", 7))
                    check = "not OK";
                else
                    miles = Int32.Parse(testInt);
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create car");
                Console.WriteLine("___________________");
                Console.Write("\n Type Fueltype : ");
                fuelType = Console.ReadLine().ToUpper();
                if (!SQL.inputCheck(fuelType, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNM", 50))
                    check = "not OK";
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create car");
                Console.WriteLine("___________________");
                Console.Write("\n Type Owner's phone : ");
                string testInt = Console.ReadLine().ToUpper();
                if (!SQL.inputCheck(testInt, "0123456789", 8))
                    check = "not OK";
                else
                    customerID = Int32.Parse(testInt);
            }
            while (check == "not OK");

            string statement = "insert into Cars values ('" + brand + "','" + model + "'," + age + ",'" + regNumber + "','" + carDate + "'," + miles + ",'" + fuelType + "'," + customerID + ")";

            try
            {
                SQL.sqlconnection(statement);
                Console.WriteLine("\n Car Created!");
            }
            catch (Exception)
            {
                Console.WriteLine("\n ERROR : Registration number belongs to another car!");
                Console.ReadKey();
            }
            Console.WriteLine("\n Returning to main menu...");

            Thread.Sleep(3000);
        }

        //Show Cars
        public void showCars()
        {
            Console.Clear();
            string input1 = "";
            Console.WriteLine("\n Show cars");
            Console.WriteLine("___________________");
            Console.Write("\n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n Show cars");
            Console.WriteLine("___________________");
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1 + "\n");
            SQL.selectCars("select * from Cars where customerID =" + input1 + "ORDER by ID");
            
            Console.ReadKey();
        }

        //Delete Car
        public void deleteCar()
        {
            Console.Clear();
            string input1 = "";
            Console.WriteLine("\n Delete car");
            Console.WriteLine("___________________");
            Console.Write("\n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n Delete car");
            Console.WriteLine("___________________");
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1 + "\n");
            SQL.selectCars("select * from Cars where customerID =" + input1);
            Console.Write("\n Type the registration number of the car you want to delete : ");
            string choice = Console.ReadLine().ToUpper();

            string statement2 = ("delete from Cars Where regNumber = '" + choice + "'" + "\n");
            SQL.sqlconnection(statement2);
            Console.WriteLine("\n Car has been erased!");
            Console.WriteLine("\n Returning to main menu...");
            Thread.Sleep(3000);
        }

        //Update Car
        public void updateCar()
        {
            Console.Clear();
            string input1, input2 = "", column = "";
            Console.WriteLine("\n Update car");
            Console.WriteLine("___________________");
            Console.Write("\n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n Update Cars");
            Console.WriteLine("___________________");
            SQL.selectCustomers("select * from Customer Where pNumber =" + input1 + "\n");
            SQL.selectCars("select * from Cars where customerID =" + input1);
            Console.Write("\n Type the registration number of the car you want to update : ");
            string choice = Console.ReadLine().ToUpper();

            Console.Clear();
            Console.WriteLine("\n Update car");
            Console.WriteLine("___________________");
            Console.WriteLine("\n 1. Brand");
            Console.WriteLine(" 2. Model");
            Console.WriteLine(" 3. Registration Date");
            Console.WriteLine(" 4. Registration Number");
            Console.WriteLine(" 5. Age");
            Console.WriteLine(" 6. Fueltype");
            Console.WriteLine(" 7. Miles");
            Console.Write("\n What information do you want to update : ");
            string choice1 = Console.ReadLine();

            switch (choice1)
            {
                case "1":
                    {
                        do
                        {
                            Console.Clear();
                            check = "OK";
                            Console.WriteLine("\n Update car");
                            Console.WriteLine("___________________");
                            Console.Write("\n Input new brand name : ");
                            input2 = Console.ReadLine().ToUpper();
                            if (!SQL.inputCheck(input2, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNM", 50))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "brand";
                        break;
                    }
                case "2":
                    {
                        do
                        {
                            Console.Clear();
                            check = "OK";
                            Console.WriteLine("\n Update car");
                            Console.WriteLine("___________________");
                            Console.Write("\n Type new model : ");
                            input2 = Console.ReadLine().ToUpper();
                            if (!SQL.inputCheck(input2, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNM0123456789- ", 50))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "model";
                        break;
                    }
                case "3":
                    {
                        do
                        {
                            Console.Clear();
                            check = "OK";
                            Console.WriteLine("\n Update car");
                            Console.WriteLine("___________________");
                            Console.Write("\n Type new registration date dd-mm-yyyy : ");
                            input2 = Console.ReadLine();
                            if (!SQL.inputCheck(input2, "0123456789-", 10))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "carDate";
                        break;
                    }
                case "4":
                    {
                        do
                        {
                            Console.Clear();
                            check = "OK";
                            Console.WriteLine("\n Update car");
                            Console.WriteLine("___________________");
                            Console.Write("\n Type new registration number : ");
                            input2 = Console.ReadLine().ToUpper();
                            if (!SQL.inputCheck(input2, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNM0123456789 ", 50))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "regNumber";
                        break;
                    }
                case "5":
                    {
                        do
                        {
                            Console.Clear();
                            check = "OK";
                            Console.WriteLine("\n Update car");
                            Console.WriteLine("___________________");
                            Console.Write("\n Type new age : ");
                            input2 = Console.ReadLine();
                            if (!SQL.inputCheck(input2, "0123456789", 4))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "age";
                        break;
                    }
                case "6":
                    {
                        do
                        {
                            Console.Clear();
                            check = "OK";
                            Console.WriteLine("\n Update car");
                            Console.WriteLine("___________________");
                            Console.Write("\n Type new fueltype : ");
                            input2 = Console.ReadLine().ToUpper();
                            if (!SQL.inputCheck(input2, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNM", 50))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "fuelType";
                        break;
                    }
                case "7":
                    {
                        do
                        {
                            Console.Clear();
                            check = "OK";
                            Console.WriteLine("\n Update car");
                            Console.WriteLine("___________________");
                            Console.Write("\n Type new miles : ");
                            input2 = Console.ReadLine();
                            if (!SQL.inputCheck(input2, "0123456789", 7))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "miles";
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
                Console.WriteLine("\n Registration number already exists!");
                Console.ReadKey();
            }

            Console.WriteLine("\n Returning to main menu...");
            Thread.Sleep(3000);
        }

        //Create Appointment
        public void createAppointment()
        {
            Console.Clear();
            string input;
            Console.WriteLine("\n Create appointments");
            Console.WriteLine("___________________");
            Console.Write("\n Type Phone Number of a Customer : ");
            input = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n Create appointments");
            Console.WriteLine("___________________");
            SQL.selectCustomers("select * from Customer Where pNumber =" + input + "\n");
            Thread.Sleep(100);
            Console.WriteLine("\n Car information");
            SQL.selectCars("select * from Cars where customerID =" + input);
            string choice;

            do
            {
                check = "OK";
                Console.Write("\n Type the registration number of the car you want to create an appointment for : ");
                choice = Console.ReadLine().ToUpper();
                if (!SQL.inputCheck(choice, "0123456789QWERTYUIOPÅASDFGHJKLÆØZXCVBNM -", 10))
                    check = "not OK";
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create appointments");
                Console.WriteLine("___________________");
                Console.Write("\n Input the arrival date : ");
                arrivalDate = Console.ReadLine();
                if (!SQL.inputCheck(arrivalDate, "0123456789-", 50))
                    check = "not OK";
            }
            while (check == "not OK");

            do
            {
                Console.Clear();
                check = "OK";
                Console.WriteLine("\n Create appointments");
                Console.WriteLine("___________________");
                Console.Write("\n Input the leaving date : ");
                leavingDate = Console.ReadLine();
                if (!SQL.inputCheck(leavingDate, "0123456789-", 50))
                    check = "not OK";
            }
            while (check == "not OK");

            string statement = "insert into carAppointments values ('" + arrivalDate + "','" + leavingDate + "','" + choice + "')";
            SQL.sqlconnection(statement);

            Console.WriteLine("\n Appointment made!");
            Console.WriteLine("\n Returning to main menu...");
            Thread.Sleep(3000);
        }

        //Show Appointments
        public void showAppointments()
        {
            Console.Clear();
            string input;
            Console.WriteLine("\n Show appointments");
            Console.WriteLine("___________________");
            Console.Write("\n Type Phone Number of a Customer : ");
            input = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n Show appointments");
            Console.WriteLine("___________________");
            SQL.selectCustomers("select * from Customer Where pNumber =" + input + "\n");
            Console.WriteLine("\n Cars belonging to this customer:");
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
            Console.WriteLine("\n Update appointments");
            Console.WriteLine("___________________");
            Console.Write("\n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n Update appointments");
            Console.WriteLine("___________________");
            SQL.selectCars("select * from Cars where customerID =" + input1);
            Console.Write("\n Type the registration number of the car whose appointments you want to edit : ");
            string choice1 = Console.ReadLine().ToUpper();
            SQL.selectAppointments("select * from carAppointments Where carID = '" + choice1 + "' order by id");
            Console.WriteLine("\n 1. Arrival date");
            Console.WriteLine(" 2. Leaving date");
            Console.WriteLine(" 3. Car ID\n");
            Console.Write("\n What information do you want to update? : ");
            string choice2 = Console.ReadLine();

            switch (choice2)
            {
                case "1":
                    {
                        do
                        {
                            check = "OK";
                            Console.Write("\n Input new arrival date : ");
                            input2 = Console.ReadLine();
                            if (!SQL.inputCheck(input2, "0123456789-", 10))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "arrivalDate";
                        break;
                    }
                case "2":
                    {
                        do
                        {
                            check = "OK";
                            Console.Write("\n Input new leaving date : ");
                            input2 = Console.ReadLine();
                            if (!SQL.inputCheck(input2, "0123456789-", 10))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "leavingDate";
                        break;
                    }
                case "3":
                    {
                        do
                        {
                            check = "OK";
                            Console.Write("\n Input new car id : ");
                            input2 = Console.ReadLine();
                            if (!SQL.inputCheck(input2, "0123456789QWERTYUIOPÅASDFGHJKLÆØZXCVBNM ", 50))
                                check = "not OK";
                        }
                        while (check == "not OK");
                        column = "carID";
                        break;
                    }
            }
            string statement = ("update carAppointments set " + column + " = " + "'" + input2 + "'" + " where carID = '" + choice1 + "'");
            SQL.sqlconnection(statement);
            Console.WriteLine("\n Appointment info updated!");
            Console.WriteLine("\n Returning to main menu...");
            Thread.Sleep(3000);
        }

        //Delete Appointments
        public void deleteAppointment()
        {
            Console.Clear();
            string input1 = "";
            Console.WriteLine("\n Delete appointments");
            Console.WriteLine("___________________");
            Console.Write("\n Type Phone Number of a Customer : ");
            input1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n Delete appointments");
            Console.WriteLine("___________________");
            SQL.selectCars("select * from Cars where customerID =" + input1);
            Console.Write("\n Type the registration number of the car whose appointments you want to delete : ");
            string choice1 = Console.ReadLine().ToUpper();
            SQL.selectAppointments("select * from carAppointments Where carID = '" + choice1 + "' order by id");
            Console.Write("\n Select the id of the appointment you wish to delete : ");
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
            Console.WriteLine("\n Returning to main menu...");

            Thread.Sleep(3000);
        }
    }
}
