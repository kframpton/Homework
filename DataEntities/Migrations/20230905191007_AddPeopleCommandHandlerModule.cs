using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEntities.Migrations
{
    /// <inheritdoc />
    public partial class AddPeopleCommandHandlerModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into Modules values ('PeopleCommandHandler', 'Api', 1.0, 1.0);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"delete from Modules
                                   where [Name] = 'PeopleCommandHandler';");
        }
    }
}
