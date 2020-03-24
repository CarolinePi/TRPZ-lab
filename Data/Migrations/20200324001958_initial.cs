using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
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
                    FrameModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Frames_FrameModelId",
                        column: x => x.FrameModelId,
                        principalTable: "Frames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Frames",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("abebcd43-5718-43c4-aa3d-6c4bc7153b37"), "Standart" });

            migrationBuilder.InsertData(
                table: "Frames",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d83be8ac-b1e9-4d5b-be34-ecc207a9cc34"), "Original" });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "FrameModelId", "Name", "Quantity" },
                values: new object[,]
                {
                    { new Guid("c505f2b7-01ec-4922-b062-ab8f3057b8b1"), new Guid("abebcd43-5718-43c4-aa3d-6c4bc7153b37"), "Wood", 21 },
                    { new Guid("a0085ad9-552c-4dc5-8de1-6e0e9a2e83c7"), new Guid("abebcd43-5718-43c4-aa3d-6c4bc7153b37"), "Iron", 18 },
                    { new Guid("2ce1e9ef-98fb-4c07-9016-052fba27143f"), new Guid("d83be8ac-b1e9-4d5b-be34-ecc207a9cc34"), "Black paint", 14 },
                    { new Guid("7506ae84-79d5-45d8-952c-f3807bf19ae0"), new Guid("d83be8ac-b1e9-4d5b-be34-ecc207a9cc34"), "Yellow paint", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_FrameModelId",
                table: "Materials",
                column: "FrameModelId");
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
