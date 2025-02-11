using Labb3_Serhan_Gyuler_SUT24.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Labb3_Serhan_Gyuler_SUT24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MENU
            var loop = true;

            while (loop)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("Choose one of the options below by entering a number:");
                Console.WriteLine("========================================");
                Console.WriteLine("1. View students and sort");
                Console.WriteLine("2. View students in specific class");
                Console.WriteLine("3. Add new employee");
                Console.WriteLine("4. Exit");
                Console.WriteLine("========================================");
                Console.Write("Enter your choice: ");

                var userChoice = Console.ReadLine();

                // CASES
                switch (userChoice)
                {
                    case "1":
                        CallAllStudentsSortOption();
                        break;
                    case "2":
                        CallOutStudentsInSpecificClass();
                        break;
                    case "3":
                        AddNewEmployee();
                        break;
                    case "4":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        Console.ReadKey();
                        break;
                }
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Function 1
        public static void CallAllStudentsSortOption()
        {
            using (var dBManager = new SchoolDbContext())
            {
                try
                {
                    // Call out students
                    Console.WriteLine("Do you want to sort students by FirstName or LastName?: ");
                    var UserChooseSortingStudents = Console.ReadLine()?.ToLower();

                    Console.WriteLine("Do you want to sort students by Falling or Rising order?: ");
                    var UserChooseSortingStudentsByOrder = Console.ReadLine()?.ToLower();

                    IOrderedQueryable<Student> query = null;

                    if (UserChooseSortingStudents == "firstname")
                    {
                        if (UserChooseSortingStudentsByOrder == "falling")
                        {
                            query = dBManager.Students.OrderByDescending(s => s.FirstName);
                        }
                        else if (UserChooseSortingStudentsByOrder == "rising")
                        {
                            query = dBManager.Students.OrderBy(s => s.FirstName);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input");
                            return;
                        }
                    }
                    else if (UserChooseSortingStudents == "lastname")
                    {
                        if (UserChooseSortingStudentsByOrder == "falling")
                        {
                            query = dBManager.Students.OrderByDescending(s => s.LastName);
                        }
                        else if (UserChooseSortingStudentsByOrder == "rising")
                        {
                            query = dBManager.Students.OrderBy(s => s.LastName);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input for sorting students.");
                        return;
                    }

                    var students = query.ToList();

                    Console.WriteLine("========================================");
                    Console.WriteLine("Sorted students:");
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // Function 2
        public static void CallOutStudentsInSpecificClass()
        {
            using (var dBManager = new SchoolDbContext())
            {
                try
                {
                    //Call all students in a specific class
                    var Classes = dBManager.Classes.ToList();

                    foreach (var Class in Classes)
                    {
                        Console.WriteLine($"Class ID: {Class.ClassId}, Class Name: {Class.ClassName}");

                    }

                    Console.WriteLine("Choose a class by the classId to see the students inside the class");
                    var choosenClassByUser = Convert.ToInt32(Console.ReadLine());

                    //Call a specific class
                    var SpecificClass = dBManager.Classes.FirstOrDefault(c => c.ClassId == choosenClassByUser);
                    if (SpecificClass != null)
                    {

                        var studentsInSpecificClass = dBManager.Students.Where(s => s.ClassId == SpecificClass.ClassId);
                        foreach (var student in studentsInSpecificClass)
                        {
                            Console.WriteLine($"{student.FirstName} {student.LastName} - SSN: {student.SocialSecurityNumber}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Class not found");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // Function 3
        public static void AddNewEmployee()
        {
            using (var dBManager = new SchoolDbContext())
            {
                try
                {
                    Console.WriteLine("Enter First name: ");
                    var firstName = Console.ReadLine();

                    Console.WriteLine("Enter Last name: ");
                    var lastName = Console.ReadLine();

                    Console.WriteLine("Enter profession: ");
                    var profession = Console.ReadLine();

                    // Skapa ny medlem
                    var newEmployee = new Employee
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Profession = profession
                    };

                    // Lägg till i context och spara
                    dBManager.Employees.Add(newEmployee);
                    dBManager.SaveChanges();
                    Console.WriteLine($"Employee {firstName} {lastName} was added to employee");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}















