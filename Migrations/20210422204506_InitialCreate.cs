using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XPTO.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OS",
                columns: table => new
                {
                    OSNumber = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    CustomerCNPJ = table.Column<string>(type: "varchar(14) CHARACTER SET utf8mb4", maxLength: 14, nullable: false),
                    CustomerName = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    WorkerCPF = table.Column<string>(type: "varchar(11) CHARACTER SET utf8mb4", maxLength: 11, nullable: false),
                    WorkerName = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OS", x => x.OSNumber);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Password = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OS");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
