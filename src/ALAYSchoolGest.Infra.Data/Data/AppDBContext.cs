﻿using ALAYSchoolGest.Domain.Entities;
using ALAYSchoolGest.Infra.UseCases.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ALAYSchoolGest.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        //modelBuilder.ApplyConfiguration(new RoleMap());
    }
}