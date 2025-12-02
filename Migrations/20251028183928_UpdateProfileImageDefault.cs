using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EagleConnect.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfileImageDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfileImage",
                table: "AspNetUsers",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "/images/default-avatar.svg",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(201));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(211));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(217));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(219));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(229));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 18, 39, 28, 53, DateTimeKind.Utc).AddTicks(249));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfileImage",
                table: "AspNetUsers",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldDefaultValue: "/images/default-avatar.svg")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2878));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2879));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2891));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2895));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2896));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2899));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2900));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2901));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2906));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2909));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2912));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 45, 26, 44, DateTimeKind.Utc).AddTicks(2913));
        }
    }
}
