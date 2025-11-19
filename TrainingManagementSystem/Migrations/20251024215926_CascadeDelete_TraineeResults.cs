using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete_TraineeResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrsReslts_Courses_CrsId",
                table: "CrsReslts");

            migrationBuilder.DropForeignKey(
                name: "FK_CrsReslts_Trainees_TraineeId",
                table: "CrsReslts");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsReslts_Courses_CrsId",
                table: "CrsReslts",
                column: "CrsId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CrsReslts_Trainees_TraineeId",
                table: "CrsReslts",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrsReslts_Courses_CrsId",
                table: "CrsReslts");

            migrationBuilder.DropForeignKey(
                name: "FK_CrsReslts_Trainees_TraineeId",
                table: "CrsReslts");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsReslts_Courses_CrsId",
                table: "CrsReslts",
                column: "CrsId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsReslts_Trainees_TraineeId",
                table: "CrsReslts",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id");
        }
    }
}
