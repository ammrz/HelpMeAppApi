using HelpMeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Infrastructure.Context
{
    public class HelpMeAppDbContext : DbContext
    {
        public HelpMeAppDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public HelpMeAppDbContext()
        {
        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<HelpMeApp.Domain.Entities.Domain> Domains { get; set; }
    }
}
