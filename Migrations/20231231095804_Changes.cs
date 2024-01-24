using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCommercialAutomation.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_SalesMoves_SalesMoveSalesId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SalesMoves_SalesMoveSalesId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SalesMoves_SalesMoveSalesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SalesMoveSalesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SalesMoveSalesId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SalesMoveSalesId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SalesMoveSalesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalesMoveSalesId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SalesMoveSalesId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "SalesMoves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "SalesMoves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SalesMoves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesMoves_CustomerId",
                table: "SalesMoves",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesMoves_EmployeeId",
                table: "SalesMoves",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesMoves_ProductId",
                table: "SalesMoves",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesMoves_Customers_CustomerId",
                table: "SalesMoves",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesMoves_Employees_EmployeeId",
                table: "SalesMoves",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesMoves_Products_ProductId",
                table: "SalesMoves",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesMoves_Customers_CustomerId",
                table: "SalesMoves");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesMoves_Employees_EmployeeId",
                table: "SalesMoves");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesMoves_Products_ProductId",
                table: "SalesMoves");

            migrationBuilder.DropIndex(
                name: "IX_SalesMoves_CustomerId",
                table: "SalesMoves");

            migrationBuilder.DropIndex(
                name: "IX_SalesMoves_EmployeeId",
                table: "SalesMoves");

            migrationBuilder.DropIndex(
                name: "IX_SalesMoves_ProductId",
                table: "SalesMoves");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "SalesMoves");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "SalesMoves");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SalesMoves");

            migrationBuilder.AddColumn<int>(
                name: "SalesMoveSalesId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalesMoveSalesId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalesMoveSalesId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SalesMoveSalesId",
                table: "Products",
                column: "SalesMoveSalesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SalesMoveSalesId",
                table: "Employees",
                column: "SalesMoveSalesId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SalesMoveSalesId",
                table: "Customers",
                column: "SalesMoveSalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_SalesMoves_SalesMoveSalesId",
                table: "Customers",
                column: "SalesMoveSalesId",
                principalTable: "SalesMoves",
                principalColumn: "SalesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SalesMoves_SalesMoveSalesId",
                table: "Employees",
                column: "SalesMoveSalesId",
                principalTable: "SalesMoves",
                principalColumn: "SalesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SalesMoves_SalesMoveSalesId",
                table: "Products",
                column: "SalesMoveSalesId",
                principalTable: "SalesMoves",
                principalColumn: "SalesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
