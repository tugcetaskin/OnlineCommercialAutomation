using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCommercialAutomation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: false),
                    Authority = table.Column<string>(type: "Char(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatagoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatagoryName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CatagoryId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoicetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceSerialNumber = table.Column<string>(type: "Char(1)", maxLength: 1, nullable: false),
                    InvoiceSequenceNumber = table.Column<string>(type: "Varchar(6)", maxLength: 6, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxAdministration = table.Column<string>(type: "Varchar(60)", maxLength: 60, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deliverer = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    Receiver = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoicetId);
                });

            migrationBuilder.CreateTable(
                name: "SalesMoves",
                columns: table => new
                {
                    SalesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesMoves", x => x.SalesId);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    InvoiceItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoicetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.InvoiceItemId);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoicetId",
                        column: x => x.InvoicetId,
                        principalTable: "Invoices",
                        principalColumn: "InvoicetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    CustomerLastName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    CustomerCity = table.Column<string>(type: "Varchar(15)", maxLength: 15, nullable: false),
                    CustomerEmail = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    SalesMoveSalesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_SalesMoves_SalesMoveSalesId",
                        column: x => x.SalesMoveSalesId,
                        principalTable: "SalesMoves",
                        principalColumn: "SalesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    EmployeeLastName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    EmployeeImage = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: false),
                    SalesMoveSalesId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_SalesMoves_SalesMoveSalesId",
                        column: x => x.SalesMoveSalesId,
                        principalTable: "SalesMoves",
                        principalColumn: "SalesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<short>(type: "smallint", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Condition = table.Column<bool>(type: "bit", nullable: false),
                    ProductImage = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: false),
                    CategoryCatagoryId = table.Column<int>(type: "int", nullable: false),
                    SalesMoveSalesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryCatagoryId",
                        column: x => x.CategoryCatagoryId,
                        principalTable: "Categories",
                        principalColumn: "CatagoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SalesMoves_SalesMoveSalesId",
                        column: x => x.SalesMoveSalesId,
                        principalTable: "SalesMoves",
                        principalColumn: "SalesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SalesMoveSalesId",
                table: "Customers",
                column: "SalesMoveSalesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SalesMoveSalesId",
                table: "Employees",
                column: "SalesMoveSalesId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoicetId",
                table: "InvoiceItems",
                column: "InvoicetId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryCatagoryId",
                table: "Products",
                column: "CategoryCatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SalesMoveSalesId",
                table: "Products",
                column: "SalesMoveSalesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "SalesMoves");
        }
    }
}
