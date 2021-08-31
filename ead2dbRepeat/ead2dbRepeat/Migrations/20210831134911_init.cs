using Microsoft.EntityFrameworkCore.Migrations;

namespace ead2dbRepeat.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currentConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maxTemp = table.Column<int>(type: "int", nullable: false),
                    minTemp = table.Column<int>(type: "int", nullable: false),
                    wDirection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wSpeed = table.Column<int>(type: "int", nullable: false),
                    tomorrowForecast = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}
