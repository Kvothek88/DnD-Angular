using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Backgrounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backgrounds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HitDice = table.Column<int>(type: "int", nullable: false),
                    IsSpellcaster = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spellbooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spellbooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    School = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsConcentration = table.Column<bool>(type: "bit", nullable: false),
                    IsDuration = table.Column<bool>(type: "bit", nullable: false),
                    IsRitual = table.Column<bool>(type: "bit", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    CastingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSubclasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsSpellcaster = table.Column<bool>(type: "bit", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSubclasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterSubclasses_CharacterClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dictionaries_DictionaryCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "DictionaryCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BackgroundFeats",
                columns: table => new
                {
                    BackgroundId = table.Column<int>(type: "int", nullable: false),
                    FeatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundFeats", x => new { x.BackgroundId, x.FeatsId });
                    table.ForeignKey(
                        name: "FK_BackgroundFeats_Backgrounds_BackgroundId",
                        column: x => x.BackgroundId,
                        principalTable: "Backgrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BackgroundFeats_Feats_FeatsId",
                        column: x => x.FeatsId,
                        principalTable: "Feats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatAbilityBonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ability = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    FeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatAbilityBonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatAbilityBonuses_Feats_FeatId",
                        column: x => x.FeatId,
                        principalTable: "Feats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    BackgroundId = table.Column<int>(type: "int", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Alignment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ImageFrame = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaxHp = table.Column<int>(type: "int", nullable: false),
                    NegativeHp = table.Column<int>(type: "int", nullable: false),
                    CurrentHp = table.Column<int>(type: "int", nullable: false),
                    TempHp = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Backgrounds_BackgroundId",
                        column: x => x.BackgroundId,
                        principalTable: "Backgrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RaceFeats",
                columns: table => new
                {
                    FeatsId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceFeats", x => new { x.FeatsId, x.RaceId });
                    table.ForeignKey(
                        name: "FK_RaceFeats_Feats_FeatsId",
                        column: x => x.FeatsId,
                        principalTable: "Feats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceFeats_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpellId = table.Column<int>(type: "int", nullable: true),
                    ActionType = table.Column<int>(type: "int", nullable: true),
                    FeatureKind = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RaceSpells",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    SpellsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceSpells", x => new { x.RaceId, x.SpellsId });
                    table.ForeignKey(
                        name: "FK_RaceSpells_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceSpells_Spells_SpellsId",
                        column: x => x.SpellsId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpellbookSpells",
                columns: table => new
                {
                    SpellId = table.Column<int>(type: "int", nullable: false),
                    SpellbookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellbookSpells", x => new { x.SpellId, x.SpellbookId });
                    table.ForeignKey(
                        name: "FK_SpellbookSpells_Spellbooks_SpellbookId",
                        column: x => x.SpellbookId,
                        principalTable: "Spellbooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellbookSpells_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DictionaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictionaryItems_Dictionaries_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advancements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    AdvancementType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    AbilityScoreImprovement_CharacterId1 = table.Column<int>(type: "int", nullable: true),
                    FeatId = table.Column<int>(type: "int", nullable: true),
                    CharacterId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advancements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advancements_Characters_AbilityScoreImprovement_CharacterId1",
                        column: x => x.AbilityScoreImprovement_CharacterId1,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Advancements_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advancements_Characters_CharacterId1",
                        column: x => x.CharacterId1,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Advancements_Feats_FeatId",
                        column: x => x.FeatId,
                        principalTable: "Feats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterAbilities_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CharacterConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Blinded = table.Column<bool>(type: "bit", nullable: false),
                    Charmed = table.Column<bool>(type: "bit", nullable: false),
                    Deafened = table.Column<bool>(type: "bit", nullable: false),
                    Frightened = table.Column<bool>(type: "bit", nullable: false),
                    Grappled = table.Column<bool>(type: "bit", nullable: false),
                    Incapacitated = table.Column<bool>(type: "bit", nullable: false),
                    Invisible = table.Column<bool>(type: "bit", nullable: false),
                    Paralyzed = table.Column<bool>(type: "bit", nullable: false),
                    Petrified = table.Column<bool>(type: "bit", nullable: false),
                    Poisoned = table.Column<bool>(type: "bit", nullable: false),
                    Prone = table.Column<bool>(type: "bit", nullable: false),
                    Restrained = table.Column<bool>(type: "bit", nullable: false),
                    Stunned = table.Column<bool>(type: "bit", nullable: false),
                    Unconscious = table.Column<bool>(type: "bit", nullable: false),
                    Exhausted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterConditions_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CharacterFeats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    FeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterFeats_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterFeats_Feats_FeatId",
                        column: x => x.FeatId,
                        principalTable: "Feats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterPhysicalCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Hair = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Skin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Eyes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterPhysicalCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterPhysicalCharacteristics_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterPreparedSpells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    SpellId = table.Column<int>(type: "int", nullable: false),
                    CharacterClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterPreparedSpells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterPreparedSpells_CharacterClasses_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterPreparedSpells_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterPreparedSpells_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSpellSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxLevel1 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MaxLevel2 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MaxLevel3 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MaxLevel4 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MaxLevel5 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MaxLevel6 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MaxLevel7 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MaxLevel8 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MaxLevel9 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsedLevel1 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsedLevel2 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsedLevel3 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsedLevel4 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsedLevel5 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsedLevel6 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsedLevel7 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsedLevel8 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsedLevel9 = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSpellSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterSpellSlots_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassAdvancements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    EntryType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAdvancements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassAdvancements_CharacterClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassAdvancements_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubclassAdvancements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    SubclassId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubclassAdvancements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubclassAdvancements_CharacterSubclasses_SubclassId",
                        column: x => x.SubclassId,
                        principalTable: "CharacterSubclasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubclassAdvancements_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BackgroundFeatures",
                columns: table => new
                {
                    BackgroundId = table.Column<int>(type: "int", nullable: false),
                    FeaturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundFeatures", x => new { x.BackgroundId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_BackgroundFeatures_Backgrounds_BackgroundId",
                        column: x => x.BackgroundId,
                        principalTable: "Backgrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BackgroundFeatures_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClassFeature",
                columns: table => new
                {
                    CharacterClassId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClassFeature", x => new { x.CharacterClassId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_CharacterClassFeature_CharacterClasses_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterClassFeature_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterFeatures",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    UsesSpellSlots = table.Column<bool>(type: "bit", nullable: true),
                    MaxUses = table.Column<int>(type: "int", nullable: true),
                    RemainingUses = table.Column<int>(type: "int", nullable: true),
                    RestType = table.Column<int>(type: "int", nullable: true),
                    Source = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFeatures", x => new { x.CharacterId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_CharacterFeatures_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSubclassFeature",
                columns: table => new
                {
                    CharacterSubclassId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSubclassFeature", x => new { x.CharacterSubclassId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_CharacterSubclassFeature_CharacterSubclasses_CharacterSubclassId",
                        column: x => x.CharacterSubclassId,
                        principalTable: "CharacterSubclasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSubclassFeature_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureAbilityBonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ability = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureAbilityBonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureAbilityBonuses_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prerequisites",
                columns: table => new
                {
                    OwnerType = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Operator = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prerequisites", x => new { x.OwnerType, x.OwnerId, x.GroupId, x.Type });
                    table.ForeignKey(
                        name: "FK_Feat_Prerequisites_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Feats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Feature_Prerequisites_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Features",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RaceFeatures",
                columns: table => new
                {
                    FeaturesId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceFeatures", x => new { x.FeaturesId, x.RaceId });
                    table.ForeignKey(
                        name: "FK_RaceFeatures_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceFeatures_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrantedProficiencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProficiencyId = table.Column<int>(type: "int", nullable: true),
                    ProficiencyTypeId = table.Column<int>(type: "int", nullable: true),
                    ProficiencyCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrantedProficiencies", x => x.Id);
                    table.CheckConstraint("CK_GrantedProficiency_ExactlyOneTarget", "(ProficiencyId IS NOT NULL AND ProficiencyTypeId IS NULL) OR (ProficiencyId IS NULL AND ProficiencyTypeId IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_GrantedProficiencies_Dictionaries_ProficiencyTypeId",
                        column: x => x.ProficiencyTypeId,
                        principalTable: "Dictionaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GrantedProficiencies_DictionaryCategories_ProficiencyCategoryId",
                        column: x => x.ProficiencyCategoryId,
                        principalTable: "DictionaryCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GrantedProficiencies_DictionaryItems_ProficiencyId",
                        column: x => x.ProficiencyId,
                        principalTable: "DictionaryItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ASIAbilityBonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ability = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    AbilityScoreImprovementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASIAbilityBonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ASIAbilityBonuses_Advancements_AbilityScoreImprovementId",
                        column: x => x.AbilityScoreImprovementId,
                        principalTable: "Advancements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BackgroundProficiencies",
                columns: table => new
                {
                    BackgroundId = table.Column<int>(type: "int", nullable: false),
                    ProficienciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundProficiencies", x => new { x.BackgroundId, x.ProficienciesId });
                    table.ForeignKey(
                        name: "FK_BackgroundProficiencies_Backgrounds_BackgroundId",
                        column: x => x.BackgroundId,
                        principalTable: "Backgrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BackgroundProficiencies_GrantedProficiencies_ProficienciesId",
                        column: x => x.ProficienciesId,
                        principalTable: "GrantedProficiencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClassMulticlassProficiency",
                columns: table => new
                {
                    CharacterClassId = table.Column<int>(type: "int", nullable: false),
                    GrantedProficiencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClassMulticlassProficiency", x => new { x.CharacterClassId, x.GrantedProficiencyId });
                    table.ForeignKey(
                        name: "FK_CharacterClassMulticlassProficiency_CharacterClasses_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterClassMulticlassProficiency_GrantedProficiencies_GrantedProficiencyId",
                        column: x => x.GrantedProficiencyId,
                        principalTable: "GrantedProficiencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClassPrimaryProficiency",
                columns: table => new
                {
                    CharacterClassId = table.Column<int>(type: "int", nullable: false),
                    GrantedProficiencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClassPrimaryProficiency", x => new { x.CharacterClassId, x.GrantedProficiencyId });
                    table.ForeignKey(
                        name: "FK_CharacterClassPrimaryProficiency_CharacterClasses_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterClassPrimaryProficiency_GrantedProficiencies_GrantedProficiencyId",
                        column: x => x.GrantedProficiencyId,
                        principalTable: "GrantedProficiencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterProficiencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    GrantedProficiencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterProficiencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterProficiencies_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterProficiencies_GrantedProficiencies_GrantedProficiencyId",
                        column: x => x.GrantedProficiencyId,
                        principalTable: "GrantedProficiencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSubclassProficiency",
                columns: table => new
                {
                    CharacterSubclassId = table.Column<int>(type: "int", nullable: false),
                    GrantedProficiencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSubclassProficiency", x => new { x.CharacterSubclassId, x.GrantedProficiencyId });
                    table.ForeignKey(
                        name: "FK_CharacterSubclassProficiency_CharacterSubclasses_CharacterSubclassId",
                        column: x => x.CharacterSubclassId,
                        principalTable: "CharacterSubclasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSubclassProficiency_GrantedProficiencies_GrantedProficiencyId",
                        column: x => x.GrantedProficiencyId,
                        principalTable: "GrantedProficiencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceProficiencies",
                columns: table => new
                {
                    ProficienciesId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceProficiencies", x => new { x.ProficienciesId, x.RaceId });
                    table.ForeignKey(
                        name: "FK_RaceProficiencies_GrantedProficiencies_ProficienciesId",
                        column: x => x.ProficienciesId,
                        principalTable: "GrantedProficiencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceProficiencies_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advancements_AbilityScoreImprovement_CharacterId1",
                table: "Advancements",
                column: "AbilityScoreImprovement_CharacterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Advancements_CharacterId",
                table: "Advancements",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Advancements_CharacterId1",
                table: "Advancements",
                column: "CharacterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Advancements_FeatId",
                table: "Advancements",
                column: "FeatId");

            migrationBuilder.CreateIndex(
                name: "IX_ASIAbilityBonuses_AbilityScoreImprovementId",
                table: "ASIAbilityBonuses",
                column: "AbilityScoreImprovementId");

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundFeats_FeatsId",
                table: "BackgroundFeats",
                column: "FeatsId");

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundFeatures_FeaturesId",
                table: "BackgroundFeatures",
                column: "FeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundProficiencies_ProficienciesId",
                table: "BackgroundProficiencies",
                column: "ProficienciesId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAbilities_CharacterId",
                table: "CharacterAbilities",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClassFeature_FeatureId",
                table: "CharacterClassFeature",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClassMulticlassProficiency_GrantedProficiencyId",
                table: "CharacterClassMulticlassProficiency",
                column: "GrantedProficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClassPrimaryProficiency_GrantedProficiencyId",
                table: "CharacterClassPrimaryProficiency",
                column: "GrantedProficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterConditions_CharacterId",
                table: "CharacterConditions",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFeats_CharacterId_FeatId",
                table: "CharacterFeats",
                columns: new[] { "CharacterId", "FeatId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFeats_FeatId",
                table: "CharacterFeats",
                column: "FeatId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFeatures_FeatureId",
                table: "CharacterFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPhysicalCharacteristics_CharacterId",
                table: "CharacterPhysicalCharacteristics",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPreparedSpells_CharacterClassId",
                table: "CharacterPreparedSpells",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPreparedSpells_CharacterId_SpellId_CharacterClassId",
                table: "CharacterPreparedSpells",
                columns: new[] { "CharacterId", "SpellId", "CharacterClassId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPreparedSpells_SpellId",
                table: "CharacterPreparedSpells",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterProficiencies_CharacterId_GrantedProficiencyId",
                table: "CharacterProficiencies",
                columns: new[] { "CharacterId", "GrantedProficiencyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterProficiencies_GrantedProficiencyId",
                table: "CharacterProficiencies",
                column: "GrantedProficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_BackgroundId",
                table: "Characters",
                column: "BackgroundId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RaceId",
                table: "Characters",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpellSlots_CharacterId",
                table: "CharacterSpellSlots",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSubclasses_ClassId",
                table: "CharacterSubclasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSubclassFeature_FeatureId",
                table: "CharacterSubclassFeature",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSubclassProficiency_GrantedProficiencyId",
                table: "CharacterSubclassProficiency",
                column: "GrantedProficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAdvancements_CharacterId",
                table: "ClassAdvancements",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAdvancements_ClassId",
                table: "ClassAdvancements",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_CategoryId",
                table: "Dictionaries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryItems_DictionaryId",
                table: "DictionaryItems",
                column: "DictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatAbilityBonuses_FeatId",
                table: "FeatAbilityBonuses",
                column: "FeatId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureAbilityBonuses_FeatureId",
                table: "FeatureAbilityBonuses",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_SpellId",
                table: "Features",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_GrantedProficiencies_ProficiencyCategoryId",
                table: "GrantedProficiencies",
                column: "ProficiencyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GrantedProficiencies_ProficiencyId",
                table: "GrantedProficiencies",
                column: "ProficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GrantedProficiencies_ProficiencyTypeId",
                table: "GrantedProficiencies",
                column: "ProficiencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prerequisites_OwnerId",
                table: "Prerequisites",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceFeats_RaceId",
                table: "RaceFeats",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceFeatures_RaceId",
                table: "RaceFeatures",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceProficiencies_RaceId",
                table: "RaceProficiencies",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceSpells_SpellsId",
                table: "RaceSpells",
                column: "SpellsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellbookSpells_SpellbookId",
                table: "SpellbookSpells",
                column: "SpellbookId");

            migrationBuilder.CreateIndex(
                name: "IX_SubclassAdvancements_CharacterId",
                table: "SubclassAdvancements",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubclassAdvancements_SubclassId",
                table: "SubclassAdvancements",
                column: "SubclassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASIAbilityBonuses");

            migrationBuilder.DropTable(
                name: "BackgroundFeats");

            migrationBuilder.DropTable(
                name: "BackgroundFeatures");

            migrationBuilder.DropTable(
                name: "BackgroundProficiencies");

            migrationBuilder.DropTable(
                name: "CharacterAbilities");

            migrationBuilder.DropTable(
                name: "CharacterClassFeature");

            migrationBuilder.DropTable(
                name: "CharacterClassMulticlassProficiency");

            migrationBuilder.DropTable(
                name: "CharacterClassPrimaryProficiency");

            migrationBuilder.DropTable(
                name: "CharacterConditions");

            migrationBuilder.DropTable(
                name: "CharacterFeats");

            migrationBuilder.DropTable(
                name: "CharacterFeatures");

            migrationBuilder.DropTable(
                name: "CharacterPhysicalCharacteristics");

            migrationBuilder.DropTable(
                name: "CharacterPreparedSpells");

            migrationBuilder.DropTable(
                name: "CharacterProficiencies");

            migrationBuilder.DropTable(
                name: "CharacterSpellSlots");

            migrationBuilder.DropTable(
                name: "CharacterSubclassFeature");

            migrationBuilder.DropTable(
                name: "CharacterSubclassProficiency");

            migrationBuilder.DropTable(
                name: "ClassAdvancements");

            migrationBuilder.DropTable(
                name: "FeatAbilityBonuses");

            migrationBuilder.DropTable(
                name: "FeatureAbilityBonuses");

            migrationBuilder.DropTable(
                name: "Prerequisites");

            migrationBuilder.DropTable(
                name: "RaceFeats");

            migrationBuilder.DropTable(
                name: "RaceFeatures");

            migrationBuilder.DropTable(
                name: "RaceProficiencies");

            migrationBuilder.DropTable(
                name: "RaceSpells");

            migrationBuilder.DropTable(
                name: "SpellbookSpells");

            migrationBuilder.DropTable(
                name: "SubclassAdvancements");

            migrationBuilder.DropTable(
                name: "Advancements");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "GrantedProficiencies");

            migrationBuilder.DropTable(
                name: "Spellbooks");

            migrationBuilder.DropTable(
                name: "CharacterSubclasses");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Feats");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "DictionaryItems");

            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropTable(
                name: "Backgrounds");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Dictionaries");

            migrationBuilder.DropTable(
                name: "DictionaryCategories");
        }
    }
}
