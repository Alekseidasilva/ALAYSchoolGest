using ALAYSchoolGest.Domain.Entities;
using FluentAssertions;

namespace ALAYSchoolGest.Tests._03_Domain.Entities;


[Collection(nameof(UserTestFixture))]
public class UserTest
{
    #region Variables
    private readonly UserTestFixture _userTestFixture;
    #endregion
    #region Builders
    public UserTest(UserTestFixture userTestFixture) => _userTestFixture = userTestFixture;

    #endregion

    #region InstantiateWithoutPassword
    [Fact(DisplayName = nameof(InstantiateWithEmail))]
    [Trait("Domain", "Entities - User")]
    public void InstantiateWithEmail()
    {
        #region Arrange
        //Arrange
        var validUser = _userTestFixture.GetValidUserWithEmail();
        #endregion
        #region Act
        //Act
        var user = new User(validUser.Email);
    
        #endregion
        #region Assert
        //Assert
        Assert.IsType<Guid>(user.Id);
        Assert.Equal(user.Email,user.Name);
        Assert.NotNull(user.Email.Address);
        Assert.NotEmpty(user.Password.Hash);
        Assert.Empty(user.Image);

        #endregion
    }
    #endregion
    #region InstantiateWithEmailAndPassword
    [Fact(DisplayName = nameof(InstantiateWithEmailAndPassword))]
    [Trait("Domain", "Entities - User")]
    public void InstantiateWithEmailAndPassword()
    {
        #region Arrange
        //Arrange
        var validUser = _userTestFixture.GetValidUserWithEmailAndPassword();
        #endregion
        #region Act
        //Act
        var user = new User(validUser.Name,validUser.Email,validUser.Password);

        #endregion
        #region Assert
        //Assert
        Assert.IsType<Guid>(user.Id);
        Assert.NotNull(user.Name);
        Assert.NotNull(user.Email.Address);
        Assert.NotEmpty(user.Password.Hash);
        Assert.Empty(user.Image);
        #endregion
    }
    #endregion

    #region InstantiateErrorWhenEmailIsEmpty
    [Theory(DisplayName = nameof(InstantiateErrorWhenEmailIsEmpty))]
    [Trait("Domain", "Entities - User")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    public void InstantiateErrorWhenEmailIsEmpty(string? email)
    {
        var validUser = _userTestFixture.GetValidUserWithEmail();
        Action action =
            () => new User(email);

        action.Should()
            .Throw<EntityValidationException>()
            .WithMessage("Name Should not be empty or null");
    }
    #endregion

}