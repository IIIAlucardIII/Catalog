using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Folders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name", "ParentId", "Path" },
                values: new object[,]
                {
                    { 1, "Creating Digital Images", null, "Creating Digital Images" },
                    { 2, "Resources", 1, "Creating Digital Images/Resources" },
                    { 3, "Evidence", 1, "Creating Digital Images/Evidence" },
                    { 4, "Graphic Products", 1, "Creating Digital Images/Graphic Products" },
                    { 5, "Primary Sources", 2, "Creating Digital Images/Resources/Primary Sources" },
                    { 6, "Secondary Sources", 2, "Creating Digital Images/Resources/Secondary Sources" },
                    { 7, "Process", 4, "Creating Digital Images/Graphic Products/Process" },
                    { 8, "Final Product", 4, "Creating Digital Images/Graphic Products/Final Product" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentId",
                table: "Folders",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
