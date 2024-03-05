using ALAYSchoolGest.Domain.Entities;
using ALAYSchoolGest.Domain.UseCases.Users.ValueObjects;
using ALAYSchoolGest.Tests.Common;

namespace ALAYSchoolGest.Tests._03_Domain.Entities;

public class UserTestFixture: BaseFixture
{
    [CollectionDefinition(nameof(UserTestFixture))]
    public class UserFixtureCollection
        : ICollectionFixture<UserTestFixture>
    { }
    
    public UserTestFixture()
        : base() { }

    public string GetValidUserName()
    {
        var userName = String.Empty;
        while (userName.Length < 3)
            userName = faker.Person.UserName;
        if (userName.Length > 255)
            userName = userName.Substring(0, 255);
        return userName;
    }
    public Password GetValidPassword()
    {
        var password = String.Empty;
        while (password.Length < 3)
            password = faker.Person.Email+faker.Person.UserName;
        if (password.Length > 255)
            password = password.Substring(0, 255);
        //categoryName = categoryName[255];
        var newPassword =new Password(password);



        return newPassword!;
    }
    public string GetValidCategoryDescription()
    {
        var categoryDescription = String.Empty;
        categoryDescription = faker.Commerce.ProductDescription();
        if (categoryDescription.Length > 10_000)
            categoryDescription = categoryDescription.Substring(0, 10_000);

        return categoryDescription;
    }






    public string GetValidEmail()
    {
        var email = String.Empty;
        while (email.Length < 3)
            email = faker.Person.Email;
        if (email.Length > 255)
            email = email.Substring(0, 255);
        //categoryName = categoryName[255];
        return email;
    }




    public User GetValidUserWithEmail()
        => new(GetValidEmail());

    public User GetValidUserWithEmailAndPassword()
    {
        return new User(GetValidUserName(), GetValidEmail(), GetValidPassword());
    }

}