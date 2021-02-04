using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingEvents.Migrations
{
    public partial class UpdateEventTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTag_Events_EventId",
                table: "EventTag");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTag_Tags_TagId",
                table: "EventTag");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTag_EventTag_EventTagEventId_EventTagTagId",
                table: "EventTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventTag",
                table: "EventTag");

            migrationBuilder.RenameTable(
                name: "EventTag",
                newName: "EventTags");

            migrationBuilder.RenameIndex(
                name: "IX_EventTag_EventTagEventId_EventTagTagId",
                table: "EventTags",
                newName: "IX_EventTags_EventTagEventId_EventTagTagId");

            migrationBuilder.RenameIndex(
                name: "IX_EventTag_TagId",
                table: "EventTags",
                newName: "IX_EventTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventTags",
                table: "EventTags",
                columns: new[] { "EventId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventTags_Events_EventId",
                table: "EventTags",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTags_Tags_TagId",
                table: "EventTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTags_EventTags_EventTagEventId_EventTagTagId",
                table: "EventTags",
                columns: new[] { "EventTagEventId", "EventTagTagId" },
                principalTable: "EventTags",
                principalColumns: new[] { "EventId", "TagId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTags_Events_EventId",
                table: "EventTags");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTags_Tags_TagId",
                table: "EventTags");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTags_EventTags_EventTagEventId_EventTagTagId",
                table: "EventTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventTags",
                table: "EventTags");

            migrationBuilder.RenameTable(
                name: "EventTags",
                newName: "EventTag");

            migrationBuilder.RenameIndex(
                name: "IX_EventTags_EventTagEventId_EventTagTagId",
                table: "EventTag",
                newName: "IX_EventTag_EventTagEventId_EventTagTagId");

            migrationBuilder.RenameIndex(
                name: "IX_EventTags_TagId",
                table: "EventTag",
                newName: "IX_EventTag_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventTag",
                table: "EventTag",
                columns: new[] { "EventId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventTag_Events_EventId",
                table: "EventTag",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTag_Tags_TagId",
                table: "EventTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTag_EventTag_EventTagEventId_EventTagTagId",
                table: "EventTag",
                columns: new[] { "EventTagEventId", "EventTagTagId" },
                principalTable: "EventTag",
                principalColumns: new[] { "EventId", "TagId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
