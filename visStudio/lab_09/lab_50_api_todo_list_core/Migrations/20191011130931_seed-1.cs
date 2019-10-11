using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_50_api_todo_list_core.Migrations
{
    public partial class seed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    TaskItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: false),
                    TaskDone = table.Column<bool>(nullable: false),
                    DateDue = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.TaskItemID);
                    table.ForeignKey(
                        name: "FK_TaskItems_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Work" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserName" },
                values: new object[] { 5, "Nooooong" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserName" },
                values: new object[] { 6, "Grong" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserName" },
                values: new object[] { 7, "Brek" });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemID", "DateDue", "Description", "TaskDone", "UserID" },
                values: new object[] { 3, null, "A Task I am doing right now", false, 5 });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemID", "DateDue", "Description", "TaskDone", "UserID" },
                values: new object[] { 1, null, "A Task I have done", true, 6 });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserID",
                table: "TaskItems",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
