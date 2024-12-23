using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Stack_Overflow.Migrations
{
    /// <inheritdoc />
    public partial class QuestionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_AspNetUsers_ApplicationUsersId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_ApplicationUsersId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ApplicationUsersId",
                table: "Question");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Question",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Question",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUsersId",
                table: "Question",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_ApplicationUsersId",
                table: "Question",
                column: "ApplicationUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AspNetUsers_ApplicationUsersId",
                table: "Question",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
