﻿using ALAYSchoolGest.Domain.Entities.ValueObjects;
using ALAYSchoolGest.Domain.Shared;
using ALAYSchoolGest.Domain.UseCases.User.ValueObjects;

namespace ALAYSchoolGest.Domain.Entities;

public class User : EntityBase
{
    #region Constructor
    protected User() { }

    public User(string name, string email, Password password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
    public User(string email, string? password = null)
    {
        Email = email;
        Password = new Password(password);
    }

    #endregion
    #region Property
    public string Name { get; private set; } = string.Empty;
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
    public string Image { get; private set; } = string.Empty;


    //public List<Role> Roles { get; set; } = new();
    #endregion
    #region Methods
    public void UpdatePassword(string plainTextPassword, string code)
    {
        if (!string.Equals(code.Trim(), Password.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
            throw new Exception("Código de restauração invãido");

        var password = new Password(plainTextPassword);
        Password = password;
    }

    public void UpdateEmail(Email email) => Email = email;

    public void ChangePassword(string plainTextPassword)
    {
        var password = new Password(plainTextPassword);
        Password = password;
    }
    #endregion
}