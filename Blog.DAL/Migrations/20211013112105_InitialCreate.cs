using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfClick = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleID);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Categories_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ArticleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "ArticleID", "Name" },
                values: new object[,]
                {
                    { 1, null, "Teknoloji" },
                    { 2, null, "Sanat" },
                    { 3, null, "Spor" },
                    { 4, null, "Sağlık" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Name", "Password", "Surname", "UserName", "UserRole" },
                values: new object[,]
                {
                    { 1, "adminname1", "a722c63db8ec8625af6cf71cb8c2d939", "adminsurname1", "admin", 1 },
                    { 2, "name2", "a722c63db8ec8625af6cf71cb8c2d939", "surname2", "username2", 2 },
                    { 3, "name3", "a722c63db8ec8625af6cf71cb8c2d939", "surname3", "username3", 2 },
                    { 4, "name4", "a722c63db8ec8625af6cf71cb8c2d939", "surname4", "username4", 2 }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "CategoryID", "Content", "Date", "Description", "ImagePath", "NumberOfClick", "Title", "UserID" },
                values: new object[,]
                {
                    { 1, 3, "Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", new DateTime(2021, 11, 8, 14, 21, 5, 244, DateTimeKind.Local).AddTicks(4809), "Basketbol Adına Herşey", null, 342, "Spor Makalesi", 1 },
                    { 2, 2, "Lorem ipsum lorem lorem ipsumrem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", new DateTime(2021, 10, 19, 14, 21, 5, 245, DateTimeKind.Local).AddTicks(7638), "Sanat Adına Herşey", null, 122, "Sanat Makalesi", 1 },
                    { 3, 2, "Lorem ipsum lorem lorem ipsum Lorem ipsum loremsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", new DateTime(2021, 10, 25, 14, 21, 5, 245, DateTimeKind.Local).AddTicks(7786), "Sanat Adına Herşey 2", null, 0, "Sanat Makalesi2", 1 },
                    { 4, 3, "Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", new DateTime(2021, 10, 15, 14, 21, 5, 245, DateTimeKind.Local).AddTicks(7824), "Basketbol Adına Herşey", null, 34, "Spor Makalesi", 2 },
                    { 5, 2, "Lorem ipsum lorem lorem ipsumrem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", new DateTime(2021, 10, 18, 14, 21, 5, 245, DateTimeKind.Local).AddTicks(7848), "Sanat Adına Herşey", null, 125, "Sanat Makalesi", 2 },
                    { 6, 2, "Lorem ipsum lorem lorem ipsum Lorem ipsum loremsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", new DateTime(2021, 10, 26, 14, 21, 5, 245, DateTimeKind.Local).AddTicks(7875), "Sanat Adına Herşey 2", null, 11, "Sanat Makalesi2", 2 },
                    { 7, 3, "Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", new DateTime(2021, 10, 30, 14, 21, 5, 245, DateTimeKind.Local).AddTicks(7896), "Basketbol Adına Herşey", null, 67, "Spor Makalesi", 3 },
                    { 8, 2, "Lorem ipsum lorem lorem ipsumrem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", new DateTime(2021, 10, 20, 14, 21, 5, 245, DateTimeKind.Local).AddTicks(7917), "Sanat Adına Herşey", null, 98, "Sanat Makalesi", 3 },
                    { 9, 2, "Lorem ipsum lorem lorem ipsum Lorem ipsum loremsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", new DateTime(2021, 10, 14, 14, 21, 5, 245, DateTimeKind.Local).AddTicks(7937), "Sanat Adına Herşey 2", null, 34, "Sanat Makalesi2", 3 },
                    { 10, 3, "Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", new DateTime(2021, 10, 13, 14, 21, 5, 245, DateTimeKind.Local).AddTicks(7959), "Basketbol Adına Herşey", null, 66, "Spor Makalesi", 4 },
                    { 11, 2, "Lorem ipsum lorem lorem ipsumrem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", new DateTime(2021, 10, 16, 14, 21, 5, 245, DateTimeKind.Local).AddTicks(7978), "Sanat Adına Herşey", null, 21, "Sanat Makalesi", 4 },
                    { 12, 2, "Lorem ipsum lorem lorem ipsum Lorem ipsum loremsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", new DateTime(2021, 10, 16, 14, 21, 5, 245, DateTimeKind.Local).AddTicks(7998), "Sanat Adına Herşey 2", null, 76, "Sanat Makalesi2", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserID",
                table: "Articles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ArticleID",
                table: "Categories",
                column: "ArticleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
