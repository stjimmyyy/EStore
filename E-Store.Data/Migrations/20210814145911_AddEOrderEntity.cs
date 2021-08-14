using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Store.Data.Migrations
{
    public partial class AddEOrderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: true),
                    SellerAddressId = table.Column<int>(type: "int", nullable: true),
                    BuyerAddressId = table.Column<int>(type: "int", nullable: true),
                    SellerPersonDetailId = table.Column<int>(type: "int", nullable: true),
                    BuyerPersonDetailId = table.Column<int>(type: "int", nullable: true),
                    AccountantDetailId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Issued = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    BuyerDeliveryAddressId = table.Column<int>(type: "int", nullable: true),
                    DeliveryProductId = table.Column<int>(type: "int", nullable: true),
                    SellerBankAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EOrders_Addresses_BuyerAddressId",
                        column: x => x.BuyerAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EOrders_Addresses_BuyerDeliveryAddressId",
                        column: x => x.BuyerDeliveryAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EOrders_Addresses_SellerAddressId",
                        column: x => x.SellerAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EOrders_BankAccounts_SellerBankAccountId",
                        column: x => x.SellerBankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EOrders_People_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EOrders_People_SellerId",
                        column: x => x.SellerId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EOrders_PersonDetails_AccountantDetailId",
                        column: x => x.AccountantDetailId,
                        principalTable: "PersonDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EOrders_PersonDetails_BuyerPersonDetailId",
                        column: x => x.BuyerPersonDetailId,
                        principalTable: "PersonDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EOrders_PersonDetails_SellerPersonDetailId",
                        column: x => x.SellerPersonDetailId,
                        principalTable: "PersonDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EOrders_Products_DeliveryProductId",
                        column: x => x.DeliveryProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductEOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EOrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductEOrders_EOrders_EOrderId",
                        column: x => x.EOrderId,
                        principalTable: "EOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductEOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EOrders_AccountantDetailId",
                table: "EOrders",
                column: "AccountantDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_EOrders_BuyerAddressId",
                table: "EOrders",
                column: "BuyerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EOrders_BuyerDeliveryAddressId",
                table: "EOrders",
                column: "BuyerDeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EOrders_BuyerId",
                table: "EOrders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_EOrders_BuyerPersonDetailId",
                table: "EOrders",
                column: "BuyerPersonDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_EOrders_DeliveryProductId",
                table: "EOrders",
                column: "DeliveryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EOrders_SellerAddressId",
                table: "EOrders",
                column: "SellerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EOrders_SellerBankAccountId",
                table: "EOrders",
                column: "SellerBankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EOrders_SellerId",
                table: "EOrders",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_EOrders_SellerPersonDetailId",
                table: "EOrders",
                column: "SellerPersonDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEOrders_EOrderId",
                table: "ProductEOrders",
                column: "EOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEOrders_ProductId",
                table: "ProductEOrders",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductEOrders");

            migrationBuilder.DropTable(
                name: "EOrders");
        }
    }
}
