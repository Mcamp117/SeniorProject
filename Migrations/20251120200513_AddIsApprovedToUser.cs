using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EagleConnect.Migrations
{
    /// <inheritdoc />
    public partial class AddIsApprovedToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2736));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2754));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2757));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2762));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2764));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2774));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2792));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 28, 5, 868, DateTimeKind.Utc).AddTicks(2800));
        }
    }
}
