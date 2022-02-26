using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendWebApi.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(nullable: false),
                    DateOfJoining = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingTopic = table.Column<string>(nullable: false),
                    TrainingLocation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlan", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TeamInfo",
                columns: new[] { "Id", "DateOfJoining", "MemberName" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash" },
                    { 2, new DateTime(1989, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ramesh" },
                    { 3, new DateTime(1993, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suresh" }
                });

            migrationBuilder.InsertData(
                table: "TrainingPlan",
                columns: new[] { "Id", "TrainingLocation", "TrainingTopic" },
                values: new object[,]
                {
                    { 1, "Pluralsight", "DotNet" },
                    { 2, "LearningCenter", "APMTutorial" },
                    { 3, "Teams", "Ethics" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "TeamInfo");

            migrationBuilder.DropTable(
                name: "TrainingPlan");
        }
    }
}
