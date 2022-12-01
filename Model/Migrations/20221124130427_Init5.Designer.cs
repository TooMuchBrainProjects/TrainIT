﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Configurations;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(TrainITDbContext))]
    [Migration("20221124130427_Init5")]
    partial class Init5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EXERCISE_ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Machine")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("MACHINE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EXERCISES");
                });

            modelBuilder.Entity("Model.Entities.Preset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PRESET_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("PRESETS");
                });

            modelBuilder.Entity("Model.Entities.PresetExercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("EXERCISE_ID");

                    b.Property<int>("PresetId")
                        .HasColumnType("int")
                        .HasColumnName("PRESET_ID");

                    b.HasKey("ExerciseId", "PresetId");

                    b.HasIndex("PresetId");

                    b.ToTable("PRESET_HAS_EXERCISES_JT");
                });

            modelBuilder.Entity("Model.Entities.SubExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SUB_EXERCISE_ID");

                    b.Property<DateOnly>("DateValue")
                        .HasColumnType("date")
                        .HasColumnName("DATE");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("EXERCISE_ID");

                    b.Property<int>("Repetition")
                        .HasColumnType("int")
                        .HasColumnName("REPETITION");

                    b.Property<int>("Set")
                        .HasColumnType("int")
                        .HasColumnName("SET");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("WEIGHT");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("SUB_EXERCISES");
                });

            modelBuilder.Entity("Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.Property<string>("PasswordHashed")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("PASSWORD_HASHED");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("Model.Entities.Exercise", b =>
                {
                    b.HasOne("Model.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Entities.PresetExercise", b =>
                {
                    b.HasOne("Model.Entities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Preset", "Preset")
                        .WithMany()
                        .HasForeignKey("PresetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Preset");
                });

            modelBuilder.Entity("Model.Entities.SubExercise", b =>
                {
                    b.HasOne("Model.Entities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });
#pragma warning restore 612, 618
        }
    }
}
