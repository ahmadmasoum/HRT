using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRT.Migrations
{
    /// <inheritdoc />
    public partial class Removed_ResumeFromCandidateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resume",
                table: "AppCandidates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Resume",
                table: "AppCandidates",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
