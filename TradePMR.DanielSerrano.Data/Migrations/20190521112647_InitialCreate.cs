using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradePMR.DanielSerrano.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    Symbol = table.Column<string>(maxLength: 4, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Action = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trades_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name" },
                values: new object[] { 1, new DateTime(2019, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name" },
                values: new object[] { 2, new DateTime(2019, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), "George" });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "AccountId", "Action", "DateCreated", "DateUpdated", "Quantity", "Symbol" },
                values: new object[] { 1, 1, 0, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "GE" });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "AccountId", "Action", "DateCreated", "DateUpdated", "Quantity", "Symbol" },
                values: new object[] { 3, 1, 0, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "AAPL" });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "AccountId", "Action", "DateCreated", "DateUpdated", "Quantity", "Symbol" },
                values: new object[] { 2, 2, 1, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "GE" });

            migrationBuilder.CreateIndex(
                name: "IX_Trades_AccountId",
                table: "Trades",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
