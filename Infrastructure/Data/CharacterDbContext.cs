using Core.Entities;
using Infrastructure.Data.Configs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data;

public class CharacterDbContext : DbContext
{
    public CharacterDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterAbilities> CharacterAbilities { get; set; }
    public DbSet<CharacterPreparedSpell> CharacterPreparedSpells { get; set; }
    public DbSet<Spell> Spells { get; set; }
    public DbSet<Spellbook> Spellbooks { get; set; }
    public DbSet<SpellbookSpell> SpellbookSpells { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CharacterConfig).Assembly);

        base.OnModelCreating(modelBuilder);

    }
}
