using Bogus;

namespace ALAYSchoolGest.Tests.Common;

public class BaseFixture
{
    public Faker faker { get; set; }
    protected BaseFixture()=> faker = new Faker("pt_PT");

}