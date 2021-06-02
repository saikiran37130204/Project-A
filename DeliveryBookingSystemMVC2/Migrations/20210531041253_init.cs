using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryBookingSystemMVC2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pincode = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    isVerified = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "deliveryExecutives",
                columns: table => new
                {
                    executiveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isVerified = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryExecutives", x => x.executiveID);
                });
            migrationBuilder.CreateTable(
               name: "bookings",
               columns: table => new
               {
                   orderID = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   customerID = table.Column<int>(type: "int", nullable: false),
                   executiveID = table.Column<int>(type: "int", nullable: false),
                   date = table.Column<DateTime>(type: "datetime2", nullable: false),
                   weight = table.Column<float>(type: "real", nullable: false),
                   price = table.Column<float>(type: "real", nullable: false),
                   address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   pincode = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                   phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                   status = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_bookings", x => x.orderID);
                   table.ForeignKey(
                                        name: "FK_bookings_customers_customerID",
                                        column: x => x.customerID,
                                        principalTable: "customers",
                                        principalColumn: "customerID",
                                        onDelete: ReferentialAction.Restrict);
                   table.ForeignKey(
                       name: "FK_bookings_deliveryExecutives_executiveID",
                       column: x => x.executiveID,
                       principalTable: "deliveryExecutives",
                       principalColumn: "executiveID",
                       onDelete: ReferentialAction.Restrict);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "deliveryExecutives");
        }
    }
}
