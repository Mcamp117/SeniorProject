using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EagleConnect.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizationFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModeratorId",
                table: "StudentOrganizations",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationMembershipRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequestedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProcessedById = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RejectionReason = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationMembershipRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationMembershipRequests_AspNetUsers_ProcessedById",
                        column: x => x.ProcessedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrganizationMembershipRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationMembershipRequests_StudentOrganizations_Organiza~",
                        column: x => x.OrganizationId,
                        principalTable: "StudentOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SentAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationMessages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationMessages_StudentOrganizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "StudentOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsPinned = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationPosts_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationPosts_StudentOrganizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "StudentOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7582));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 43, 50, 369, DateTimeKind.Utc).AddTicks(7583));

            migrationBuilder.CreateIndex(
                name: "IX_StudentOrganizations_ModeratorId",
                table: "StudentOrganizations",
                column: "ModeratorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMembershipRequests_OrganizationId_UserId_Status",
                table: "OrganizationMembershipRequests",
                columns: new[] { "OrganizationId", "UserId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMembershipRequests_ProcessedById",
                table: "OrganizationMembershipRequests",
                column: "ProcessedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMembershipRequests_UserId",
                table: "OrganizationMembershipRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMessages_OrganizationId",
                table: "OrganizationMessages",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMessages_SenderId",
                table: "OrganizationMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMessages_SentAt",
                table: "OrganizationMessages",
                column: "SentAt");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPosts_AuthorId",
                table: "OrganizationPosts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPosts_CreatedAt",
                table: "OrganizationPosts",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPosts_OrganizationId",
                table: "OrganizationPosts",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentOrganizations_AspNetUsers_ModeratorId",
                table: "StudentOrganizations",
                column: "ModeratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentOrganizations_AspNetUsers_ModeratorId",
                table: "StudentOrganizations");

            migrationBuilder.DropTable(
                name: "OrganizationMembershipRequests");

            migrationBuilder.DropTable(
                name: "OrganizationMessages");

            migrationBuilder.DropTable(
                name: "OrganizationPosts");

            migrationBuilder.DropIndex(
                name: "IX_StudentOrganizations_ModeratorId",
                table: "StudentOrganizations");

            migrationBuilder.DropColumn(
                name: "ModeratorId",
                table: "StudentOrganizations");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9143));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9147));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9153));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 17, 20, 45, 155, DateTimeKind.Utc).AddTicks(9178));
        }
    }
}
