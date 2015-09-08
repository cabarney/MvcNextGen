using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace UserGroupMigrations
{
    public partial class AddRegistrationFlagToMeeting : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.AddColumn(
                name: "RegistrationOpen",
                table: "Meeting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropColumn(name: "RegistrationOpen", table: "Meeting");
        }
    }
}
