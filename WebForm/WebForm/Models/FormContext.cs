using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebForm.Models
{
    public class FormContext : DbContext
    {
        public DbSet<Form> Form { get; set; }
        public FormContext(DbContextOptions<FormContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
