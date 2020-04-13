using Microsoft.EntityFrameworkCore.Migrations;

namespace DabAflevering2.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    StudentEntityAuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Students_StudentEntityAuId",
                        column: x => x.StudentEntityAuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentAuId = table.Column<int>(nullable: false),
                    StudentsAuId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: false),
                    CoursesId = table.Column<int>(nullable: true),
                    Semester = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Students_StudentsAuId",
                        column: x => x.StudentsAuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherAuId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
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
                    StudentAuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<int>(nullable: false),
                    AssignmentsId = table.Column<int>(nullable: true),
                    StudentAuId = table.Column<int>(nullable: false),
                    StudentsAuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentStudents_Assignments_AssignmentsId",
                        column: x => x.AssignmentsId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignmentStudents_Students_StudentsAuId",
                        column: x => x.StudentsAuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_AssignmentStudents_AssignmentsId",
                table: "AssignmentStudents",
                column: "AssignmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentStudents_StudentsAuId",
                table: "AssignmentStudents",
                column: "StudentsAuId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentEntityAuId",
                table: "Courses",
                column: "StudentEntityAuId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_StudentAuId",
                table: "Exercises",
                column: "StudentAuId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TeacherAuId",
                table: "Exercises",
                column: "TeacherAuId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_CoursesId",
                table: "StudentsCourses",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_StudentsAuId",
                table: "StudentsCourses",
                column: "StudentsAuId");

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
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
