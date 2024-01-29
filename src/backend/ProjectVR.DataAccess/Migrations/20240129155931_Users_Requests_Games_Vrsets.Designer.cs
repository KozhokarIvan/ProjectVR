﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectVR.DataAccess;

#nullable disable

namespace ProjectVR.DataAccess.Migrations
{
    [DbContext(typeof(ProjectVRDbContext))]
    [Migration("20240129155931_Users_Requests_Games_Vrsets")]
    partial class Users_Requests_Games_Vrsets
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("AcceptedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FromUserGuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ToUserGuid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FromUserGuid");

                    b.HasIndex("ToUserGuid");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.UserGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("boolean");

                    b.Property<Guid>("OwnerGuid")
                        .HasColumnType("uuid");

                    b.Property<byte?>("Rating")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("OwnerGuid");

                    b.ToTable("UserGames");
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.UserVrSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("boolean");

                    b.Property<Guid>("OwnerGuid")
                        .HasColumnType("uuid");

                    b.Property<int>("VrSetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerGuid");

                    b.HasIndex("VrSetId");

                    b.ToTable("UserVrSets");
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.Users", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Avatar")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastSeen")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Guid");

                    b.ToTable("Usersinfo");
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.VrSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.ToTable("VrSets");
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.Request", b =>
                {
                    b.HasOne("ProjectVR.DataAccess.Entities.Users", "From")
                        .WithMany("OutgoingRequests")
                        .HasForeignKey("FromUserGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectVR.DataAccess.Entities.Users", "To")
                        .WithMany("IncomingRequests")
                        .HasForeignKey("ToUserGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.UserGame", b =>
                {
                    b.HasOne("ProjectVR.DataAccess.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectVR.DataAccess.Entities.Users", "Owner")
                        .WithMany("Games")
                        .HasForeignKey("OwnerGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.UserVrSet", b =>
                {
                    b.HasOne("ProjectVR.DataAccess.Entities.Users", "Owner")
                        .WithMany("VrSets")
                        .HasForeignKey("OwnerGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectVR.DataAccess.Entities.VrSet", "VrSet")
                        .WithMany()
                        .HasForeignKey("VrSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("VrSet");
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.Users", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("IncomingRequests");

                    b.Navigation("OutgoingRequests");

                    b.Navigation("VrSets");
                });
#pragma warning restore 612, 618
        }
    }
}
