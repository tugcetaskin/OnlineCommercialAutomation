using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCommercialAutomation.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInvoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Invoices",
                type: "char(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Invoices");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldMaxLength: 5);
        }
    }
}
