using Labb3_Serhan_Gyuler_SUT24.Models;
using Microsoft.Data.SqlClient;

namespace Labb3_Serhan_Gyuler_SUT24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var dBManager = new SchoolDbContext())
            {
                /*
                 Call out students
                Console.WriteLine("Do you want to sort students by FirstName or LastName?: ");
                string UserChooseSortingStudents = Console.ReadLine();

                Console.WriteLine("Do you want to sort students by Falling or Rising order?: ");
                string UserChooseSortingStudentsByOrder = Console.ReadLine();

                IOrderedQueryable<Student> query = null;

                if (UserChooseSortingStudents == "FirstName")
                {
                    if (UserChooseSortingStudentsByOrder == "Falling")
                    {
                        query = dBManager.Students.OrderByDescending(s => s.FirstName);
                    }
                    else if (UserChooseSortingStudentsByOrder == "Rising")
                    {
                        query = dBManager.Students.OrderBy(s => s.FirstName);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input for sorting order.");
                        return;
                    }
                }
                else if (UserChooseSortingStudents == "LastName")
                {
                    if (UserChooseSortingStudentsByOrder == "Falling")
                    {
                        query = dBManager.Students.OrderByDescending(s => s.LastName);
                    }
                    else if (UserChooseSortingStudentsByOrder == "Rising")
                    {
                        query = dBManager.Students.OrderBy(s => s.LastName);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input for sorting order.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input for sorting by FirstName or LastName.");
                    return;
                }

                var students = query.ToList();

                foreach (var student in students)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}");
                }
                */

                /*// Call all students i a specific class
                var Classes = dBManager.Classes.ToList();

                foreach (var Class in Classes)
                {
                    Console.WriteLine($"Class ID: {Class.ClassId}, Class Name: {Class.ClassName}");

                }

                Console.WriteLine("Choose a class by the classId to see the students inside the class");
                int choosenClassByUser = Convert.ToInt32(Console.ReadLine()); 

                 Call a specific class
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
                */

                //Add new employee
                var newEmployee = new Employee
                {
                    FirstName = "Tommy",
                    LastName = "Ghost",
                    Profession = "Unemployed"
                };

                //Lägg till i context och spara
                dBManager.Employees.Add(newEmployee);
                dBManager.SaveChanges();


            }

        }
    }
}
