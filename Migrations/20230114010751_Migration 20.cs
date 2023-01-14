using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetDotNet.Migrations
{
    /// <inheritdoc />
    public partial class Migration20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "nbVotesChoix1",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "nbVotesChoix2",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "nbVotesChoix3",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "nbVotesChoix4",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "nbVotesChoix5",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "nbVotesChoix6",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nbVotesChoix1",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "nbVotesChoix2",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "nbVotesChoix3",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "nbVotesChoix4",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "nbVotesChoix5",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "nbVotesChoix6",
                table: "Surveys");
        }
    }
}
