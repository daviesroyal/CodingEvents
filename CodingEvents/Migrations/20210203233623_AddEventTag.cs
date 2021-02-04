using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingEvents.Migrations
{
    public partial class AddEventTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTag",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false),
                    EventTagEventId = table.Column<int>(nullable: true),
                    EventTagTagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTag", x => new { x.EventId, x.TagId });
                    table.ForeignKey(
                        name: "FK_EventTag_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTag_EventTag_EventTagEventId_EventTagTagId",
                        columns: x => new { x.EventTagEventId, x.EventTagTagId },
                        principalTable: "EventTag",
                        principalColumns: new[] { "EventId", "TagId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventTag_TagId",
                table: "EventTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTag_EventTagEventId_EventTagTagId",
                table: "EventTag",
                columns: new[] { "EventTagEventId", "EventTagTagId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTag");
        }
    }
}
