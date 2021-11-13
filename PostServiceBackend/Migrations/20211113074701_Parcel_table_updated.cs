using Microsoft.EntityFrameworkCore.Migrations;

namespace PostServiceBackend.Migrations
{
    public partial class Parcel_table_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Receiver",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "Parcels");
        }
    }
}
