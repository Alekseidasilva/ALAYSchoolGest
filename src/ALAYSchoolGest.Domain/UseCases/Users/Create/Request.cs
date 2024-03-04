using MediatR;
namespace ALAYSchoolGest.Domain.UseCases.Users.Create;


    public record Request(
        string Name,
        string Email,
        string Password) : IRequest<Response>;
