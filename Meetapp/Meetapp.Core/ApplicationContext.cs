﻿using System;
using System.Collections.Generic;
using System.Text;
using Meetapp.Core.Entities;
using Meetapp.Core.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Meetapp.Core
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Event> Events { get; set; }

    }
}
