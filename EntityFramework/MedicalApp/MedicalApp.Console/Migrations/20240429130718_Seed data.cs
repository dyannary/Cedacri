using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalApp.Console.Migrations
{
    /// <inheritdoc />
    public partial class Seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DoctorPacient",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPacient", x => new { x.DoctorId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_DoctorPacient_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPacient_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "Email", "Name", "Username" },
                values: new object[] { 1, "user1@mail.com", "User1", "Test1" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Email", "Idnp", "Name", "Phone" },
                values: new object[] { 1, "user@mail.com", "32434323131", "TestPatient1", "03982821" });

            migrationBuilder.InsertData(
                table: "DoctorPacient",
                columns: new[] { "DoctorId", "PatientId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPacient_PatientId",
                table: "DoctorPacient",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPacient");

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Email",
                table: "Doctor",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
