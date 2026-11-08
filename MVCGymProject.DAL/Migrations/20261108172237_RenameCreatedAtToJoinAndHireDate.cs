using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCGymProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameCreatedAtToJoinAndHireDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Trainers",
                newName: "HireDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Members",
                newName: "JoinDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HireDate",
                table: "Trainers",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "JoinDate",
                table: "Members",
                newName: "CreatedAt");
        }
    }
}
