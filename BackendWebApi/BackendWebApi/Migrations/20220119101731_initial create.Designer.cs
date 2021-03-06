// <auto-generated />
using System;
using BackendWebApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackendWebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220119101731_initial create")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackendWebApi.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("BackendWebApi.Models.Register", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("BackendWebApi.Models.TeamInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfJoining")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TeamInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfJoining = new DateTime(1998, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MemberName = "Akash"
                        },
                        new
                        {
                            Id = 2,
                            DateOfJoining = new DateTime(1989, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MemberName = "Ramesh"
                        },
                        new
                        {
                            Id = 3,
                            DateOfJoining = new DateTime(1993, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MemberName = "Suresh"
                        });
                });

            modelBuilder.Entity("BackendWebApi.Models.TrainingPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TrainingLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainingTopic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrainingPlan");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TrainingLocation = "Pluralsight",
                            TrainingTopic = "DotNet"
                        },
                        new
                        {
                            Id = 2,
                            TrainingLocation = "LearningCenter",
                            TrainingTopic = "APMTutorial"
                        },
                        new
                        {
                            Id = 3,
                            TrainingLocation = "Teams",
                            TrainingTopic = "Ethics"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
