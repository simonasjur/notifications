using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NotificationScheduler.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SendingDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMarket",
                columns: table => new
                {
                    CompaniesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MarketsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMarket", x => new { x.CompaniesId, x.MarketsId });
                    table.ForeignKey(
                        name: "FK_CompanyMarket_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyMarket_Markets_MarketsId",
                        column: x => x.MarketsId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyNotification",
                columns: table => new
                {
                    CompaniesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NotificationsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyNotification", x => new { x.CompaniesId, x.NotificationsId });
                    table.ForeignKey(
                        name: "FK_CompanyNotification_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyNotification_Notifications_NotificationsId",
                        column: x => x.NotificationsId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Markets",
                columns: new[] { "Id", "Location" },
                values: new object[,]
                {
                    { new Guid("128d9dfa-860c-43b3-a1b6-4b41c0e9e668"), "Norway" },
                    { new Guid("74bdbf46-1c5d-47ab-9da0-b60ab8f07605"), "Denmark" },
                    { new Guid("9cd11347-465b-4eb5-a4d5-a9d6b9afc425"), "Finland" },
                    { new Guid("bd418e29-19cf-4cbb-a7d8-51d4285ed850"), "Sweden" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Number",
                table: "Companies",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMarket_MarketsId",
                table: "CompanyMarket",
                column: "MarketsId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyNotification_NotificationsId",
                table: "CompanyNotification",
                column: "NotificationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_Location",
                table: "Markets",
                column: "Location",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SendingDate",
                table: "Notifications",
                column: "SendingDate",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyMarket");

            migrationBuilder.DropTable(
                name: "CompanyNotification");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}
