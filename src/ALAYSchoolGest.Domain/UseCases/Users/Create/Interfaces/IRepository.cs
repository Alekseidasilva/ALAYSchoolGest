namespace ALAYSchoolGest.Domain.UseCases.Users.Create.Interfaces;

public interface IRepository
{
    Task<bool> AnyAsync(string email, CancellationToken cancellationToken);
    Task SaveAsync(Entities.User user, CancellationToken cancellationToken);
}