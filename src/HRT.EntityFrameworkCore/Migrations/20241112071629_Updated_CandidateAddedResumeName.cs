using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRT.Migrations
{
    /// <inheritdoc />
    public partial class Updated_CandidateAddedResumeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResumeName",
                table: "AppCandidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResumeName",
                table: "AppCandidates");
        }
    }
}
