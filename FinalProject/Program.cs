using System;
using System.Collections.Generic;

namespace FinalProject
{
    class Program
    {
        private static bool validInput = true;
        private static bool runProgram = true;
        //Employee details for validation
        private static string name;
        private static string address;
        private static string position;
        private static string phoneNumber;
        private static DateTime startDate;
        private static string email;
        //Tree
        private static BST employeeTree = new BST();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User!");
            string userInput = "";
            while (runProgram)
            {
                Console.WriteLine("Please input the integer that correlates to the action you would like to perform");
                Console.WriteLine("1 - Add a new employee");
                Console.WriteLine("2 - View employees");
                Console.WriteLine("3 - Edit an employee");
                Console.WriteLine("4 - Delete an employee");
                userInput = Console.ReadLine();
                //Add a new employee to the tree
                if (userInput.Equals("1"))
                {
                    addNewEmployee();
                }
                else if(userInput.Equals("2"))
                {
                    viewEmployees();
                }
                else if(userInput.Equals("3"))
                {
                    if (employeeTree.Root == null)
                        Console.WriteLine("Please add a user first");
                    else
                        editEmployees();
                }
                else if(userInput.Equals("4"))
                {
                    if (employeeTree.Root == null)
                        Console.WriteLine("Please add a user first");
                    else
                        deleteEmployee();
                }
                Console.WriteLine();
                
            }

        }

        private static bool validateInput(String input)
        {
            input = input.Trim();
            if (input.Equals("1") || input.Equals("2") || input.Equals("3"))
            {
                return true;
            }
            return false;
        }

        private static bool validateName()
        {
            name = name.ToLower();
            if (name.Equals(""))
                return false;
            for (int i = 0; i < name.Length; i++)
            {
                if ((name[i] < 97 || name[i] > 122) && name[i] != ' ')
                    return false;
            }
            return true;
        }
        private static bool formatNumber(string number)
        {
            number = number.Trim();
            if (number.Equals(""))
                return false;
            if (number.Length != 10)
                return false;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] < 48 || number[i] > 57)
                    return false;
            }
            phoneNumber = number;
            return true;
        }

        private static DateTime convertStringToDate(string date)
        {
            try
            {
                date = date.Trim();
                date = date.Replace('/', ' ');
                date = date.Replace('-', ' ');
                date = date.Replace('_', ' ');
                return DateTime.Parse(date);
            } catch(Exception ex) {
                Console.WriteLine("Invalid date format, please fix date in edit");
            }
            return DateTime.Parse("01 01 1971");
        }

        private static bool validateEmail(string emailAddress)
        {
            emailAddress = emailAddress.Trim();
            if (emailAddress.Equals(""))
                return false;
            if (!emailAddress.Contains('@'))
                return false;
            if (!emailAddress.Substring(emailAddress.Length - 4, 4).Equals(".com"))
                return false;
            email = emailAddress;
            return true;

        }

        private static void addNewEmployee()
        {
            Console.WriteLine("Please enter the employee's name");
            name = Console.ReadLine();
            if (!validateName())
            {
                Console.WriteLine("Invalid name, a name must only conatin letters");
                return;
            }
            Console.WriteLine("Please enter the employee's phone number");
            if (!formatNumber(Console.ReadLine()))
            {
                Console.WriteLine("Invalid phone number, a number must only conatin 10 numerics");
                return;
            }
            Console.WriteLine("Please enter the employee's email");
            if (!validateEmail(Console.ReadLine()))
            {
                Console.WriteLine("Invalid email, please enter a valid email address");
                return;
            }
            Console.WriteLine("Please enter the employee's address");
            address = Console.ReadLine();
            Console.WriteLine("Please enter the employee's position");
            position = Console.ReadLine();
            Console.WriteLine("Please enter the employee's start date");
            startDate = convertStringToDate(Console.ReadLine());
            Employee emp = new Employee(name, email, phoneNumber, position, address, startDate);
            employeeTree.Add(emp);
            Console.WriteLine(name + " was added successfully");
            Console.WriteLine();
        }

        private static void viewEmployees()
        {
            Console.WriteLine("Name                                            Email                                              Position");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            employeeTree.TraverseInOrder(employeeTree.Root);
            Console.WriteLine();

        }

        private static void editEmployees()
        {
            Console.WriteLine("Please enter the employee's email that you would like to edit");
            email = Console.ReadLine();
            Node editEmp = employeeTree.Find(email.Trim());
            if (editEmp != null)
            {
                Console.WriteLine("Please enter the employee's name");
                name = Console.ReadLine();
                if (!validateName())
                {
                    Console.WriteLine("Invalid name, a name must only conatin letters");
                    return;
                }
                editEmp.Data.name = name;
                Console.WriteLine("Please enter the employee's phone number");
                if (!formatNumber(Console.ReadLine()))
                {
                    Console.WriteLine("Invalid phone number, a number must only conatin 10 numerics");
                    return;
                }
                editEmp.Data.phoneNumber = phoneNumber;
                Console.WriteLine("Please enter the employee's email");
                if (!validateEmail(Console.ReadLine()))
                {
                    Console.WriteLine("Invalid email, please enter a valid email address");
                    return;
                }
                editEmp.Data.email = email;
                Console.WriteLine("Please enter the employee's address");
                editEmp.Data.name = address = Console.ReadLine();
                Console.WriteLine("Please enter the employee's position");
                editEmp.Data.name = position = Console.ReadLine();
                Console.WriteLine("Please enter the employee's start date");
                editEmp.Data.startDate = convertStringToDate(Console.ReadLine());
                Console.WriteLine(name + " was modified successfully");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Could not find user.");
                Console.WriteLine();
            }
        }

        public static void deleteEmployee()
        {
            Console.WriteLine("Please enter the employee's email that you would like to delete");
            email = Console.ReadLine();
            Node deleteEmp = employeeTree.Find(email.Trim());
            if (deleteEmp != null)
            {
                Console.WriteLine("Are you sure you would like to delete " + deleteEmp.Data.name + " from the system? (Y for Yes, Anything else for No");
                String decision = Console.ReadLine();
                if (decision.Trim().ToLower().Equals("y") || decision.Trim().ToLower().Equals("yes"))
                {
                    employeeTree.Remove(deleteEmp.Data);
                    Console.WriteLine("User successfully deleted");
                    Console.WriteLine();
                }
            }
        }
    }
}
