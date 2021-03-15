using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseWork.Data.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_first_name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    user_last_name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    book_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    book_isbn = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    book_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    book_description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    book_publish_year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("book_pkey", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_Books_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KeyWordModel",
                columns: table => new
                {
                    key_word_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    key_word = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    BookModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("key_word_pkey", x => x.key_word_id);
                    table.ForeignKey(
                        name: "FK_KeyWordModel_Books_BookModelId",
                        column: x => x.BookModelId,
                        principalTable: "Books",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyWordModel_BookModelId",
                table: "KeyWordModel",
                column: "BookModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyWordModel");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
