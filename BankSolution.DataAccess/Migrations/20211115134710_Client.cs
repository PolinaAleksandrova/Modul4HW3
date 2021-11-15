using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankSolution.DataAccess.Migrations
{
    public partial class Client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "FirstName", "LastName", "Location" },
                values: new object[,]
                {
                    { 1, "Phillip", "Freeman", "8202 Silver Impasse, Singing Springs, Illinois, US" },
                    { 2, "Jayson", "Henderson", "8065 Jagged Beacon Gate, Corfu, Georgia, US" },
                    { 3, "David", "Sanders", "9706 Cozy Highlands, Friday Harbor, Tennessee, US" },
                    { 4, "Piers", "Williams", "2147 Broad Embers Inlet, Wild Horse, Tennessee, US" },
                    { 5, "Steven", "Robertson", "1229 Noble Parkway, Opposition, Louisiana, US" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Budget", "ClientId", "Name", "StartedDate" },
                values: new object[,]
                {
                    { 1, 10000.0m, 1, "111", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 20000.0m, 2, "222", new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 30000.0m, 3, "333", new DateTime(2021, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 40000.0m, 4, "444", new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 50000.0m, 5, "555", new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");
        }
    }
}
