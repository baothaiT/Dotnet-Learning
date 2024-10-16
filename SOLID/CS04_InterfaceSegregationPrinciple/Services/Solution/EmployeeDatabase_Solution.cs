

namespace CS04_InterfaceSegregationPrinciple.Services.Solution;
public class EmployeeDatabase_Solution: IAddOperation_Solution, IGetOperation_Solution
{
    public void AddEmployeeDetails()
    {
        Console.WriteLine("AddEmployeeDetails");
    }
    public void ShowEmployeeDetails(int employeeId)
    {
        Console.WriteLine($"AddEmployeeDetails {employeeId}");
    }
}