using Microsoft.EntityFrameworkCore.Migrations;

namespace DabAflevering2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    AuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.AuId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    AuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.AuId);
                    table.ForeignKey(
                        name: "FK_Teachers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourses",
                columns: table => new
                {
                    StudentAuId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Semester = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourses", x => new { x.StudentAuId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Students_StudentAuId",
                        column: x => x.StudentAuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherAuId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Teachers_TeacherAuId",
                        column: x => x.TeacherAuId,
                        principalTable: "Teachers",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    Lecture = table.Column<string>(nullable: false),
                    HelpWhere = table.Column<string>(nullable: true),
                    TeacherAuId = table.Column<int>(nullable: true),
                    StudentAuId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercises_Students_StudentAuId",
                        column: x => x.StudentAuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercises_Teachers_TeacherAuId",
                        column: x => x.TeacherAuId,
                        principalTable: "Teachers",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentStudents",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(nullable: false),
                    StudentAuId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    NeedHelp = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentStudents", x => new { x.StudentAuId, x.AssignmentId });
                    table.ForeignKey(
                        name: "FK_AssignmentStudents_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentStudents_Students_StudentAuId",
                        column: x => x.StudentAuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseId",
                table: "Assignments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherAuId",
                table: "Assignments",
                column: "TeacherAuId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentStudents_AssignmentId",
                table: "AssignmentStudents",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CourseId",
                table: "Exercises",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_StudentAuId",
                table: "Exercises",
                column: "StudentAuId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TeacherAuId",
                table: "Exercises",
                column: "TeacherAuId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_CourseId",
                table: "StudentsCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CourseId",
                table: "Teachers",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentStudents");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "StudentsCourses");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
