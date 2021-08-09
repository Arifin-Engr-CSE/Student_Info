using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Info.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentClasses",
                columns: table => new
                {
                    StudentClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClasses", x => x.StudentClassId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    AddmissionDate = table.Column<DateTime>(nullable: false),
                    StudentClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_StudentClasses_StudentClassId",
                        column: x => x.StudentClassId,
                        principalTable: "StudentClasses",
                        principalColumn: "StudentClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentClassId",
                table: "Students",
                column: "StudentClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudentClasses");
        }
    }
}
