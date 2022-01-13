using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visagiste.Migrations
{
    public partial class AddPropetryMapToContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "Contact",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 1,
                column: "Map",
                value: "<script type=\"text/javascript\" charset=\"utf-8\" async src=\"https://api-maps.yandex.ru/services/constructor/1.0/js/?um=constructor%3A3c1d989bb05c7ef404fd41c59995fe2231f79de65bef8c8c41033e8682000645&amp;lang=ru_RU&amp;scroll=true\"></script>");

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1,
                column: "Banners",
                value: "[\"/images/SeedData/banner-1.jpg\",\"/images/SeedData/banner-2.jpg\"]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Map",
                table: "Contact");

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1,
                column: "Banners",
                value: "[\"/images/author.jpg\",\"/images/author-2.jpg\"]");
        }
    }
}
