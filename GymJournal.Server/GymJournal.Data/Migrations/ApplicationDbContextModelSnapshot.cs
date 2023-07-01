﻿// <auto-generated />
using System;
using GymJournal.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymJournal.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExerciseMuscle", b =>
                {
                    b.Property<Guid>("ExercisesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MusclesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExercisesId", "MusclesId");

                    b.HasIndex("MusclesId");

                    b.ToTable("ExerciseMuscle");
                });

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.Property<Guid>("ExercisesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkoutsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExercisesId", "WorkoutsId");

                    b.HasIndex("WorkoutsId");

                    b.ToTable("ExerciseWorkout");
                });

            modelBuilder.Entity("GymJournal.Data.Entities.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("GymJournal.Data.Entities.Muscle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Muscles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3cf1dc75-d641-4305-97e5-eb629f454676"),
                            Name = "Chest"
                        },
                        new
                        {
                            Id = new Guid("f62031db-81a1-4643-8e44-845c19eb51e4"),
                            Name = "Triceps"
                        },
                        new
                        {
                            Id = new Guid("5a25a051-75d3-4733-839c-f645ca8f20f7"),
                            Name = "Back"
                        },
                        new
                        {
                            Id = new Guid("3c0b0369-e88c-40f0-bc30-a1a309958db4"),
                            Name = "Biceps"
                        },
                        new
                        {
                            Id = new Guid("909c35a3-a2c0-4fc9-97b6-5299a0d88dab"),
                            Name = "Forearms"
                        },
                        new
                        {
                            Id = new Guid("f46d7cf7-a3a8-42eb-97c5-0e3b10b5bbe1"),
                            Name = "Abs"
                        },
                        new
                        {
                            Id = new Guid("8bd9fdf8-f0b5-4361-b447-b926195637c7"),
                            Name = "FrontalDelt"
                        },
                        new
                        {
                            Id = new Guid("576d342b-b493-4edc-ad56-fffd2ffa36fb"),
                            Name = "LateralDelt"
                        },
                        new
                        {
                            Id = new Guid("6328df6e-3f56-4ad6-ba7b-50ab92270b48"),
                            Name = "RearDelt"
                        },
                        new
                        {
                            Id = new Guid("3ef37065-e38e-4676-a0da-af322e750d45"),
                            Name = "Quads"
                        },
                        new
                        {
                            Id = new Guid("dc0d5865-8fa7-48a1-89cc-65986e10928e"),
                            Name = "Hamstrings"
                        },
                        new
                        {
                            Id = new Guid("a2d5742d-a68a-4b70-a7ac-94f31dd77b03"),
                            Name = "Calves"
                        },
                        new
                        {
                            Id = new Guid("a8627c30-a7b9-4b2c-af13-350b77faa36b"),
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("GymJournal.Data.Entities.UserInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Token")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WorkoutPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WorkoutPlanStart")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("WorkoutPlanId");

                    b.ToTable("UserInfos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("42282faf-05a4-48ff-b062-65fed7b5e84a"),
                            Name = "Admin",
                            Password = "$2a$11$UGVpOHQKT1mMw5YLrCJ4A.P1RWVvkZ0.ItcTb146/e5yoVvDwd7xS",
                            Role = "Admin",
                            Token = new Guid("8ae01d7d-3965-4b7e-b8af-e12fd5f588f6")
                        });
                });

            modelBuilder.Entity("GymJournal.Data.Entities.WorkSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reps")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("UserId");

                    b.ToTable("WorkSets");
                });

            modelBuilder.Entity("GymJournal.Data.Entities.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("GymJournal.Data.Entities.WorkoutPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkoutPlans");
                });

            modelBuilder.Entity("WorkoutWorkoutPlan", b =>
                {
                    b.Property<Guid>("WorkoutPlansId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkoutsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WorkoutPlansId", "WorkoutsId");

                    b.HasIndex("WorkoutsId");

                    b.ToTable("WorkoutWorkoutPlan");
                });

            modelBuilder.Entity("ExerciseMuscle", b =>
                {
                    b.HasOne("GymJournal.Data.Entities.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymJournal.Data.Entities.Muscle", null)
                        .WithMany()
                        .HasForeignKey("MusclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.HasOne("GymJournal.Data.Entities.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymJournal.Data.Entities.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymJournal.Data.Entities.UserInfo", b =>
                {
                    b.HasOne("GymJournal.Data.Entities.WorkoutPlan", "WorkoutPlan")
                        .WithMany("UserInfos")
                        .HasForeignKey("WorkoutPlanId");

                    b.Navigation("WorkoutPlan");
                });

            modelBuilder.Entity("GymJournal.Data.Entities.WorkSet", b =>
                {
                    b.HasOne("GymJournal.Data.Entities.Exercise", "Exercise")
                        .WithMany("WorkSets")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymJournal.Data.Entities.UserInfo", "User")
                        .WithMany("WorkSets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkoutWorkoutPlan", b =>
                {
                    b.HasOne("GymJournal.Data.Entities.WorkoutPlan", null)
                        .WithMany()
                        .HasForeignKey("WorkoutPlansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymJournal.Data.Entities.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymJournal.Data.Entities.Exercise", b =>
                {
                    b.Navigation("WorkSets");
                });

            modelBuilder.Entity("GymJournal.Data.Entities.UserInfo", b =>
                {
                    b.Navigation("WorkSets");
                });

            modelBuilder.Entity("GymJournal.Data.Entities.WorkoutPlan", b =>
                {
                    b.Navigation("UserInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
