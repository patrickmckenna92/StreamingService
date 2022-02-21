using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StreamingService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Package = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FreeSongs = table.Column<int>(type: "int", nullable: false),
                    RemainingSongsThisMonth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionId",
                table: "Users",
                column: "SubscriptionId");

            migrationBuilder.Sql("insert into Subscriptions (Id, Package, Price) VALUES (NEWID(), 1, 0)");
            migrationBuilder.Sql("insert into Subscriptions (Id, Package, Price) VALUES (NEWID(), 2, 4.99)");
            migrationBuilder.Sql("insert into Subscriptions (Id, Package, Price) VALUES (NEWID(), 3, 9.99)");

            migrationBuilder.Sql("insert into Users (Id, EmailAddress, SubscriptionId, FreeSongs, RemainingSongsThisMonth) " +
                "VALUES (NEWID(), 'test@test.com', (SELECT Id FROM Subscriptions WHERE Package = 1), 3, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
