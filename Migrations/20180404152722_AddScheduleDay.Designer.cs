﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TaskApp2;
using TaskApp2.Models;

namespace TaskApp2.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20180404152722_AddScheduleDay")]
    partial class AddScheduleDay
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("TaskApp2.Models.Task", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Complete");

                    b.Property<string>("Desc");

                    b.Property<string>("Name");

                    b.Property<int>("RepeatFreq");

                    b.Property<DateTime>("ScheduleDay");

                    b.HasKey("ID");

                    b.ToTable("Task");
                });
#pragma warning restore 612, 618
        }
    }
}
