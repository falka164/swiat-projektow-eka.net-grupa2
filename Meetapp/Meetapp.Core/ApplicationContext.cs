using System;
using System.Collections.Generic;
using System.Text;
using Meetapp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetapp.Core
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        public DbSet<Event> Events { get; set; }

    }
}
