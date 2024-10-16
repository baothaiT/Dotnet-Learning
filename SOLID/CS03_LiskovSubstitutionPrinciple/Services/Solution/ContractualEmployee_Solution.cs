
namespace CS03_LiskovSubstitutionPrinciple.Services.Solution;

public class ContractualEmployee_Solution:  IProject
{
    public string GetProjectDetails(int employeeId)
    {
        Console.WriteLine("Child CasualEmployee Project");
        return "Child CasualEmployee Project";
    }
}