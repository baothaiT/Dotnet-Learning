
namespace CS03_LiskovSubstitutionPrinciple.Services.Case;

public class CasualEmployee : Employee
{
    public override string GetProjectDetails(int employeeId)
    {
        Console.WriteLine("Child CasualEmployee Project");
        return "Child CasualEmployee Project";
    }
    // May be for contractual employee we do not need to store the details into database.
    public override string GetEmployeeDetails(int employeeId)
    {
        return "Child CasualEmployee Employee";
    }
}