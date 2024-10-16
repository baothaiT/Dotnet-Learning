
namespace CS03_LiskovSubstitutionPrinciple.Services.Solution;

public class CasualEmployee_Solution: IEmployee, IProject
{
    public string GetProjectDetails(int employeeId)
    {
        Console.WriteLine("Child CasualEmployee Project");
        return "Child CasualEmployee Project";
    }
    public string GetEmployeeDetails(int employeeId)
    {
        return "Child CasualEmployee Employee";
    }
}