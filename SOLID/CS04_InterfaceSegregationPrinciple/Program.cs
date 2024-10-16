using CS04_InterfaceSegregationPrinciple.Services.Case;
using CS04_InterfaceSegregationPrinciple.Services.Solution;

namespace CS04_InterfaceSegregationPrinciple;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World! CS04_InterfaceSegregationPrinciple");

        #region Case
        Console.WriteLine("EmployeeDatabase_Case ----------");
        EmployeeDatabase_Case employeeDatabase_Case = new EmployeeDatabase_Case();
        employeeDatabase_Case.AddEmployeeDetails();
        employeeDatabase_Case.ShowEmployeeDetails(123);

        #endregion

        #region Solution with Interface SegregationPrinciple
        Console.WriteLine("EmployeeDatabase with Interface SegregationPrinciple----------"); 
        EmployeeDatabase_Solution employeeDatabase_Solution = new EmployeeDatabase_Solution();
        employeeDatabase_Solution.AddEmployeeDetails();
        employeeDatabase_Solution.ShowEmployeeDetails(123);

        #endregion
        
    }
}