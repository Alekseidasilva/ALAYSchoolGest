using ALAYSchoolGest.Domain.Entities;
using ALAYSchoolGest.Domain.UseCases.Users.Create.Interfaces;
using ALAYSchoolGest.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ALAYSchoolGest.Infra.UseCases.Users;

public class Repository:IRepository
{
    #region Variables
    private readonly AppDbContext _context;
    #endregion
    #region Constructs
    public Repository(AppDbContext context) => _context = context;
    #endregion
    #region Methods
    public async Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .AsNoTracking()
            .AnyAsync(x => x.Email.Address == email, cancellationToken);
    }
    public async Task SaveAsync(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
    #endregion

}