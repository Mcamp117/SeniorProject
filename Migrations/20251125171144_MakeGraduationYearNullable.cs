using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EagleConnect.Migrations
{
    /// <inheritdoc />
    public partial class MakeGraduationYearNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GraduationYear",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3386));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3388));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3399));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3405));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3406));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3491));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3507));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3508));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3510));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3512));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3514));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 11, 43, 581, DateTimeKind.Utc).AddTicks(3516));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GraduationYear",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8631));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8656));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 20, 5, 13, 47, DateTimeKind.Utc).AddTicks(8770));
        }
    }
}
