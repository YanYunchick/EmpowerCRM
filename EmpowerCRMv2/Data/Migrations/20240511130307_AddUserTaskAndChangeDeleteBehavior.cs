using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpowerCRMv2.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTaskAndChangeDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_OwnerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Opportunities_OpportunityStages_StageId",
                table: "Opportunities");

            migrationBuilder.AlterColumn<int>(
                name: "StageId",
                table: "Opportunities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "UserTaskPriority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskPriority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTaskStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    PriorityId = table.Column<int>(type: "int", nullable: true),
                    OpportunityId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTask_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTask_Opportunities_OpportunityId",
                        column: x => x.OpportunityId,
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTask_UserTaskPriority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "UserTaskPriority",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTask_UserTaskStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "UserTaskStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTask_OpportunityId",
                table: "UserTask",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTask_OwnerId",
                table: "UserTask",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTask_PriorityId",
                table: "UserTask",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTask_StatusId",
                table: "UserTask",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_OwnerId",
                table: "Contacts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunities_OpportunityStages_StageId",
                table: "Opportunities",
                column: "StageId",
                principalTable: "OpportunityStages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_OwnerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Opportunities_OpportunityStages_StageId",
                table: "Opportunities");

            migrationBuilder.DropTable(
                name: "UserTask");

            migrationBuilder.DropTable(
                name: "UserTaskPriority");

            migrationBuilder.DropTable(
                name: "UserTaskStatus");

            migrationBuilder.AlterColumn<int>(
                name: "StageId",
                table: "Opportunities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_OwnerId",
                table: "Contacts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunities_OpportunityStages_StageId",
                table: "Opportunities",
                column: "StageId",
                principalTable: "OpportunityStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
