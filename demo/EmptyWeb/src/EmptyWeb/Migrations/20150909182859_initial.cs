using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace EmptyWebMigrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Thing",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    Name = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thing", x => x.Id);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Thing");
        }
    }
}
