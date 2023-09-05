using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEntities.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePeopleCommandHandlerModuleVersionV1R1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"update Modules
                                   set DefaultVersion = 1.1
                                   where [Name] = 'PeopleCommandHandler'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"update Modules
                                   set DefaultVersion = 1.0
                                   where [Name] = 'PeopleCommandHandler'");
        }
    }
}
