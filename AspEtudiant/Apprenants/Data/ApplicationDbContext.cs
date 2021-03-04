using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Apprenants.Models;

namespace Apprenants.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Apprenants.Models.Etudiants> Etudiants { get; set; }

        private DbSet<Roles> roles;

        public DbSet<Roles> GetRoles()
        {
            return roles;
        }

        public void SetRoles(DbSet<Roles> value)
        {
            roles = value;
        }
    }
}
