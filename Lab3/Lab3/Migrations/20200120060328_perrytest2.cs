using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab3.Migrations
{
    public partial class perrytest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceCode1",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_ProvinceCode1",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ProvinceCode1",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceCode",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceCode",
                table: "Cities",
                column: "ProvinceCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceCode",
                table: "Cities",
                column: "ProvinceCode",
                principalTable: "Provinces",
                principalColumn: "ProvinceCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceCode",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_ProvinceCode",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceCode",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ProvinceCode1",
                table: "Cities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceCode1",
                table: "Cities",
                column: "ProvinceCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceCode1",
                table: "Cities",
                column: "ProvinceCode1",
                principalTable: "Provinces",
                principalColumn: "ProvinceCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
