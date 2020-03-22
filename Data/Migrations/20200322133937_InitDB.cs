using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    FrameId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Frames_FrameId",
                        column: x => x.FrameId,
                        principalTable: "Frames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "FrameId", "Name", "Quantity" },
                values: new object[,]
                {
                    { new Guid("4deb0123-af83-43f9-b0eb-0d073b92c8cc"), null, "Wood", 21 },
                    { new Guid("6b57748c-e193-4fe5-9553-c8d557e4336b"), null, "Iron", 18 },
                    { new Guid("95ba9ece-f754-4cd7-9452-2a267b8f682e"), null, "Black paint", 14 },
                    { new Guid("14c9eeb1-80c7-400f-bd21-3567c379934b"), null, "Yellow paint", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_FrameId",
                table: "Materials",
                column: "FrameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Frames");
        }
    }
}
