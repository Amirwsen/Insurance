using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixSomeBugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceOrders_Insurances_InsuranceId1",
                table: "InsuranceOrders");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceOrders_InsuranceId1",
                table: "InsuranceOrders");

            migrationBuilder.DropColumn(
                name: "InsuranceId1",
                table: "InsuranceOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InsuranceId1",
                table: "InsuranceOrders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceOrders_InsuranceId1",
                table: "InsuranceOrders",
                column: "InsuranceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceOrders_Insurances_InsuranceId1",
                table: "InsuranceOrders",
                column: "InsuranceId1",
                principalTable: "Insurances",
                principalColumn: "Id");
        }
    }
}
