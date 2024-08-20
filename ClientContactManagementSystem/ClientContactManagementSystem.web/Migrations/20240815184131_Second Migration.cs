using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientContactManagementSystem.web.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientsContact_tblClents_ClientId",
                table: "ClientsContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblClents",
                table: "tblClents");

            migrationBuilder.RenameTable(
                name: "tblClents",
                newName: "tblClients");

            migrationBuilder.AddColumn<string>(
                name: "ClientCode",
                table: "tblClients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblClients",
                table: "tblClients",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsContact_tblClients_ClientId",
                table: "ClientsContact",
                column: "ClientId",
                principalTable: "tblClients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientsContact_tblClients_ClientId",
                table: "ClientsContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblClients",
                table: "tblClients");

            migrationBuilder.DropColumn(
                name: "ClientCode",
                table: "tblClients");

            migrationBuilder.RenameTable(
                name: "tblClients",
                newName: "tblClents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblClents",
                table: "tblClents",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsContact_tblClents_ClientId",
                table: "ClientsContact",
                column: "ClientId",
                principalTable: "tblClents",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
