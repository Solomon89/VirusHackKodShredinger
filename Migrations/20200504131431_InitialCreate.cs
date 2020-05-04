using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VirusHackKodShredinger.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleId = table.Column<long>(nullable: false),
                    SubjectId = table.Column<long>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Peoples_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "Peoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Peoples",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Елена" },
                    { 2L, "Дмитрий" },
                    { 3L, "Иван" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Group", "Name" },
                values: new object[,]
                {
                    { 1L, null, "DataBase engine" },
                    { 2L, null, "ООП" },
                    { 3L, null, "Web Development" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "DateTime", "Note", "PeopleId", "SubjectId" },
                values: new object[] { 1L, new DateTime(2020, 5, 5, 14, 42, 0, 0, DateTimeKind.Unspecified), null, 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_PeopleId",
                table: "Schedules",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SubjectId",
                table: "Schedules",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
