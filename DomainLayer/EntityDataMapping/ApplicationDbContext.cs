using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
namespace DomainLayer.EntityDataMapping
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Student> Students
        {
            get;
            set;
        }
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            StudentMapping.StudentMappingModelCreation(modelBuilder);
        }
    }
}