
namespace CS03_LiskovSubstitutionPrinciple.Services.Case;
public class ContractualEmployee : Employee
{
    public override string GetProjectDetails(int employeeId)
    {
        Console.WriteLine("Child ContractualEmployee Project");
        return "Child ContractualEmployee Project";
    }
    // May be for contractual employee we do not need to store the details into database.
    public override string GetEmployeeDetails(int employeeId)
    {
        throw new NotImplementedException();
    }
}