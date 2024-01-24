using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCommercialAutomation.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInvoiceItemsAddInvoiceId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoicetId",
                table: "InvoiceItems");

            migrationBuilder.RenameColumn(
                name: "InvoicetId",
                table: "InvoiceItems",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_InvoicetId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoicetId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "InvoiceItems",
                newName: "InvoicetId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_InvoicetId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoicetId",
                table: "InvoiceItems",
                column: "InvoicetId",
                principalTable: "Invoices",
                principalColumn: "InvoicetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
