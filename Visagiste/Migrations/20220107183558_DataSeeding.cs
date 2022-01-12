using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visagiste.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Avatar_AvatarId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Contact_ContactId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_AvatarId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_ContactId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "AvatarId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Owners");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Contact",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Avatar",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "AboutMe", "Banners", "Name" },
                values: new object[] { 1, "I am A Photographer from America Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.", "[\"/images/SeedData/banner-1.jpg\",\"/images/SeedData/banner-2.jpg\"]", "Ivan Ivanov" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "FullName", "Tags" },
                values: new object[] { 1, "/images/image_1.jpg", "[\"Model\",\"Visagiste\"]" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "FullName", "Tags" },
                values: new object[] { 2, "/images/image_2.jpg", "[\"Model\"]" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "FullName", "Tags" },
                values: new object[] { 3, "/images/image_3.jpg", "[\"Model\"]" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "FullName", "Tags" },
                values: new object[] { 4, "/images/image_4.jpg", "[\"Model\"]" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "FullName", "Tags" },
                values: new object[] { 5, "/images/image_5.jpg", "[\"Model\"]" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "FullName", "Tags" },
                values: new object[] { 6, "/images/image_6.jpg", "[\"Model\"]" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "FullName", "Tags" },
                values: new object[] { 7, "/images/image_7.jpg", "[\"Model\"]" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "FullName", "Tags" },
                values: new object[] { 8, "/images/image_8.jpg", "[\"Model\"]" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "FullName", "Tags" },
                values: new object[] { 9, "/images/image_9.jpg", "[\"Model\"]" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "FullName", "Tags" },
                values: new object[] { 10, "/images/image_10.jpg", "[\"Model\"]" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "FullName", "Tags" },
                values: new object[] { 11, "/images/image_11.jpg", "[\"Model\"]" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "FullName", "Tags" },
                values: new object[] { 12, "/images/image_12.jpg", "[\"Model\"]" });

            migrationBuilder.InsertData(
                table: "Avatar",
                columns: new[] { "Id", "OwnerId", "Url", "X", "Y" },
                values: new object[] { 1, 1, "/images/author.jpg", 0, 0 });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Address", "Email", "InstagramUrl", "OwnerId", "Phone", "VkUrl" },
                values: new object[] { 1, "203 Fake St. Mountain View, San Francisco, California, USA", "info@yourdomain.com", "https://www.instagram.com/", 1, "+2 392 3929 210", "https://vk.com/" });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_OwnerId",
                table: "Contact",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Avatar_OwnerId",
                table: "Avatar",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Avatar_Owners_OwnerId",
                table: "Avatar",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Owners_OwnerId",
                table: "Contact",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avatar_Owners_OwnerId",
                table: "Avatar");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Owners_OwnerId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_OwnerId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Avatar_OwnerId",
                table: "Avatar");

            migrationBuilder.DeleteData(
                table: "Avatar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Avatar");

            migrationBuilder.AddColumn<int>(
                name: "AvatarId",
                table: "Owners",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Owners",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_AvatarId",
                table: "Owners",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_ContactId",
                table: "Owners",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Avatar_AvatarId",
                table: "Owners",
                column: "AvatarId",
                principalTable: "Avatar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Contact_ContactId",
                table: "Owners",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id");
        }
    }
}
