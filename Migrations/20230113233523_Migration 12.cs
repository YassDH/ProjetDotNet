using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetDotNet.Migrations
{
    /// <inheritdoc />
    public partial class Migration12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Surveys_SurveyId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_SurveyId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Options");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "Options",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_SurveyId",
                table: "Options",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Surveys_SurveyId",
                table: "Options",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id");
        }
    }
}
