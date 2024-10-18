
namespace CS02_Builder_DesignPattern.Models;

public class PersonModel
{
    public string Id { get;set; }
    public string Name { get;set; }
    public string Email { get;set; }
    public string Phone { get;set; }
    public override string ToString()
    {
        return $"{ this.Id} : {this.Name} : {this.Email} : {this.Phone}";
    }
}