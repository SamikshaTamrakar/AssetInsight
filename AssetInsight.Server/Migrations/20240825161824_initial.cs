using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetInsight.Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssestClass = table.Column<string>(type: "TEXT", nullable: true),
                    Currency = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<string>(type: "TEXT", nullable: true),
                    InvestorName = table.Column<string>(type: "TEXT", nullable: true),
                    InvestorType = table.Column<string>(type: "TEXT", nullable: true),
                    InvestorCountry = table.Column<string>(type: "TEXT", nullable: true),
                    InvestorDateAdded = table.Column<string>(type: "TEXT", nullable: true),
                    InvestorLastUpdated = table.Column<string>(type: "TEXT", nullable: true),
                    TotalCommitment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");
        }
    }
}
