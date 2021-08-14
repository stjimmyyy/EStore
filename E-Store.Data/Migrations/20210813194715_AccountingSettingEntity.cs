using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Store.Data.Migrations
{
    public partial class AccountingSettingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vat = table.Column<int>(type: "int", nullable: false),
                    AccountantDetailId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountingSettings_People_SellerId",
                        column: x => x.SellerId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountingSettings_PersonDetails_AccountantDetailId",
                        column: x => x.AccountantDetailId,
                        principalTable: "PersonDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingSettings_AccountantDetailId",
                table: "AccountingSettings",
                column: "AccountantDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingSettings_SellerId",
                table: "AccountingSettings",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingSettings");
        }
    }
}
