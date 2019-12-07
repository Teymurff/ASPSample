using Microsoft.EntityFrameworkCore.Migrations;

namespace P310_ASP_Start.Migrations
{
    public partial class SeededSlidersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Image", "SubTitle", "Title" },
                values: new object[,]
                {
                    { 1, "banner1.jpg", "Special for today", "The Biggest <span>Sale</span> " },
                    { 2, "banner2.jpg", "New Arrivals On Sale", "SUMMER <span>COLLECTION </span> " },
                    { 3, "banner3.jpg", "Special for Kamran", "The Biggest <span>Sale</span> " },
                    { 4, "banner4.jpg", "Special for Ruslan", "The Biggest <span>Perviz ever</span> " }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
