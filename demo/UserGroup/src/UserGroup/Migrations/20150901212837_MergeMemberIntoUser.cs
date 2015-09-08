using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace UserGroupMigrations
{
    public partial class MergeMemberIntoUser : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Registration_Member_MemberId", table: "Registration");
            migration.DropColumn(name: "MemberId", table: "Registration");
            migration.DropTable("Member");
            migration.AddColumn(
                name: "UserId",
                table: "Registration",
                type: "nvarchar(450)",
                nullable: true);
            migration.RenameTable(
                name: "AspNetUsers",
                newName: "Users");
            migration.AddColumn(
                name: "Name",
                table: "Users",
                type: "nvarchar(100)",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Registration_ApplicationUser_UserId",
                table: "Registration",
                column: "UserId",
                referencedTable: "Users",
                referencedColumn: "Id");
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Registration_ApplicationUser_UserId", table: "Registration");
            migration.DropColumn(name: "UserId", table: "Registration");
            migration.DropColumn(name: "Name", table: "Users");
            migration.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    Email = table.Column(type: "nvarchar(max)", nullable: true),
                    Name = table.Column(type: "nvarchar(100)", nullable: true),
                    UserId = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_ApplicationUser_UserId",
                        columns: x => x.UserId,
                        referencedTable: "AspNetUsers",
                        referencedColumn: "Id");
                });
            migration.AddColumn(
                name: "MemberId",
                table: "Registration",
                type: "int",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Registration_Member_MemberId",
                table: "Registration",
                column: "MemberId",
                referencedTable: "Member",
                referencedColumn: "Id");
            migration.RenameTable(
                name: "Users",
                newName: "AspNetUsers");
        }
    }
}
