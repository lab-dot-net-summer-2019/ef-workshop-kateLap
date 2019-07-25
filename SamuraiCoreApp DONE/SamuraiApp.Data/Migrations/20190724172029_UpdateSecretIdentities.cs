using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class UpdateSecretIdentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_SecretIdentities_Id",
                table: "Samurais");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Samurais",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "SecretIdentityId",
                table: "Samurais",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_SecretIdentityId",
                table: "Samurais",
                column: "SecretIdentityId",
                unique: true,
                filter: "[SecretIdentityId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_SecretIdentities_SecretIdentityId",
                table: "Samurais",
                column: "SecretIdentityId",
                principalTable: "SecretIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_SecretIdentities_SecretIdentityId",
                table: "Samurais");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_SecretIdentityId",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "SecretIdentityId",
                table: "Samurais");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Samurais",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_SecretIdentities_Id",
                table: "Samurais",
                column: "Id",
                principalTable: "SecretIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
