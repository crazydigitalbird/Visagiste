using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visagiste.Migrations
{
    public partial class AddClassTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Photos");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoTagJunction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhotoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoTagJunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoTagJunction_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotoTagJunction_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 1,
                column: "Map",
                value: "<script type=\"text/javascript\" charset=\"utf-8\" async src=\"https://api-maps.yandex.ru/services/constructor/1.0/js/?um=constructor%3A3c1d989bb05c7ef404fd41c59995fe2231f79de65bef8c8c41033e8682000645&amp;lang=ru_RU&amp;scroll=true\"></script>");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Model" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Visagiste" });

            migrationBuilder.InsertData(
                table: "PhotoTagJunction",
                columns: new[] { "Id", "PhotoId", "TagId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "PhotoTagJunction",
                columns: new[] { "Id", "PhotoId", "TagId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "PhotoTagJunction",
                columns: new[] { "Id", "PhotoId", "TagId" },
                values: new object[] { 3, 3, 1 });

            migrationBuilder.InsertData(
                table: "PhotoTagJunction",
                columns: new[] { "Id", "PhotoId", "TagId" },
                values: new object[] { 4, 4, 1 });

            migrationBuilder.InsertData(
                table: "PhotoTagJunction",
                columns: new[] { "Id", "PhotoId", "TagId" },
                values: new object[] { 5, 5, 1 });

            migrationBuilder.InsertData(
                table: "PhotoTagJunction",
                columns: new[] { "Id", "PhotoId", "TagId" },
                values: new object[] { 6, 6, 1 });

            migrationBuilder.InsertData(
                table: "PhotoTagJunction",
                columns: new[] { "Id", "PhotoId", "TagId" },
                values: new object[] { 7, 7, 1 });

            migrationBuilder.InsertData(
                table: "PhotoTagJunction",
                columns: new[] { "Id", "PhotoId", "TagId" },
                values: new object[] { 8, 8, 1 });

            migrationBuilder.InsertData(
                table: "PhotoTagJunction",
                columns: new[] { "Id", "PhotoId", "TagId" },
                values: new object[] { 9, 9, 1 });

            migrationBuilder.InsertData(
                table: "PhotoTagJunction",
                columns: new[] { "Id", "PhotoId", "TagId" },
                values: new object[] { 10, 1, 2 });

            migrationBuilder.InsertData(
                table: "PhotoTagJunction",
                columns: new[] { "Id", "PhotoId", "TagId" },
                values: new object[] { 11, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoTagJunction_PhotoId",
                table: "PhotoTagJunction",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoTagJunction_TagId",
                table: "PhotoTagJunction",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoTagJunction");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Photos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 1,
                column: "Map",
                value: "<script type=\"text/javascript\" charset=\"utf-8\" async src=\"https://api-maps.yandex.ru/services/constructor/1.0/js/?um=constructor%3A3c1d989bb05c7ef404fd41c59995fe2231f79de65bef8c8c41033e8682000645&amp;width=600&amp;height=600&amp;lang=ru_RU&amp;scroll=true\"></script>");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tags",
                value: "[\"Model\",\"Visagiste\"]");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tags",
                value: "[\"Model\"]");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Tags",
                value: "[\"Model\"]");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Tags",
                value: "[\"Model\"]");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Tags",
                value: "[\"Model\"]");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Tags",
                value: "[\"Model\"]");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Tags",
                value: "[\"Model\"]");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Tags",
                value: "[\"Model\"]");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 9,
                column: "Tags",
                value: "[\"Model\"]");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Tags",
                value: "[\"Model\"]");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 11,
                column: "Tags",
                value: "[\"Model\"]");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 12,
                column: "Tags",
                value: "[\"Model\"]");
        }
    }
}
