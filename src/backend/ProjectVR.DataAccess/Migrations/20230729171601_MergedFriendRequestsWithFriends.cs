using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProjectVR.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MergedFriendRequestsWithFriends : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "AcceptedAt",
                table: "Friends",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("309f1f3c-39a7-4701-b38e-aa68dafff1d7"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("385f17c9-46b2-49f8-9425-9824369f6e84"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("407898b1-cf14-42a1-9b74-775587f878da"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("ca7a6018-0cf2-45da-a54c-0de1e7401bb4"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("fbfa8300-e0fd-410b-a7be-4357eb0fc6bc"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "AcceptedAt",
                table: "Friends",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromUserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ToUserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SentAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Usersinfo_FromUserGuid",
                        column: x => x.FromUserGuid,
                        principalTable: "Usersinfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Usersinfo_ToUserGuid",
                        column: x => x.ToUserGuid,
                        principalTable: "Usersinfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5116), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5116), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("309f1f3c-39a7-4701-b38e-aa68dafff1d7"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5093), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5094), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5127), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5128), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("385f17c9-46b2-49f8-9425-9824369f6e84"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5104), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5105), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("407898b1-cf14-42a1-9b74-775587f878da"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5054), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5087), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5112), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5113), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5124), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5125), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5109), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5109), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5119), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5120), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("ca7a6018-0cf2-45da-a54c-0de1e7401bb4"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5101), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5102), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("fbfa8300-e0fd-410b-a7be-4357eb0fc6bc"),
                columns: new[] { "CreatedAt", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5098), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5099), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_FromUserGuid",
                table: "FriendRequests",
                column: "FromUserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ToUserGuid",
                table: "FriendRequests",
                column: "ToUserGuid");
        }
    }
}
