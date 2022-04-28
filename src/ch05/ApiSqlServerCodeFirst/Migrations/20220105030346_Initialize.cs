using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiSqlServerCodeFirst.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WpPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostAuthor = table.Column<int>(type: "int", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostDateGmt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostExcerpt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToPing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pinged = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostModifiedGmt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostContentFiltered = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostParent = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuOrder = table.Column<int>(type: "int", nullable: false),
                    PostType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostMimeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WpPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WpUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNicename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserActivationKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserStatus = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WpUsers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WpPosts");

            migrationBuilder.DropTable(
                name: "WpUsers");
        }
    }
}
