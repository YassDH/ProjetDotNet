using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetDotNet.Migrations
{
    /// <inheritdoc />
    public partial class Migration26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "VotedSurveys",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "Survey",
                table: "VotedSurveys",
                newName: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_VotedSurveys_SurveyId",
                table: "VotedSurveys",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_VotedSurveys_UsersId",
                table: "VotedSurveys",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_VotedSurveys_Surveys_SurveyId",
                table: "VotedSurveys",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VotedSurveys_Users_UsersId",
                table: "VotedSurveys",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VotedSurveys_Surveys_SurveyId",
                table: "VotedSurveys");

            migrationBuilder.DropForeignKey(
                name: "FK_VotedSurveys_Users_UsersId",
                table: "VotedSurveys");

            migrationBuilder.DropIndex(
                name: "IX_VotedSurveys_SurveyId",
                table: "VotedSurveys");

            migrationBuilder.DropIndex(
                name: "IX_VotedSurveys_UsersId",
                table: "VotedSurveys");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "VotedSurveys",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "VotedSurveys",
                newName: "Survey");
        }
    }
}
