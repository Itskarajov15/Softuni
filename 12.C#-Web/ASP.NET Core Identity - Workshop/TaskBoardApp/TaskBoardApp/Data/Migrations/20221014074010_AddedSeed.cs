using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class AddedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a8830398-4e60-4a6c-9552-2fa2e40b19a9", 0, "d32b3f45-5b7d-4008-a195-8c379648cec7", "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEJu4sGCnmtapjONYib5wmPmTNv3VxnbUbvLcO8VY7cYavE3gikR6BJcggPE97iH69Q==", null, false, "53ea4a6c-dd43-4ec8-985b-5755a2a606af", false, "guest" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 14, 10, 40, 9, 921, DateTimeKind.Local).AddTicks(2561), "Learn using ASP.NET Core Identity", "a8830398-4e60-4a6c-9552-2fa2e40b19a9", "Prepare for ASP.NET Fundamentals exam" },
                    { 2, 3, new DateTime(2022, 5, 14, 10, 40, 9, 921, DateTimeKind.Local).AddTicks(2597), "Learn using EF Core and MS SQL Server Management Studio", "a8830398-4e60-4a6c-9552-2fa2e40b19a9", "Improve EF Core skills" },
                    { 3, 2, new DateTime(2022, 10, 4, 10, 40, 9, 921, DateTimeKind.Local).AddTicks(2600), "Learn using ASP.NET Core Identity", "a8830398-4e60-4a6c-9552-2fa2e40b19a9", "Improve ASP.NET Core skills" },
                    { 4, 3, new DateTime(2021, 10, 14, 10, 40, 9, 921, DateTimeKind.Local).AddTicks(2603), "Prepare by solving old Mid and Final exams", "a8830398-4e60-4a6c-9552-2fa2e40b19a9", "Prepare for C# Fundamentals Exam" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8830398-4e60-4a6c-9552-2fa2e40b19a9");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
