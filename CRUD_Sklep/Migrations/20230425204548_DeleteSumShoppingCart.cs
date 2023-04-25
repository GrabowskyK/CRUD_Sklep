using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Sklep.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSumShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sum",
                table: "ShopingCarts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Sum",
                table: "ShopingCarts",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
