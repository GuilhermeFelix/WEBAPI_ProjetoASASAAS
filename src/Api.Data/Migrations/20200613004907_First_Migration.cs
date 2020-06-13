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
                    Crm_IPV4 = table.Column<string>(maxLength: 100, nullable: true),
                    Vendas_IPV4 = table.Column<string>(maxLength: 100, nullable: true),
                    Faturamento_IPV4 = table.Column<string>(maxLength: 100, nullable: true),
                    Site_IPV4 = table.Column<string>(maxLength: 100, nullable: true),
                    Crm_PORT = table.Column<int>(maxLength: 100, nullable: false),
                    Vendas_PORT = table.Column<int>(maxLength: 100, nullable: false),
                    Faturamento_PORT = table.Column<int>(maxLength: 100, nullable: false),
                    Site_PORT = table.Column<int>(maxLength: 10, nullable: false),
                    Crm_LICENSES = table.Column<int>(maxLength: 3, nullable: false),
                    Vendas_LICENSES = table.Column<int>(maxLength: 3, nullable: false),
                    Faturamento_LICENSES = table.Column<int>(maxLength: 3, nullable: false),
                    Site_LICENSES = table.Column<int>(maxLength: 3, nullable: false),
                    Crm_TAG = table.Column<string>(maxLength: 100, nullable: true),
                    Vendas_TAG = table.Column<string>(maxLength: 100, nullable: true),
                    Faturamento_TAG = table.Column<string>(maxLength: 100, nullable: true),
                    Site_TAG = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Crm_IPV4",
                table: "Manager",
                column: "Crm_IPV4");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Crm_LICENSES",
                table: "Manager",
                column: "Crm_LICENSES");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Crm_PORT",
                table: "Manager",
                column: "Crm_PORT");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Crm_START",
                table: "Manager",
                column: "Crm_START");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Crm_TAG",
                table: "Manager",
                column: "Crm_TAG");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Email",
                table: "Manager",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Faturamento_IPV4",
                table: "Manager",
                column: "Faturamento_IPV4");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Faturamento_LICENSES",
                table: "Manager",
                column: "Faturamento_LICENSES");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Faturamento_PORT",
                table: "Manager",
                column: "Faturamento_PORT");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Faturamento_START",
                table: "Manager",
                column: "Faturamento_START");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Faturamento_TAG",
                table: "Manager",
                column: "Faturamento_TAG");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Site_IPV4",
                table: "Manager",
                column: "Site_IPV4");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Site_LICENSES",
                table: "Manager",
                column: "Site_LICENSES");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Site_PORT",
                table: "Manager",
                column: "Site_PORT");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Site_START",
                table: "Manager",
                column: "Site_START");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Site_TAG",
                table: "Manager",
                column: "Site_TAG");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Vendas_IPV4",
                table: "Manager",
                column: "Vendas_IPV4");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Vendas_LICENSES",
                table: "Manager",
                column: "Vendas_LICENSES");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Vendas_PORT",
                table: "Manager",
                column: "Vendas_PORT");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Vendas_START",
                table: "Manager",
                column: "Vendas_START");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Vendas_TAG",
                table: "Manager",
                column: "Vendas_TAG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manager");
        }
    }
}
