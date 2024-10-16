

namespace CS04_InterfaceSegregationPrinciple.Services.Case;
public class EmployeeDatabase_Case: IEmployeeDatabase_Case
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