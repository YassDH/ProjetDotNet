using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetDotNet.Migrations
{
    /// <inheritdoc />
    public partial class Migration25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VotedSurveys_Surveys_SurveyId",
                table: "VotedSurveys");

            migrationBuilder.DropForeignKey(
                name: "FK_VotedSurveys_Users_UserId",
                table: "VotedSurveys");

            migrationBuilder.DropIndex(
                name: "IX_VotedSurveys_SurveyId",
                table: "VotedSurveys");

            migrationBuilder.DropIndex(
                name: "IX_VotedSurveys_UserId",
                table: "VotedSurveys");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "VotedSurveys",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "VotedSurveys",
                newName: "Survey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "VotedSurveys",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Survey",
                table: "VotedSurveys",
                newName: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_VotedSurveys_SurveyId",
                table: "VotedSurveys",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_VotedSurveys_UserId",
                table: "VotedSurveys",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_VotedSurveys_Surveys_SurveyId",
                table: "VotedSurveys",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VotedSurveys_Users_UserId",
                table: "VotedSurveys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
