using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Stack_Overflow.Migrations
{
    /// <inheritdoc />
    public partial class QuestionUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Votes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Votes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Votes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Votes_AnswerId",
                table: "Votes",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_QuestionId",
                table: "Votes",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Answers_AnswerId",
                table: "Votes",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Question_QuestionId",
                table: "Votes",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Answers_AnswerId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Question_QuestionId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_AnswerId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_QuestionId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Votes");
        }
    }
}
