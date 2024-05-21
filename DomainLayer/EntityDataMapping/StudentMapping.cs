using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityDataMapping
{
    public static class StudentMapping
    {
        public static void StudentMappingModelCreation(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Student>();
            entity.ToTable("tblStudent").HasKey("Id").HasName("StudentId");

            entity.Property(p => p.Id).HasColumnName("StudentId").UseIdentityColumn();
            entity.Property(p => p.Name).HasColumnName("Name");
            entity.Property(p => p.Address).HasColumnName("Address");
            entity.Property(p => p.Country).HasColumnName("Country");
        }
    }
}
