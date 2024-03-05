namespace ALAYSchoolGest.Tests._03_Domain.Entities;

private readonly UserTestFixture _userTestFixture;

[Collection(nameof(UserTestFixture))]
public class UserTest
{
    #region Instantiate
    [Fact(DisplayName = nameof(Instantiate))]
    [Trait("Domain", "Entities - User")]
    public void Instantiate()
    {
        #region Arrange
        //Arrange
        var validUser = _categoryTestFixture.GetValidCategory();

        var datetimebefore = DateTime.Now;
        #endregion
        #region Act
        //Act
        var category = new DomainEntity.Category(validUser.Name, validUser.Description);
        var datetimeAfter = DateTime.Now.AddSeconds(1);
        #endregion
        #region Assert
        //Assert
        category.Should().NotBeNull();
        category.Name.Should().Be(validUser.Name);
        category.Description.Should().Be(validUser.Description);
        category.Id.Should().NotBeEmpty();
        category.CreatedAt.Should().NotBeSameDateAs(default(DateTime));
        (category.CreatedAt >= datetimebefore).Should().BeTrue();
        (category.CreatedAt <= datetimeAfter).Should().BeTrue();
        (category.IsActive).Should().BeTrue();
        #endregion
    }
    #endregion

}