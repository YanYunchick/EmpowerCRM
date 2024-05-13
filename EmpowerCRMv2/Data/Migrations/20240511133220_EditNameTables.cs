using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpowerCRMv2.Migrations
{
    /// <inheritdoc />
    public partial class EditNameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTask_AspNetUsers_OwnerId",
                table: "UserTask");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTask_Opportunities_OpportunityId",
                table: "UserTask");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTask_UserTaskPriority_PriorityId",
                table: "UserTask");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTask_UserTaskStatus_StatusId",
                table: "UserTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTaskStatus",
                table: "UserTaskStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTaskPriority",
                table: "UserTaskPriority");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTask",
                table: "UserTask");

            migrationBuilder.RenameTable(
                name: "UserTaskStatus",
                newName: "UserTaskStatuses");

            migrationBuilder.RenameTable(
                name: "UserTaskPriority",
                newName: "UserTaskPriorities");

            migrationBuilder.RenameTable(
                name: "UserTask",
                newName: "UserTasks");

            migrationBuilder.RenameIndex(
                name: "IX_UserTask_StatusId",
                table: "UserTasks",
                newName: "IX_UserTasks_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTask_PriorityId",
                table: "UserTasks",
                newName: "IX_UserTasks_PriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTask_OwnerId",
                table: "UserTasks",
                newName: "IX_UserTasks_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTask_OpportunityId",
                table: "UserTasks",
                newName: "IX_UserTasks_OpportunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTaskStatuses",
                table: "UserTaskStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTaskPriorities",
                table: "UserTaskPriorities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTasks",
                table: "UserTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_AspNetUsers_OwnerId",
                table: "UserTasks",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Opportunities_OpportunityId",
                table: "UserTasks",
                column: "OpportunityId",
                principalTable: "Opportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_UserTaskPriorities_PriorityId",
                table: "UserTasks",
                column: "PriorityId",
                principalTable: "UserTaskPriorities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_UserTaskStatuses_StatusId",
                table: "UserTasks",
                column: "StatusId",
                principalTable: "UserTaskStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_OwnerId",
                table: "UserTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Opportunities_OpportunityId",
                table: "UserTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_UserTaskPriorities_PriorityId",
                table: "UserTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_UserTaskStatuses_StatusId",
                table: "UserTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTaskStatuses",
                table: "UserTaskStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTasks",
                table: "UserTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTaskPriorities",
                table: "UserTaskPriorities");

            migrationBuilder.RenameTable(
                name: "UserTaskStatuses",
                newName: "UserTaskStatus");

            migrationBuilder.RenameTable(
                name: "UserTasks",
                newName: "UserTask");

            migrationBuilder.RenameTable(
                name: "UserTaskPriorities",
                newName: "UserTaskPriority");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_StatusId",
                table: "UserTask",
                newName: "IX_UserTask_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_PriorityId",
                table: "UserTask",
                newName: "IX_UserTask_PriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_OwnerId",
                table: "UserTask",
                newName: "IX_UserTask_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_OpportunityId",
                table: "UserTask",
                newName: "IX_UserTask_OpportunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTaskStatus",
                table: "UserTaskStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTask",
                table: "UserTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTaskPriority",
                table: "UserTaskPriority",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTask_AspNetUsers_OwnerId",
                table: "UserTask",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTask_Opportunities_OpportunityId",
                table: "UserTask",
                column: "OpportunityId",
                principalTable: "Opportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTask_UserTaskPriority_PriorityId",
                table: "UserTask",
                column: "PriorityId",
                principalTable: "UserTaskPriority",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTask_UserTaskStatus_StatusId",
                table: "UserTask",
                column: "StatusId",
                principalTable: "UserTaskStatus",
                principalColumn: "Id");
        }
    }
}
