using Microsoft.EntityFrameworkCore.Migrations;

namespace DrunkenWizard_API.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    PremiumClass = table.Column<bool>(nullable: false),
                    ClassType = table.Column<string>(nullable: true),
                    SelectedColor = table.Column<string>(nullable: true),
                    RollEffect1 = table.Column<string>(nullable: true),
                    RollEffect2 = table.Column<string>(nullable: true),
                    RollEffect3 = table.Column<string>(nullable: true),
                    RollEffect4 = table.Column<string>(nullable: true),
                    RollEffect5 = table.Column<string>(nullable: true),
                    RollEffect6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    SlayedBeast = table.Column<int>(nullable: false),
                    BoostUsed = table.Column<bool>(nullable: false),
                    LocalPLayer = table.Column<bool>(nullable: false),
                    PremiumAccount = table.Column<bool>(nullable: false),
                    IsHost = table.Column<bool>(nullable: false),
                    GameKey = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    GameClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_GameClass_GameClassId",
                        column: x => x.GameClassId,
                        principalTable: "GameClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spell",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SpellImage = table.Column<string>(nullable: true),
                    Style = table.Column<string>(nullable: true),
                    SecondStyle = table.Column<string>(nullable: true),
                    GameClassName = table.Column<string>(nullable: true),
                    GameClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spell_GameClass_GameClassId",
                        column: x => x.GameClassId,
                        principalTable: "GameClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameClassId",
                table: "Player",
                column: "GameClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameId",
                table: "Player",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Spell_GameClassId",
                table: "Spell",
                column: "GameClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Spell");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "GameClass");
        }
    }
}
