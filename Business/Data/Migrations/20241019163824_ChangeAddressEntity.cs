using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAddressEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "CustomerAddress",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "StreetDetail",
                table: "CustomerAddress",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "CustomerAddress",
                newName: "Neighborhood");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "CustomerAddress",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "CustomerAddress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "CustomerAddress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Residential",
                table: "CustomerAddress",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "CustomerAddress");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "CustomerAddress");

            migrationBuilder.DropColumn(
                name: "Residential",
                table: "CustomerAddress");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "CustomerAddress",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "CustomerAddress",
                newName: "StreetDetail");

            migrationBuilder.RenameColumn(
                name: "Neighborhood",
                table: "CustomerAddress",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "CustomerAddress",
                newName: "Number");
        }
    }
}
