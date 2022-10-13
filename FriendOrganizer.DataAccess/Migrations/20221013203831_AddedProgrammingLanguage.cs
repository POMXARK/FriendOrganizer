using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendOrganizer.DataAccess.Migrations
{
    public partial class AddedProgrammingLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoriteLanguageId",
                table: "Friends",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FavoriteLanguageId",
                table: "Friends",
                column: "FavoriteLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_ProgrammingLanguages_FavoriteLanguageId",
                table: "Friends",
                column: "FavoriteLanguageId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_ProgrammingLanguages_FavoriteLanguageId",
                table: "Friends");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Friends_FavoriteLanguageId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "FavoriteLanguageId",
                table: "Friends");
        }
    }
}
