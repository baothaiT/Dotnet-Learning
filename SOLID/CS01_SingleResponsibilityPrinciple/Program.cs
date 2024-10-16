
namespace SingleResponsibilityPrinciple;

public class Program
{
    public static void Main(string[] args)
    {
        # region Wrong Case Use
        Console.WriteLine("Wrong Case Use");
        EmployeeWrong employeeWrong = new EmployeeWrong();
        employeeWrong.Name = "NameTest";
        employeeWrong.Email = "EmailTest";
        employeeWrong.Salary = 1000;

        var salary = employeeWrong.CalculateSalary();
        Console.WriteLine($"Salary: {salary}");

        employeeWrong.SendEmail();

        # endregion 

        #region Employment with Single Responsibility Principle
        Console.WriteLine("Employment with Single Responsibility Principle");
        Employee employee = new Employee
        {
            Name = "John Doe",
            Email = "john.doe@example.com",
            Salary = 5000
        };

        SalaryCalculator salaryCalculator = new SalaryCalculator();
        decimal newSalary = salaryCalculator.CalculateSalary(employee);
        Console.WriteLine($"New Salary: {newSalary}");

        EmailService emailService = new EmailService();
        emailService.SendEmail(employee);
            
        #endregion

    }
}

# region Wrong Case Implement

public class EmployeeWrong
{
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }

    // Responsibility 1: Employee data management
    public void AddEmployee()
    {
        // Code to add employee to the database
    }

    // Responsibility 2: Salary calculations
    public decimal CalculateSalary()
    {
        // Code to calculate salary
        return Salary * 1.1M;
    }

    // Responsibility 3: Email notification
    public void SendEmail()
    {
        // Code to send an email
        Console.WriteLine($"Email sent to {Email}");
    }
}

#endregion

// Class for managing employee data
public class Employee
{
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }

    // Now the Employee class only handles employee-related properties.
}

// Class for handling salary calculations
public class SalaryCalculator
{
    public decimal CalculateSalary(Employee employee)
    {
        // Responsibility: Calculate salary for the given employee
        return employee.Salary * 1.1M;
    }
}

// Class for handling email notifications
public class EmailService
{
    public void SendEmail(Employee employee)
    {
        // Responsibility: Send email to the employee
        Console.WriteLine($"Email sent to {employee.Email}");
    }
}

#region Case SingleResponsibilityPrinciple



#endregion