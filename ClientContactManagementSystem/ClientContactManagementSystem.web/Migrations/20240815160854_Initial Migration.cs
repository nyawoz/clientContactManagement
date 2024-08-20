using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientContactManagementSystem.web.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblClents",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClents", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "tblContacts",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    linkContact = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "ClientsContact",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactsContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsContact", x => new { x.ClientId, x.ContactsContactId });
                    table.ForeignKey(
                        name: "FK_ClientsContact_tblClents_ClientId",
                        column: x => x.ClientId,
                        principalTable: "tblClents",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientsContact_tblContacts_ContactsContactId",
                        column: x => x.ContactsContactId,
                        principalTable: "tblContacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientsContact_ContactsContactId",
                table: "ClientsContact",
                column: "ContactsContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientsContact");

            migrationBuilder.DropTable(
                name: "tblClents");

            migrationBuilder.DropTable(
                name: "tblContacts");
        }
    }
}
