﻿

using Microsoft.EntityFrameworkCore;


namespace CrudOp.Models
{
    public class ApplicationDbContext:DbContext
    {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }   
    }
}
