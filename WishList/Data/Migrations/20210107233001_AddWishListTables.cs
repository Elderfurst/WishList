using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WishList.Data.Migrations
{
    public partial class AddWishListTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceId = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Private = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishListEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BackingUrl = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    MarkedOff = table.Column<bool>(nullable: false),
                    DateMarkedOff = table.Column<DateTime>(nullable: false),
                    WishListRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishListEntries_WishLists_WishListRecordId",
                        column: x => x.WishListRecordId,
                        principalTable: "WishLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishListEntries_WishListRecordId",
                table: "WishListEntries",
                column: "WishListRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishListEntries");

            migrationBuilder.DropTable(
                name: "WishLists");
        }
    }
}
