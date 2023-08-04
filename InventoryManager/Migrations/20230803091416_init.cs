using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManager.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemName = table.Column<string>(type: "TEXT", nullable: false),
                    ItemType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoughtItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShippingStatus = table.Column<string>(type: "TEXT", nullable: false),
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsListed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoughtItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoughtItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoldItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShippingStatus = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoughtItems_ItemId",
                table: "BoughtItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldItems_ItemId",
                table: "SoldItems",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoughtItems");

            migrationBuilder.DropTable(
                name: "SoldItems");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
