using System;

public abstract class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Role { get; set; }
    public double Salary { get; set; }

    public Employee(string name, int age, string role)
    {
        Name = name;
        Age = age;
        Role = role;
    }

    public abstract double CalculateSalary(double rate, int time);
}

// ---------------------------------------

public class PartTimeEmployee : Employee
{
    public PartTimeEmployee(string name, int age, string role)
        : base(name, age, role) { }

    public override double CalculateSalary(double hourlyRate, int hoursPerWeek)
    {
        Salary = hourlyRate * hoursPerWeek * 4; // 4 أسابيع في الشهر
        return Salary;
    }
}

// ---------------------------------------

public class FullTimeEmployee : Employee
{
    public FullTimeEmployee(string name, int age, string role)
        : base(name, age, role) { }

    public override double CalculateSalary(double dailyRate, int daysPerMonth)
    {
        Salary = dailyRate * daysPerMonth;
        return Salary;
    }
}

// ---------------------------------------

class Program
{
    static Employee[] employees = new Employee[10];
    static int employeeCount = 0;

    static void RegisterDefaultEmployees()
    {
        // Part-time employees
        employees[employeeCount++] = new PartTimeEmployee("Sarah Johnson", 30, "Front-End Developer");
        employees[employeeCount++] = new PartTimeEmployee("Mark Thompson", 40, "Customer Support Specialist");
        employees[employeeCount++] = new PartTimeEmployee("Emily Chen", 35, "Content Writer");
        employees[employeeCount++] = new PartTimeEmployee("Robert Garcia", 27, "Graphic Designer");
        employees[employeeCount++] = new PartTimeEmployee("Lisa Patel", 32, "Social Media Manager");

        // Full-time employees
        employees[employeeCount++] = new FullTimeEmployee("David Miller", 38, "Software Engineer");
        employees[employeeCount++] = new FullTimeEmployee("Angela Robinson", 25, "Project Manager");
        employees[employeeCount++] = new FullTimeEmployee("John Smith", 44, "Quality Assurance Tester");
        employees[employeeCount++] = new FullTimeEmployee("Sophia Williams", 31, "UX/UI Designer");
        employees[employeeCount++] = new FullTimeEmployee("Michael Brown", 29, "DevOps Engineer");
    }

    static void Main()
    {
        RegisterDefaultEmployees(); // تسجيل الموظفين تلقائيًا

        while (true)
        {
            Console.WriteLine("\nTo register a new employee, press R.");
            Console.WriteLine("To calculate a salary, press C.");
            Console.WriteLine("To exit, press E.");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine().ToUpper();

            if (choice == "R")
            {
                if (employeeCount >= 10)
                {
                    Console.WriteLine("Maximum number of employees reached.");
                    continue;
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter Role: ");
                string role = Console.ReadLine();

                Console.Write("Enter Employment Type (part-time/full-time): ");
                string type = Console.ReadLine().ToLower();

                if (type == "part-time")
                {
                    employees[employeeCount++] = new PartTimeEmployee(name, age, role);
                }
                else if (type == "full-time")
                {
                    employees[employeeCount++] = new FullTimeEmployee(name, age, role);
                }
                else
                {
                    Console.WriteLine("Invalid type.");
                }
            }
            else if (choice == "C")
            {
                if (employeeCount == 0)
                {
                    Console.WriteLine("No employees registered yet.");
                    continue;
                }

                Console.Write("Enter employee name to calculate salary: ");
                string searchName = Console.ReadLine();
                bool found = false;

                foreach (Employee emp in employees)
                {
                    if (emp != null && emp.Name.ToLower() == searchName.ToLower())
                    {
                        found = true;

                        if (emp is PartTimeEmployee)
                        {
                            Console.Write("Enter hourly rate: ");
                            double rate = double.Parse(Console.ReadLine());

                            Console.Write("Enter hours worked per week: ");
                            int hours = int.Parse(Console.ReadLine());

                            double salary = emp.CalculateSalary(rate, hours);
                            Console.WriteLine($"Monthly salary for {emp.Name} is ${salary}");
                        }
                        else if (emp is FullTimeEmployee)
                        {
                            Console.Write("Enter daily rate: ");
                            double rate = double.Parse(Console.ReadLine());

                            Console.Write("Enter days worked this month: ");
                            int days = int.Parse(Console.ReadLine());

                            double salary = emp.CalculateSalary(rate, days);
                            Console.WriteLine($"Monthly salary for {emp.Name} is ${salary}");
                        }
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Not Found.");
                }
            }
            else if (choice == "E")
            {
                Console.WriteLine("Exiting the program...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
