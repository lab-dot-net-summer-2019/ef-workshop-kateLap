using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Teachers_TeacherId",
                table: "Samurais");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiId",
                table: "SecretIdentity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecretIdentity",
                table: "SecretIdentity");

            migrationBuilder.DropIndex(
                name: "IX_SecretIdentity_SamuraiId",
                table: "SecretIdentity");

            migrationBuilder.DropColumn(
                name: "SamuraiId",
                table: "SecretIdentity");

            migrationBuilder.RenameTable(
                name: "SecretIdentity",
                newName: "SecretIdentities");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Samurais",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Samurais",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecretIdentities",
                table: "SecretIdentities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_SecretIdentities_Id",
                table: "Samurais",
                column: "Id",
                principalTable: "SecretIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Teachers_TeacherId",
                table: "Samurais",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_SecretIdentities_Id",
                table: "Samurais");

            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Teachers_TeacherId",
                table: "Samurais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecretIdentities",
                table: "SecretIdentities");

            migrationBuilder.RenameTable(
                name: "SecretIdentities",
                newName: "SecretIdentity");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Samurais",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Samurais",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "SamuraiId",
                table: "SecretIdentity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecretIdentity",
                table: "SecretIdentity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentity_SamuraiId",
                table: "SecretIdentity",
                column: "SamuraiId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Teachers_TeacherId",
                table: "Samurais",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiId",
                table: "SecretIdentity",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
