using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class SeededDefaultRolesAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ce23114-07fe-4862-89a7-08bc5fd62781", "fef1340f-3543-4865-a0bf-25d26f76ab74", "User", "USER" },
                    { "a7fbbd7d-2634-48bf-9304-56197e3edd91", "965fef41-7fca-4ed5-9b0a-ff1913a614d2", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "08373b78-1b9d-4bc6-b5c3-d619eb65eafa", 0, "077320c5-204c-49d5-8729-9e0e9f9dae8c", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEOvFN1xbqb4K8gAV2/f35uNOETsH+fqjxmMvUwA13w8OtDL2OV+Xdkc/LytPuMtiog==", null, false, "88d1e854-c836-403e-be69-1946cd740fbb", false, "admin@bookstore.com" },
                    { "b6649e1e-47ea-4d15-9995-5ccbd163fee9", 0, "43c92366-1258-4db7-83e3-23ff949d7f88", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEKYoF+GJNddGfhj/ReJRbDTULxMO5HnYP95vr0a4T84QQUET3eg7fJY8DYET2owuFw==", null, false, "aee2e80e-505f-4479-b4cf-55f30792d20c", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a7fbbd7d-2634-48bf-9304-56197e3edd91", "08373b78-1b9d-4bc6-b5c3-d619eb65eafa" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4ce23114-07fe-4862-89a7-08bc5fd62781", "b6649e1e-47ea-4d15-9995-5ccbd163fee9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a7fbbd7d-2634-48bf-9304-56197e3edd91", "08373b78-1b9d-4bc6-b5c3-d619eb65eafa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ce23114-07fe-4862-89a7-08bc5fd62781", "b6649e1e-47ea-4d15-9995-5ccbd163fee9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ce23114-07fe-4862-89a7-08bc5fd62781");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7fbbd7d-2634-48bf-9304-56197e3edd91");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08373b78-1b9d-4bc6-b5c3-d619eb65eafa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6649e1e-47ea-4d15-9995-5ccbd163fee9");
        }
    }
}
