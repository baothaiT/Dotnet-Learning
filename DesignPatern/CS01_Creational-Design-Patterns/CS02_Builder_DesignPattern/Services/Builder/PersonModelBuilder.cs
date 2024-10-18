
using CS02_Builder_DesignPattern.Models;

namespace CS02_Builder_DesignPattern.Sevices.Builder;

public class PersonModelBuilder
{
    private PersonModel _personModel;

    public PersonModelBuilder()
    {
        _personModel = new PersonModel();
    }
    public PersonModelBuilder AddId(string id)
    {
        _personModel.Id = id;
        return this;
    }
    public PersonModelBuilder AddName(string name)
    {
        _personModel.Name = name;
        return this;
    }
    public PersonModelBuilder AddEmail(string email)
    {
         _personModel.Email = email;
         return this;
    }
    public PersonModelBuilder AddPhone(string phone)
    {
        _personModel.Phone = phone;
        return this;
    }
    public PersonModel Build()
    {
        return _personModel;
    }
}