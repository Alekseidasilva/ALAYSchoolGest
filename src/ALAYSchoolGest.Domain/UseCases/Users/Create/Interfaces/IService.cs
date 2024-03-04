
namespace ALAYSchoolGest.Domain.UseCases.Users.Create.Interfaces;

public interface IService
{
    Task SendVerificationEmailAsync(Entities.User user, CancellationToken cancellationToken);
}