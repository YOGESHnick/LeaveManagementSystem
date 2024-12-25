using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLeaveRequestTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "leaveRequestStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveRequestStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "leaveRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    LeaveRequestStatusId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leaveRequest_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaveRequest_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_leaveRequest_LeavesTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeavesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaveRequest_leaveRequestStatuses_LeaveRequestStatusId",
                        column: x => x.LeaveRequestStatusId,
                        principalTable: "leaveRequestStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd1d1356-fe72-4759-8f1b-bcab49fa6d08", "AQAAAAIAAYagAAAAEFybNO966VleLVPP06FY4OPV1Dh4DtuV0KhLpguvwMiuQWPffC5XtE7t119LucnWEQ==", "ca23ee11-73af-45d3-83b3-ff1b6c16d359" });

            migrationBuilder.InsertData(
                table: "leaveRequestStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Approved" },
                    { 3, "Declined" },
                    { 4, "Canceled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequest_EmployeeId",
                table: "leaveRequest",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequest_LeaveRequestStatusId",
                table: "leaveRequest",
                column: "LeaveRequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequest_LeaveTypeId",
                table: "leaveRequest",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequest_ReviewerId",
                table: "leaveRequest",
                column: "ReviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaveRequest");

            migrationBuilder.DropTable(
                name: "leaveRequestStatuses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8b68be0-f469-4a6a-b218-13d6fe3f7993", "AQAAAAIAAYagAAAAEJoC7Au85Fya0j9sNev2wfFDmFX6iiyBuNwA4MaRce7A8qUkiJ8il/9Sc8NOcTApHg==", "1952be42-a655-40ff-8f49-64ee2bdc21b7" });
        }
    }
}
