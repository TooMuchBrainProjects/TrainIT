﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Configuration;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(TrainITDbContext))]
    [Migration("20230402181242_nametables")]
    partial class nametables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Entities.Auth.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ROLE_ID");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("IDENTIFIER");

                    b.HasKey("Id");

                    b.HasIndex("Identifier")
                        .IsUnique();

                    b.ToTable("ROLES");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Administrator",
                            Identifier = "Admin"
                        });
                });

            modelBuilder.Entity("Model.Entities.Auth.RoleClaim", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("ROLE_ID");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("USER_HAS_ROLES_JT");
                });

            modelBuilder.Entity("Model.Entities.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("PASSWORD_HASH");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("USERNAME");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("Model.Entities.Library.ExerciseLibrary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EXERCISE_LIBRARY_ID");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int?>("MachineLibraryId")
                        .HasColumnType("int")
                        .HasColumnName("MACHINE_LIBRARY_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.HasIndex("MachineLibraryId");

                    b.ToTable("EXERCISE_LIBRARIES");
                });

            modelBuilder.Entity("Model.Entities.Library.ExerciseLibraryMuscleLibrary", b =>
                {
                    b.Property<int>("ExerciseLibraryId")
                        .HasColumnType("int")
                        .HasColumnName("EXERCISE_LIBRARY_ID");

                    b.Property<int>("MuscleLibraryId")
                        .HasColumnType("int")
                        .HasColumnName("MUSCLE_LIBRARY_ID");

                    b.HasKey("ExerciseLibraryId", "MuscleLibraryId");

                    b.HasIndex("MuscleLibraryId");

                    b.ToTable("EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT");
                });

            modelBuilder.Entity("Model.Entities.Library.MachineLibrary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MACHINE_LIBRARY_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("MACHINE_LIBRARIES");
                });

            modelBuilder.Entity("Model.Entities.Library.MuscleLibrary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MUSCLE_LIBRARY_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("MUSCLE_LIBRARIES");
                });

            modelBuilder.Entity("Model.Entities.Library.WorkoutLibrary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("WORKOUT_LIBRARY_ID");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("WORKOUT_LIBRARIES");
                });

            modelBuilder.Entity("Model.Entities.Library.WorkoutLibraryExerciseLibrary", b =>
                {
                    b.Property<int>("WorkoutLibraryId")
                        .HasColumnType("int")
                        .HasColumnName("WORKOUT_LIBRARY_ID");

                    b.Property<int>("ExerciseLibraryId")
                        .HasColumnType("int")
                        .HasColumnName("EXERCISE_LIBRARY_ID");

                    b.HasKey("WorkoutLibraryId", "ExerciseLibraryId");

                    b.HasIndex("ExerciseLibraryId");

                    b.ToTable("WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT");
                });

            modelBuilder.Entity("Model.Entities.Log.LogEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LOG_ID");

                    b.Property<DateOnly>("DateValue")
                        .HasColumnType("date")
                        .HasColumnName("CHANGE_DATE");

                    b.Property<string>("FieldType")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("FIELD_TYPE");

                    b.Property<string>("NewValue")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NEW_VALUE");

                    b.Property<string>("OldValue")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("OLD_VALUE");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LOG_ENTRIES");
                });

            modelBuilder.Entity("Model.Entities.per_User.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ACTIVITY_ID");

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

                    b.Property<float>("Weight")
                        .HasColumnType("float")
                        .HasColumnName("WEIGHT");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ACTIVITIES");
                });

            modelBuilder.Entity("Model.Entities.per_User.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EXERCISE_ID");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int?>("MachineLibraryId")
                        .HasColumnType("int")
                        .HasColumnName("MACHINE_LIBRARY_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("MachineLibraryId");

                    b.HasIndex("UserId");

                    b.ToTable("EXERCISES");
                });

            modelBuilder.Entity("Model.Entities.per_User.ExerciseMuscleLibrary", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("EXERCISE_ID");

                    b.Property<int>("MuscleLibraryId")
                        .HasColumnType("int")
                        .HasColumnName("MUSCLE_LIBRARY_ID");

                    b.HasKey("ExerciseId", "MuscleLibraryId");

                    b.HasIndex("MuscleLibraryId");

                    b.ToTable("EXERCISE_HAS_MUSCLE_LIBRARIES_JT");
                });

            modelBuilder.Entity("Model.Entities.per_User.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("WORKOUT_ID");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

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

                    b.ToTable("WORKOUTS");
                });

            modelBuilder.Entity("Model.Entities.per_User.WorkoutExercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("EXERCISE_ID");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int")
                        .HasColumnName("WORKOUT_ID");

                    b.HasKey("ExerciseId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WORKOUT_HAS_EXERCISES_JT");
                });

            modelBuilder.Entity("Model.Entities.Auth.RoleClaim", b =>
                {
                    b.HasOne("Model.Entities.Auth.Role", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Auth.User", "User")
                        .WithMany("RoleClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Entities.Library.ExerciseLibrary", b =>
                {
                    b.HasOne("Model.Entities.Library.MachineLibrary", "MachineLibrary")
                        .WithMany("ExerciseLibraries")
                        .HasForeignKey("MachineLibraryId");

                    b.Navigation("MachineLibrary");
                });

            modelBuilder.Entity("Model.Entities.Library.ExerciseLibraryMuscleLibrary", b =>
                {
                    b.HasOne("Model.Entities.Library.ExerciseLibrary", "ExerciseLibrary")
                        .WithMany("ExerciseLibraryMuscleLibraries")
                        .HasForeignKey("ExerciseLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Library.MuscleLibrary", "MuscleLibrary")
                        .WithMany("ExerciseLibraryMuscleLibraries")
                        .HasForeignKey("MuscleLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseLibrary");

                    b.Navigation("MuscleLibrary");
                });

            modelBuilder.Entity("Model.Entities.Library.WorkoutLibraryExerciseLibrary", b =>
                {
                    b.HasOne("Model.Entities.Library.ExerciseLibrary", "ExerciseLibrary")
                        .WithMany("WorkoutLibraryExerciseLibraries")
                        .HasForeignKey("ExerciseLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Library.WorkoutLibrary", "WorkoutLibrary")
                        .WithMany("WorkoutLibraryExerciseLibraries")
                        .HasForeignKey("WorkoutLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseLibrary");

                    b.Navigation("WorkoutLibrary");
                });

            modelBuilder.Entity("Model.Entities.Log.LogEntry", b =>
                {
                    b.HasOne("Model.Entities.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Entities.per_User.Activity", b =>
                {
                    b.HasOne("Model.Entities.per_User.Exercise", "Exercise")
                        .WithMany("Activities")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("Model.Entities.per_User.Exercise", b =>
                {
                    b.HasOne("Model.Entities.Library.MachineLibrary", "MachineLibrary")
                        .WithMany()
                        .HasForeignKey("MachineLibraryId");

                    b.HasOne("Model.Entities.Auth.User", "User")
                        .WithMany("Exercises")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MachineLibrary");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Entities.per_User.ExerciseMuscleLibrary", b =>
                {
                    b.HasOne("Model.Entities.per_User.Exercise", "Exercise")
                        .WithMany("ExerciseMuscleLibraries")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Library.MuscleLibrary", "MuscleLibrary")
                        .WithMany()
                        .HasForeignKey("MuscleLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("MuscleLibrary");
                });

            modelBuilder.Entity("Model.Entities.per_User.Workout", b =>
                {
                    b.HasOne("Model.Entities.Auth.User", "User")
                        .WithMany("Workouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Entities.per_User.WorkoutExercise", b =>
                {
                    b.HasOne("Model.Entities.per_User.Exercise", "Exercise")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.per_User.Workout", "Workout")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Model.Entities.Auth.Role", b =>
                {
                    b.Navigation("RoleClaims");
                });

            modelBuilder.Entity("Model.Entities.Auth.User", b =>
                {
                    b.Navigation("Exercises");

                    b.Navigation("RoleClaims");

                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("Model.Entities.Library.ExerciseLibrary", b =>
                {
                    b.Navigation("ExerciseLibraryMuscleLibraries");

                    b.Navigation("WorkoutLibraryExerciseLibraries");
                });

            modelBuilder.Entity("Model.Entities.Library.MachineLibrary", b =>
                {
                    b.Navigation("ExerciseLibraries");
                });

            modelBuilder.Entity("Model.Entities.Library.MuscleLibrary", b =>
                {
                    b.Navigation("ExerciseLibraryMuscleLibraries");
                });

            modelBuilder.Entity("Model.Entities.Library.WorkoutLibrary", b =>
                {
                    b.Navigation("WorkoutLibraryExerciseLibraries");
                });

            modelBuilder.Entity("Model.Entities.per_User.Exercise", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("ExerciseMuscleLibraries");

                    b.Navigation("WorkoutExercises");
                });

            modelBuilder.Entity("Model.Entities.per_User.Workout", b =>
                {
                    b.Navigation("WorkoutExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
