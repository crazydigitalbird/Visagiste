using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visagiste.Migrations
{
    public partial class RenameProperyFullNameToName_Photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Photos",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "image_1.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "image_2.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "image_3.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "image_4.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "image_5.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "image_6.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "image_7.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "image_8.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "image_9.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "image_10.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "image_11.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "image_12.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Photos",
                newName: "FullName");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FullName",
                value: "/images/image_1.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FullName",
                value: "/images/image_2.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FullName",
                value: "/images/image_3.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FullName",
                value: "/images/image_4.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FullName",
                value: "/images/image_5.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FullName",
                value: "/images/image_6.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FullName",
                value: "/images/image_7.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FullName",
                value: "/images/image_8.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FullName",
                value: "/images/image_9.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FullName",
                value: "/images/image_10.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FullName",
                value: "/images/image_11.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 12,
                column: "FullName",
                value: "/images/image_12.jpg");
        }
    }
}
