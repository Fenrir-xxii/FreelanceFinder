using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelanceFinder.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCurencyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "ProjectAdvertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ProjectAdvertisements",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CurrencyISOCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CurrencyISONumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAdvertisements_CurrencyId",
                table: "ProjectAdvertisements",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectAdvertisements_Currencies_CurrencyId",
                table: "ProjectAdvertisements",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectAdvertisements_Currencies_CurrencyId",
                table: "ProjectAdvertisements");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_ProjectAdvertisements_CurrencyId",
                table: "ProjectAdvertisements");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "ProjectAdvertisements");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ProjectAdvertisements");
        }
    }
}
