﻿#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EjercicioModulo3Clase2.Domain.Entities;

namespace EjercicioModulo3Clase2.Repository
{
    public partial class ToDoListDBContext : DbContext
    {
        public ToDoListDBContext()
        {
        }

        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Tasks> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.ToTable("tasks");

                entity.Property(e => e.Id).HasColumnName("id");


                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DueDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("due_date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsCompleted).HasColumnName("is_completed");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}