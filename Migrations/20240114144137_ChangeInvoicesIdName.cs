using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCommercialAutomation.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInvoicesIdName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoicetId",
                table: "Invoices",
                newName: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Invoices",
                newName: "InvoicetId");
        }
    }
}
