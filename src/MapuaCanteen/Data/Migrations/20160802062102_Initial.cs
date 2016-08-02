using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MapuaCanteen.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChefBabsProducts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    PreparationTime = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefBabsProducts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PajGrillProducts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    PreparationTime = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PajGrillProducts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaotsinProducts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    PreparationTime = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaotsinProducts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Balance = table.Column<decimal>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    LastTransaction = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    StudentNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAccounts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChefBabsProducts");

            migrationBuilder.DropTable(
                name: "PajGrillProducts");

            migrationBuilder.DropTable(
                name: "PaotsinProducts");

            migrationBuilder.DropTable(
                name: "StudentAccounts");
        }
    }
}
