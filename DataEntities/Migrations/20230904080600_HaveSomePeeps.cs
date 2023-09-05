using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEntities.Migrations
{
    /// <inheritdoc />
    public partial class HaveSomePeeps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into people values (newid(), 'William', 'Hartnell', 'Male', '1908-01-08', 'London, England', '1975-04-23', 'Marden, Kent, England');
                                    insert into people values (newid(), 'Patrick', 'Troughton', 'Male', '1920-03-25', 'Mill Hill, Middlesex, England', '1987-03-28', 'Columbus, Georgia, United States');
                                    insert into people values (newid(), 'Jon', 'Pertwee', 'Male', '1919-07-07', 'Chelsea, London, England', '1996-05-20', 'Sherman, Connecticut, United States');
                                    insert into people values (newid(), 'Tom', 'Baker', 'Male', '1934-01-20', 'Vauxhall, Liverpool, England', null, null);
                                    insert into people values (newid(), 'Peter', 'Davison', 'Male', '1951-04-13', 'Streatham, London, England', null, null);
                                    insert into people values (newid(), 'Colin', 'Baker', 'Male', '1943-06-08', 'Waterloo, London, England', null, null);
                                    insert into people values (newid(), 'Sylvester', 'McCoy', 'Male', '1943-08-20', 'Dunoon, Argyll and Bute, Scotland', null, null);
                                    insert into people values (newid(), 'Paul', 'McGann', 'Male', '1959-11-14', 'Kensington, Liverpool, England', null, null);
                                    insert into people values (newid(), 'Christopher', 'Eccleston', 'Male', '1964-02-16', 'Salford, Lancashire, England', null, null);
                                    insert into people values (newid(), 'David', 'Tennant', 'Male', '1971-04-18', 'London, England', null, null);
                                    insert into people values (newid(), 'Matt', 'Smith', 'Male', '1982-10-28', 'Northampton, England', null, null);
                                    insert into people values (newid(), 'Peter', 'Capaldi', 'Male', '1958-04-14', 'Glasgow, Scotland', null, null);
                                    insert into people values (newid(), 'Jodie', 'Whittaker', 'Female', '1982-06-17', 'Skelmanthorpe, West Yorkshire, England', null, null);
                                    insert into people values (newid(), 'Ncuti', 'Gatwa', 'Male', '1992-10-15', 'Kigali, Rwanda', null, null);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
