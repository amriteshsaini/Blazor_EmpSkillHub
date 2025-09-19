using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpSkillHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "EmpSkills",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpSkills", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_EmpSkills_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FirstName_LastName_PhoneNumber",
                table: "Employees",
                columns: new[] { "FirstName", "LastName", "PhoneNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmpSkills_EmpId_SkillId",
                table: "EmpSkills",
                columns: new[] { "EmpId", "SkillId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmpSkills_SkillId",
                table: "EmpSkills",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpSkills");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
