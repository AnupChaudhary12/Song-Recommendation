﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SongRecommendation.Persistence;

#nullable disable

namespace SongRecommendation.Persistence.Migrations
{
    [DbContext(typeof(SongRecommendationDbContext))]
    [Migration("20240321233621_addedIdToUserSong")]
    partial class addedIdToUserSong
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("SongRecommendation.Domain.Entities.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SongTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("SongRecommendation.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SongRecommendation.Domain.Entities.UserSong", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SongId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLiked")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLikedAlbum")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLikedArtist")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLikedGenre")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("UserSongs");
                });

            modelBuilder.Entity("SongRecommendation.Domain.Entities.UserSong", b =>
                {
                    b.HasOne("SongRecommendation.Domain.Entities.Song", "Song")
                        .WithMany("LikedByUser")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SongRecommendation.Domain.Entities.User", "User")
                        .WithMany("LikedSongs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Song");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SongRecommendation.Domain.Entities.Song", b =>
                {
                    b.Navigation("LikedByUser");
                });

            modelBuilder.Entity("SongRecommendation.Domain.Entities.User", b =>
                {
                    b.Navigation("LikedSongs");
                });
#pragma warning restore 612, 618
        }
    }
}
