using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientContactManagementSystem.web.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "linkContact",
                table: "tblContacts",
                newName: "linkClientCheck");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLinkedContact",
                table: "tblClients",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfLinkedContact",
                table: "tblClients");

            migrationBuilder.RenameColumn(
                name: "linkClientCheck",
                table: "tblContacts",
                newName: "linkContact");
        }
    }
}
