using Microsoft.EntityFrameworkCore.Migrations;

namespace FindADev.DAL.Migrations
{
    public partial class ChangeRoleIdToProfileId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Rate_RateId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_RateId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "RateId",
                table: "Profile");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Rate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rate_ProfileId",
                table: "Rate",
                column: "ProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_Profile_ProfileId",
                table: "Rate",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rate_Profile_ProfileId",
                table: "Rate");

            migrationBuilder.DropIndex(
                name: "IX_Rate_ProfileId",
                table: "Rate");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Rate");

            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "Profile",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profile_RateId",
                table: "Profile",
                column: "RateId",
                unique: true,
                filter: "[RateId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Rate_RateId",
                table: "Profile",
                column: "RateId",
                principalTable: "Rate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
