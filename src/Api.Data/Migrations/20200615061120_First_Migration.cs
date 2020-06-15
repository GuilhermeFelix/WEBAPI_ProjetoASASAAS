using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class First_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Crm_START = table.Column<bool>(nullable: false),
                    Vendas_START = table.Column<bool>(nullable: false),
                    Faturamento_START = table.Column<bool>(nullable: false),
                    Site_START = table.Column<bool>(nullable: false),
                    IPV4 = table.Column<string>(maxLength: 100, nullable: true),
                    PORT = table.Column<int>(maxLength: 100, nullable: false),
                    LICENSES = table.Column<int>(maxLength: 3, nullable: false),
                    TAG = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Crm_START",
                table: "Manager",
                column: "Crm_START");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Email",
                table: "Manager",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Faturamento_START",
                table: "Manager",
                column: "Faturamento_START");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_IPV4",
                table: "Manager",
                column: "IPV4");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_LICENSES",
                table: "Manager",
                column: "LICENSES");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_PORT",
                table: "Manager",
                column: "PORT");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Site_START",
                table: "Manager",
                column: "Site_START");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_TAG",
                table: "Manager",
                column: "TAG");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Vendas_START",
                table: "Manager",
                column: "Vendas_START");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manager");
        }
    }
}
