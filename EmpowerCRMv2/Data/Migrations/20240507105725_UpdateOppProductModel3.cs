using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpowerCRMv2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOppProductModel3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "OpportunityProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OpportunityProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
