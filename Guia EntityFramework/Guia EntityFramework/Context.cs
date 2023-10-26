using Microsoft.EntityFrameworkCore;
using Guia_EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Context : DbContext
{
    public DbSet<Student> Estudiantes { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-CA33S3F\\SQLEXPRESS;Database=Progra2;Trusted_Connection=True;");
    }
}

