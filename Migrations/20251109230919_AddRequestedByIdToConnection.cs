using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EagleConnect.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestedByIdToConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestedById",
                table: "Connections",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            // Set RequestedById to User1Id for existing connections (best guess)
            migrationBuilder.Sql("UPDATE Connections SET RequestedById = User1Id WHERE RequestedById IS NULL");

            // Now make it required
            migrationBuilder.AlterColumn<string>(
                name: "RequestedById",
                table: "Connections",
                type: "varchar(255)",
                nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Connections_RequestedById",
                table: "Connections",
                column: "RequestedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_AspNetUsers_RequestedById",
                table: "Connections",
                column: "RequestedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_AspNetUsers_RequestedById",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_RequestedById",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "RequestedById",
                table: "Connections");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1001));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1013));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1015));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1127));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1129));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1131));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1132));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1133));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1136));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 0, 10, 19, 685, DateTimeKind.Utc).AddTicks(1141));
        }
    }
}
