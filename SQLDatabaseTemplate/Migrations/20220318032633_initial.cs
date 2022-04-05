using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQLDatabaseTemplate.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelOne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelOne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelTwo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isThereTruth = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTwo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ModelOne",
                columns: new[] { "Id", "Text" },
                values: new object[] { 1, "Test 1" });

            migrationBuilder.InsertData(
                table: "ModelTwo",
                columns: new[] { "Id", "Text", "isThereTruth" },
                values: new object[] { 1, "Text", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelOne");

            migrationBuilder.DropTable(
                name: "ModelTwo");
        }
    }
}
