using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameData
{
    public partial class GameContext : DbContext
    {
        public GameContext()
        {
        }

        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DtUserCombination> DtUserCombinations { get; set; } = null!;
        public virtual DbSet<SpGame> SpGames { get; set; } = null!;
        public virtual DbSet<SpUser> SpUsers { get; set; } = null!;
        public virtual DbSet<SpWinCombination> SpWinCombinations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Game;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DtUserCombination>(entity =>
            {
                entity.HasKey(e => e.IdUserCombination);

                entity.ToTable("dt_user_combination");

                entity.Property(e => e.IdUserCombination)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user_combination");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IdWinCombination).HasColumnName("id_win_combination");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.DtUserCombinations)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_dt_user_combination_sp_user");

                entity.HasOne(d => d.IdWinCombinationNavigation)
                    .WithMany(p => p.DtUserCombinations)
                    .HasForeignKey(d => d.IdWinCombination)
                    .HasConstraintName("FK_dt_user_combination_sp_win_combination");
            });

            modelBuilder.Entity<SpGame>(entity =>
            {
                entity.HasKey(e => e.IdGame);

                entity.ToTable("sp_games");

                entity.Property(e => e.IdGame)
                    .ValueGeneratedNever()
                    .HasColumnName("id_game");

                entity.Property(e => e.DatePlay)
                    .HasColumnType("date")
                    .HasColumnName("date_play");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Protocol)
                    .HasColumnType("ntext")
                    .HasColumnName("protocol");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.SpGames)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_sp_games_sp_user");
            });

            modelBuilder.Entity<SpUser>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("sp_user");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");

                entity.Property(e => e.DateRegistration)
                    .HasColumnType("date")
                    .HasColumnName("date_registration");

                entity.Property(e => e.Name)
                    .HasColumnType("ntext")
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .HasColumnType("ntext")
                    .HasColumnName("surname");

                entity.Property(e => e.Username)
                    .HasColumnType("ntext")
                    .HasColumnName("username");

                entity.Property(e => e.Userpass)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("userpass")
                    .IsFixedLength();
            });

            modelBuilder.Entity<SpWinCombination>(entity =>
            {
                entity.HasKey(e => e.IdWinCombination);

                entity.ToTable("sp_win_combination");

                entity.Property(e => e.IdWinCombination)
                    .ValueGeneratedNever()
                    .HasColumnName("id_win_combination");

                entity.Property(e => e.A)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.B)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.C)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
