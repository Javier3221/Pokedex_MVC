using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<PokemonType> Type { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables
            modelBuilder.Entity<Pokemon>()
                .ToTable("Pokemon");

            modelBuilder.Entity<Region>()
                .ToTable("Region");

            modelBuilder.Entity<PokemonType>()
                .ToTable("PokemonType");
            #endregion

            #region primary keys
            modelBuilder.Entity<Pokemon>()
                .HasKey(Pokemon => Pokemon.Id);

            modelBuilder.Entity<Region>()
                .HasKey(Region => Region.Id);

            modelBuilder.Entity<PokemonType>()
                .HasKey(PokemonType => PokemonType.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<Region>()
                .HasMany<Pokemon>(Region => Region.Pokemon)
                .WithOne(Pokemon => Pokemon.Region)
                .HasForeignKey(Pokemon => Pokemon.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PokemonType>()
                .HasMany<Pokemon>(PokemonType => PokemonType.PrimaryPokemon)
                .WithOne(Pokemon => Pokemon.PrimaryType)
                .HasForeignKey(Pokemon => Pokemon.PrimaryTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PokemonType>()
                .HasMany<Pokemon>(PokemonType => PokemonType.SecondaryPokemon)
                .WithOne(Pokemon => Pokemon.SecondaryType)
                .HasForeignKey(Pokemon => Pokemon.SecondaryTypeId);
            #endregion

            #region property configurations
            #region Pokemon
            modelBuilder.Entity<Pokemon>()
                .Property(Pokemon => Pokemon.PrimaryTypeId)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
               .Property(Pokemon => Pokemon.RegionId)
               .IsRequired();
            #endregion

            #region Regions
            modelBuilder.Entity<Region>()
                .Property(Region => Region.Name)
                .IsRequired()
                .HasMaxLength(55);
            #endregion

            #region PokemonType
            modelBuilder.Entity<PokemonType>()
                .Property(PokemonType => PokemonType.Name)
                .IsRequired()
                .HasMaxLength(55);
            #endregion
            #endregion
        }

    }
}
