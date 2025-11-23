using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EagleConnect.Migrations
{
    /// <inheritdoc />
    public partial class RemoveYearField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "AspNetUsers",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7801));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7803));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7811));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7812));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7815));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 23, 9, 18, 420, DateTimeKind.Utc).AddTicks(7828));
        }
    }
}
