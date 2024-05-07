using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalApp.API.Migrations
{
    /// <inheritdoc />
    public partial class EntityModifyied : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorsId",
                table: "DoctorPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Patients_PatientsId",
                table: "DoctorPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatients_Patients_PatientId",
                table: "DoctorPatients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Pacient");

            migrationBuilder.RenameColumn(
                name: "PacientId",
                table: "Recipes",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "PacientId",
                table: "MedicalRecords",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Doctors",
                newName: "doctor_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctors",
                newName: "doctor_id");

            migrationBuilder.RenameColumn(
                name: "DoctorsId",
                table: "DoctorPatient",
                newName: "DoctorsIdent");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pacient",
                newName: "patient_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecordDate",
                table: "MedicalRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Doctors",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Idnp",
                table: "Pacient",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pacient",
                table: "Pacient",
                column: "patient_id");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 1,
                columns: new[] { "DoctorId", "PatientId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_PatientId",
                table: "Recipes",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorsIdent",
                table: "DoctorPatient",
                column: "DoctorsIdent",
                principalTable: "Doctors",
                principalColumn: "doctor_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Pacient_PatientsId",
                table: "DoctorPatient",
                column: "PatientsId",
                principalTable: "Pacient",
                principalColumn: "patient_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatients_Pacient_PatientId",
                table: "DoctorPatients",
                column: "PatientId",
                principalTable: "Pacient",
                principalColumn: "patient_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Pacient_PatientId",
                table: "MedicalRecords",
                column: "PatientId",
                principalTable: "Pacient",
                principalColumn: "patient_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Pacient_PatientId",
                table: "Recipes",
                column: "PatientId",
                principalTable: "Pacient",
                principalColumn: "patient_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorsIdent",
                table: "DoctorPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Pacient_PatientsId",
                table: "DoctorPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatients_Pacient_PatientId",
                table: "DoctorPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Pacient_PatientId",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Pacient_PatientId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_PatientId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pacient",
                table: "Pacient");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Pacient",
                newName: "Patients");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Recipes",
                newName: "PacientId");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "MedicalRecords",
                newName: "PacientId");

            migrationBuilder.RenameColumn(
                name: "doctor_name",
                table: "Doctors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "doctor_id",
                table: "Doctors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DoctorsIdent",
                table: "DoctorPatient",
                newName: "DoctorsId");

            migrationBuilder.RenameColumn(
                name: "patient_id",
                table: "Patients",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecordDate",
                table: "MedicalRecords",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Idnp",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorsId",
                table: "DoctorPatient",
                column: "DoctorsId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Patients_PatientsId",
                table: "DoctorPatient",
                column: "PatientsId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatients_Patients_PatientId",
                table: "DoctorPatients",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
