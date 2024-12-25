using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7009645a-6244-4463-b8b3-b11fab9958e2", "AQAAAAIAAYagAAAAEBsdI+2TP25BdjpvnpvCdlm92dzYyaDAkpteb5JBAU/bVAXQlBQLa1Jju4EPSs5buw==", "0af85e1e-9aec-4588-822b-0b16b769b4cc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd1d1356-fe72-4759-8f1b-bcab49fa6d08", "AQAAAAIAAYagAAAAEFybNO966VleLVPP06FY4OPV1Dh4DtuV0KhLpguvwMiuQWPffC5XtE7t119LucnWEQ==", "ca23ee11-73af-45d3-83b3-ff1b6c16d359" });
        }
    }
}
