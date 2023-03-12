using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class logentry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOG_ENTRIES",
                columns: table => new
                {
                    LOGID = table.Column<int>(name: "LOG_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    USERID = table.Column<int>(name: "USER_ID", type: "int", nullable: false),
                    FIELDTYPE = table.Column<string>(name: "FIELD_TYPE", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATE = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG_ENTRIES", x => x.LOGID);
                    table.ForeignKey(
                        name: "FK_LOG_ENTRIES_USERS_USER_ID",
                        column: x => x.USERID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LOG_ENTRIES_USER_ID",
                table: "LOG_ENTRIES",
                column: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOG_ENTRIES");
        }
    }
}
