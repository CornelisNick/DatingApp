using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDM.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProviderName = table.Column<string>(nullable: false),
                    Params = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issuers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IssuerName = table.Column<string>(nullable: false),
                    PrivateKey = table.Column<string>(nullable: false),
                    ProviderId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issuers_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IssuerId = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Issuers_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "Issuers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "Params", "ProviderName" },
                values: new object[] { "375c4e43-1917-4247-91e0-924f40036815", "No parms", "Platform" });

            migrationBuilder.InsertData(
                table: "Issuers",
                columns: new[] { "Id", "IssuerName", "PrivateKey", "ProviderId" },
                values: new object[] { "c1e15789-fcde-41c4-930a-2fd64d20a86c", "Platform issuer", "My private key", "375c4e43-1917-4247-91e0-924f40036815" });

            migrationBuilder.InsertData(
                table: "Issuers",
                columns: new[] { "Id", "IssuerName", "PrivateKey", "ProviderId" },
                values: new object[] { "35b66516-f61c-4fad-8881-e32148f1d9e5", "Reseller issuer", "My private key", "375c4e43-1917-4247-91e0-924f40036815" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IssuerId", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { "bdc19f3d-e88d-4403-86e8-aa3c7e007c17", "c1e15789-fcde-41c4-930a-2fd64d20a86c", new byte[] { 124, 27, 129, 105, 198, 152, 64, 139, 212, 16, 63, 137, 229, 153, 76, 3, 192, 0, 238, 117, 159, 114, 140, 177, 124, 31, 206, 112, 210, 193, 76, 176, 12, 100, 71, 229, 171, 64, 63, 130, 57, 41, 227, 76, 139, 131, 212, 214, 251, 47, 125, 77, 6, 247, 228, 142, 102, 133, 73, 35, 30, 245, 51, 109 }, new byte[] { 255, 145, 53, 247, 195, 215, 159, 144, 133, 56, 4, 12, 1, 60, 219, 38, 249, 58, 231, 190, 205, 120, 93, 146, 2, 148, 205, 198, 251, 191, 133, 243, 194, 233, 184, 61, 198, 177, 36, 70, 138, 240, 47, 18, 124, 223, 252, 245, 106, 42, 248, 21, 202, 100, 155, 119, 113, 252, 192, 95, 31, 80, 33, 208, 94, 235, 145, 157, 201, 206, 99, 136, 31, 100, 100, 93, 72, 146, 57, 224, 30, 204, 73, 31, 149, 113, 205, 144, 86, 197, 25, 219, 221, 139, 148, 193, 57, 160, 105, 172, 232, 132, 132, 69, 159, 83, 164, 105, 48, 86, 70, 85, 252, 72, 13, 86, 0, 249, 215, 55, 126, 110, 133, 90, 128, 131, 213, 12 }, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IssuerId", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { "d0cf1d16-0cd8-40a0-9873-10b74d0daa9c", "c1e15789-fcde-41c4-930a-2fd64d20a86c", new byte[] { 124, 27, 129, 105, 198, 152, 64, 139, 212, 16, 63, 137, 229, 153, 76, 3, 192, 0, 238, 117, 159, 114, 140, 177, 124, 31, 206, 112, 210, 193, 76, 176, 12, 100, 71, 229, 171, 64, 63, 130, 57, 41, 227, 76, 139, 131, 212, 214, 251, 47, 125, 77, 6, 247, 228, 142, 102, 133, 73, 35, 30, 245, 51, 109 }, new byte[] { 255, 145, 53, 247, 195, 215, 159, 144, 133, 56, 4, 12, 1, 60, 219, 38, 249, 58, 231, 190, 205, 120, 93, 146, 2, 148, 205, 198, 251, 191, 133, 243, 194, 233, 184, 61, 198, 177, 36, 70, 138, 240, 47, 18, 124, 223, 252, 245, 106, 42, 248, 21, 202, 100, 155, 119, 113, 252, 192, 95, 31, 80, 33, 208, 94, 235, 145, 157, 201, 206, 99, 136, 31, 100, 100, 93, 72, 146, 57, 224, 30, 204, 73, 31, 149, 113, 205, 144, 86, 197, 25, 219, 221, 139, 148, 193, 57, 160, 105, 172, 232, 132, 132, 69, 159, 83, 164, 105, 48, 86, 70, 85, 252, 72, 13, 86, 0, 249, 215, 55, 126, 110, 133, 90, 128, 131, 213, 12 }, "user1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IssuerId", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { "96c7044f-8b0e-404c-81b0-8019dd0120d6", "35b66516-f61c-4fad-8881-e32148f1d9e5", new byte[] { 124, 27, 129, 105, 198, 152, 64, 139, 212, 16, 63, 137, 229, 153, 76, 3, 192, 0, 238, 117, 159, 114, 140, 177, 124, 31, 206, 112, 210, 193, 76, 176, 12, 100, 71, 229, 171, 64, 63, 130, 57, 41, 227, 76, 139, 131, 212, 214, 251, 47, 125, 77, 6, 247, 228, 142, 102, 133, 73, 35, 30, 245, 51, 109 }, new byte[] { 255, 145, 53, 247, 195, 215, 159, 144, 133, 56, 4, 12, 1, 60, 219, 38, 249, 58, 231, 190, 205, 120, 93, 146, 2, 148, 205, 198, 251, 191, 133, 243, 194, 233, 184, 61, 198, 177, 36, 70, 138, 240, 47, 18, 124, 223, 252, 245, 106, 42, 248, 21, 202, 100, 155, 119, 113, 252, 192, 95, 31, 80, 33, 208, 94, 235, 145, 157, 201, 206, 99, 136, 31, 100, 100, 93, 72, 146, 57, 224, 30, 204, 73, 31, 149, 113, 205, 144, 86, 197, 25, 219, 221, 139, 148, 193, 57, 160, 105, 172, 232, 132, 132, 69, 159, 83, 164, 105, 48, 86, 70, 85, 252, 72, 13, 86, 0, 249, 215, 55, 126, 110, 133, 90, 128, 131, 213, 12 }, "reseller_admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IssuerId", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { "9bd58c40-ab1b-4dc1-9be7-27015ce669ce", "35b66516-f61c-4fad-8881-e32148f1d9e5", new byte[] { 124, 27, 129, 105, 198, 152, 64, 139, 212, 16, 63, 137, 229, 153, 76, 3, 192, 0, 238, 117, 159, 114, 140, 177, 124, 31, 206, 112, 210, 193, 76, 176, 12, 100, 71, 229, 171, 64, 63, 130, 57, 41, 227, 76, 139, 131, 212, 214, 251, 47, 125, 77, 6, 247, 228, 142, 102, 133, 73, 35, 30, 245, 51, 109 }, new byte[] { 255, 145, 53, 247, 195, 215, 159, 144, 133, 56, 4, 12, 1, 60, 219, 38, 249, 58, 231, 190, 205, 120, 93, 146, 2, 148, 205, 198, 251, 191, 133, 243, 194, 233, 184, 61, 198, 177, 36, 70, 138, 240, 47, 18, 124, 223, 252, 245, 106, 42, 248, 21, 202, 100, 155, 119, 113, 252, 192, 95, 31, 80, 33, 208, 94, 235, 145, 157, 201, 206, 99, 136, 31, 100, 100, 93, 72, 146, 57, 224, 30, 204, 73, 31, 149, 113, 205, 144, 86, 197, 25, 219, 221, 139, 148, 193, 57, 160, 105, 172, 232, 132, 132, 69, 159, 83, 164, 105, 48, 86, 70, 85, 252, 72, 13, 86, 0, 249, 215, 55, 126, 110, 133, 90, 128, 131, 213, 12 }, "reseller_user1" });

            migrationBuilder.CreateIndex(
                name: "IX_Issuers_IssuerName",
                table: "Issuers",
                column: "IssuerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issuers_ProviderId",
                table: "Issuers",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_ProviderName",
                table: "Providers",
                column: "ProviderName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IssuerId",
                table: "Users",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Issuers");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
