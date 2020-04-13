using Microsoft.EntityFrameworkCore.Migrations;

namespace DabAflevering2.Migrations
{
    public partial class contextUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Students_StudentAuId",
                table: "Exercises");

            migrationBuilder.AlterColumn<int>(
                name: "StudentAuId",
                table: "Exercises",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Students_StudentAuId",
                table: "Exercises",
                column: "StudentAuId",
                principalTable: "Students",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Students_StudentAuId",
                table: "Exercises");

            migrationBuilder.AlterColumn<int>(
                name: "StudentAuId",
                table: "Exercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Students_StudentAuId",
                table: "Exercises",
                column: "StudentAuId",
                principalTable: "Students",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
