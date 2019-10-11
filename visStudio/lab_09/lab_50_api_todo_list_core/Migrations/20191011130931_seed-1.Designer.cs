﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab_50_api_todo_list_core;

namespace lab_50_api_todo_list_core.Migrations
{
    [DbContext(typeof(TaskItemContext))]
    [Migration("20191011130931_seed-1")]
    partial class seed1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("lab_50_api_todo_list_core.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new { CategoryID = 1, CategoryName = "Admin" },
                        new { CategoryID = 2, CategoryName = "Work" }
                    );
                });

            modelBuilder.Entity("lab_50_api_todo_list_core.TaskItem", b =>
                {
                    b.Property<int>("TaskItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateDue");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("TaskDone");

                    b.Property<int?>("UserID");

                    b.HasKey("TaskItemID");

                    b.HasIndex("UserID");

                    b.ToTable("TaskItems");

                    b.HasData(
                        new { TaskItemID = 3, Description = "A Task I am doing right now", TaskDone = false, UserID = 5 },
                        new { TaskItemID = 1, Description = "A Task I have done", TaskDone = true, UserID = 6 }
                    );
                });

            modelBuilder.Entity("lab_50_api_todo_list_core.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new { UserID = 5, UserName = "Nooooong" },
                        new { UserID = 6, UserName = "Grong" },
                        new { UserID = 7, UserName = "Brek" }
                    );
                });

            modelBuilder.Entity("lab_50_api_todo_list_core.TaskItem", b =>
                {
                    b.HasOne("lab_50_api_todo_list_core.User", "User")
                        .WithMany("TaskItems")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}