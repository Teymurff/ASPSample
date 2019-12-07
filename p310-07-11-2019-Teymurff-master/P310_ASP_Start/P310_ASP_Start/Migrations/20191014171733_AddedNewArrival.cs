using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P310_ASP_Start.Migrations
{
    public partial class AddedNewArrival : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewArrivals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(maxLength: 255, nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewArrivals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NewArrivals",
                columns: new[] { "Id", "Image", "Title" },
                values: new object[] { 1, "bottom1.jpg", "<span>f</span>all ahead" });

            migrationBuilder.InsertData(
                table: "NewArrivals",
                columns: new[] { "Id", "Image", "Title" },
                values: new object[] { 2, "bottom2.jpg", "<span>f</span>all ahead" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewArrivals");
        }
    }
}
