using CS03_LiskovSubstitutionPrinciple.Services.Case;
using CS03_LiskovSubstitutionPrinciple.Services.Solution;


namespace CS03_LiskovSubstitutionPrinciple;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("CS03_LiskovSubstitutionPrinciple");

        // #region Case 
        // List<Employee> employeeList = new List<Employee>();
        // employeeList.Add(new ContractualEmployee());
        // employeeList.Add(new CasualEmployee());
        // foreach (Employee e in employeeList)
        // {
        //     e.GetEmployeeDetails(1245);
        //     // e.GetProjectDetails(123);
        // }
        // #endregion

        #region Solution with Liskov Substitution Principle

        CasualEmployee_Solution casualEmployee_Solution = new CasualEmployee_Solution();
        casualEmployee_Solution.GetEmployeeDetails(123);

        ContractualEmployee_Solution contractualEmployee_Solution = new ContractualEmployee_Solution();
        

        #endregion
    }
}
