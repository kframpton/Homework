using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEntities.Migrations
{
    /// <inheritdoc />
    public partial class AddModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(1024)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DefaultVersion = table.Column<double>(type: "float", nullable: false),
                    MinimumVersion = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
