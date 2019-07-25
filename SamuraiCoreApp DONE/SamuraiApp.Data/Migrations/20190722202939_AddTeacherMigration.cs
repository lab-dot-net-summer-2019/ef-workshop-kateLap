using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class AddTeacherMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Samurais",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_TeacherId",
                table: "Samurais",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Teachers_TeacherId",
                table: "Samurais",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Teachers_TeacherId",
                table: "Samurais");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_TeacherId",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Samurais");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Samurais",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KillStreak",
                table: "SamuraiBattle",
                nullable: false,
                defaultValue: 0);
        }
    }
}
