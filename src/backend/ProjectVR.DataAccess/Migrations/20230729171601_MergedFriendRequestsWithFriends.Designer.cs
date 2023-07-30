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
    [Migration("20230729171601_MergedFriendRequestsWithFriends")]
    partial class MergedFriendRequestsWithFriends
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.Friend", b =>
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

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = "https://steamuserimages-a.akamaihd.net/ugc/786352192200116789/D2244F357EC1456DEEB6F4AB15F8553C10F9F8DC/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false",
                            Name = "Beat Saber"
                        },
                        new
                        {
                            Id = 2,
                            Icon = "https://i.gyazo.com/b54996dbec36d72cb1e5fe944a4b23da.png",
                            Name = "VR Chat"
                        },
                        new
                        {
                            Id = 3,
                            Icon = "https://steamuserimages-a.akamaihd.net/ugc/1043093962826688663/4E945777E1822C8979CD679DDCCCD44C822A8BCB/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false",
                            Name = "Skyrim VR"
                        },
                        new
                        {
                            Id = 4,
                            Icon = "https://steamuserimages-a.akamaihd.net/ugc/2057618192240916199/8F24AAC05F4485CA8C49D4064362BB6B91960D16/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true",
                            Name = "Fallout 4 VR"
                        },
                        new
                        {
                            Id = 5,
                            Icon = "https://steamuserimages-a.akamaihd.net/ugc/1670238751987019701/F499E283EDE967EDF91BA4C204086D56C1F96C7F/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true",
                            Name = "Half-Life: Alyx"
                        },
                        new
                        {
                            Id = 6,
                            Icon = "https://www.giantbomb.com/a/uploads/original/36/362334/3059196-bladeandsorcery.png",
                            Name = "Blade and Sorcery"
                        },
                        new
                        {
                            Id = 7,
                            Icon = "https://steamuserimages-a.akamaihd.net/ugc/490148340904984238/DD10B711A4378D7BF3D48F10E3535F29BEC3FB80/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true",
                            Name = "PAYDAY 2 VR"
                        },
                        new
                        {
                            Id = 8,
                            Icon = "https://images.discordapp.net/icons/556971445897396224/866ab404fa90cb84066fd06903c7c692.png?size=512",
                            Name = "The Forest"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameId = 3,
                            IsFavorite = true,
                            OwnerGuid = new Guid("407898b1-cf14-42a1-9b74-775587f878da"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 2,
                            GameId = 4,
                            IsFavorite = true,
                            OwnerGuid = new Guid("407898b1-cf14-42a1-9b74-775587f878da"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 3,
                            GameId = 1,
                            IsFavorite = true,
                            OwnerGuid = new Guid("407898b1-cf14-42a1-9b74-775587f878da"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 4,
                            GameId = 6,
                            IsFavorite = false,
                            OwnerGuid = new Guid("407898b1-cf14-42a1-9b74-775587f878da"),
                            Rating = (byte)95
                        },
                        new
                        {
                            Id = 5,
                            GameId = 3,
                            IsFavorite = true,
                            OwnerGuid = new Guid("309f1f3c-39a7-4701-b38e-aa68dafff1d7"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 6,
                            GameId = 4,
                            IsFavorite = true,
                            OwnerGuid = new Guid("fbfa8300-e0fd-410b-a7be-4357eb0fc6bc"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 7,
                            GameId = 1,
                            IsFavorite = true,
                            OwnerGuid = new Guid("ca7a6018-0cf2-45da-a54c-0de1e7401bb4"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 8,
                            GameId = 8,
                            IsFavorite = true,
                            OwnerGuid = new Guid("385f17c9-46b2-49f8-9425-9824369f6e84"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 9,
                            GameId = 3,
                            IsFavorite = true,
                            OwnerGuid = new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"),
                            Rating = (byte)98
                        },
                        new
                        {
                            Id = 10,
                            GameId = 4,
                            IsFavorite = true,
                            OwnerGuid = new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"),
                            Rating = (byte)87
                        },
                        new
                        {
                            Id = 11,
                            GameId = 1,
                            IsFavorite = true,
                            OwnerGuid = new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"),
                            Rating = (byte)90
                        },
                        new
                        {
                            Id = 12,
                            GameId = 6,
                            IsFavorite = false,
                            OwnerGuid = new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"),
                            Rating = (byte)65
                        },
                        new
                        {
                            Id = 13,
                            GameId = 3,
                            IsFavorite = true,
                            OwnerGuid = new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 14,
                            GameId = 4,
                            IsFavorite = true,
                            OwnerGuid = new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 15,
                            GameId = 1,
                            IsFavorite = true,
                            OwnerGuid = new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 16,
                            GameId = 6,
                            IsFavorite = false,
                            OwnerGuid = new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"),
                            Rating = (byte)77
                        },
                        new
                        {
                            Id = 17,
                            GameId = 3,
                            IsFavorite = false,
                            OwnerGuid = new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"),
                            Rating = (byte)63
                        },
                        new
                        {
                            Id = 18,
                            GameId = 4,
                            IsFavorite = false,
                            OwnerGuid = new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"),
                            Rating = (byte)55
                        },
                        new
                        {
                            Id = 19,
                            GameId = 1,
                            IsFavorite = false,
                            OwnerGuid = new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"),
                            Rating = (byte)59
                        },
                        new
                        {
                            Id = 20,
                            GameId = 6,
                            IsFavorite = false,
                            OwnerGuid = new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"),
                            Rating = (byte)50
                        },
                        new
                        {
                            Id = 21,
                            GameId = 3,
                            IsFavorite = true,
                            OwnerGuid = new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 22,
                            GameId = 4,
                            IsFavorite = true,
                            OwnerGuid = new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 23,
                            GameId = 1,
                            IsFavorite = true,
                            OwnerGuid = new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 24,
                            GameId = 6,
                            IsFavorite = true,
                            OwnerGuid = new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 25,
                            GameId = 3,
                            IsFavorite = true,
                            OwnerGuid = new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 26,
                            GameId = 4,
                            IsFavorite = false,
                            OwnerGuid = new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"),
                            Rating = (byte)74
                        },
                        new
                        {
                            Id = 27,
                            GameId = 1,
                            IsFavorite = false,
                            OwnerGuid = new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"),
                            Rating = (byte)69
                        },
                        new
                        {
                            Id = 28,
                            GameId = 6,
                            IsFavorite = false,
                            OwnerGuid = new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"),
                            Rating = (byte)62
                        },
                        new
                        {
                            Id = 29,
                            GameId = 3,
                            IsFavorite = false,
                            OwnerGuid = new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"),
                            Rating = (byte)73
                        },
                        new
                        {
                            Id = 30,
                            GameId = 4,
                            IsFavorite = false,
                            OwnerGuid = new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"),
                            Rating = (byte)64
                        },
                        new
                        {
                            Id = 31,
                            GameId = 1,
                            IsFavorite = true,
                            OwnerGuid = new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"),
                            Rating = (byte)100
                        },
                        new
                        {
                            Id = 32,
                            GameId = 6,
                            IsFavorite = false,
                            OwnerGuid = new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"),
                            Rating = (byte)47
                        });
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.UserInfo", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Avatar")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

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

                    b.HasData(
                        new
                        {
                            Guid = new Guid("407898b1-cf14-42a1-9b74-775587f878da"),
                            Avatar = "https://media.forgecdn.net/avatars/479/187/637776165451218467.jpeg",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            LastSeen = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Username = "vrenjoyer"
                        },
                        new
                        {
                            Guid = new Guid("309f1f3c-39a7-4701-b38e-aa68dafff1d7"),
                            Avatar = "https://yt3.ggpht.com/ytc/AKedOLT2-arf4z54qiWMx3T8WXuP7BKT6iMEIzBrU4uG=s900-c-k-c0x00ffffff-no-rj",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            LastSeen = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Username = "skyrimenjoyer"
                        },
                        new
                        {
                            Guid = new Guid("fbfa8300-e0fd-410b-a7be-4357eb0fc6bc"),
                            Avatar = "https://avatars.akamai.steamstatic.com/6a991cedbf9caf7e0dfd32c5f17f13820c818bf8_medium.jpg",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            LastSeen = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Username = "falloutenjoyer"
                        },
                        new
                        {
                            Guid = new Guid("ca7a6018-0cf2-45da-a54c-0de1e7401bb4"),
                            Avatar = "https://modelsaber.com/files/saber/1607719628/original.png",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            LastSeen = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Username = "beatsaberenjoyer"
                        },
                        new
                        {
                            Guid = new Guid("385f17c9-46b2-49f8-9425-9824369f6e84"),
                            Avatar = "https://avatars.akamai.steamstatic.com/e49df9e19ca580ebd13d8d6b69c43a6c9bad8ac0_medium.jpg",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            LastSeen = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Username = "forestenjoyer"
                        },
                        new
                        {
                            Guid = new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"),
                            Avatar = "https://cdn4.iconfinder.com/data/icons/vr-avatars/512/VR8-1024.png",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            LastSeen = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Username = "quest2enjoyer"
                        },
                        new
                        {
                            Guid = new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"),
                            Avatar = "https://avatars.akamai.steamstatic.com/07a8f40c65079d2a6caf4af91a5e466517cd7a19_medium.jpg",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            LastSeen = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Username = "quest3enjoyer"
                        },
                        new
                        {
                            Guid = new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"),
                            Avatar = "https://avatars.akamai.steamstatic.com/fef49e7fa7e1997310d705b2a6158ff8dc1cdfeb_full.jpg",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            LastSeen = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Username = "questproenjoyer"
                        },
                        new
                        {
                            Guid = new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"),
                            Avatar = "https://avatars.akamai.steamstatic.com/b3c041f3eb316e0edf16e6ba36f426b433e16cee_medium.jpg",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            LastSeen = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Username = "valveindexenjoyer"
                        },
                        new
                        {
                            Guid = new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"),
                            Avatar = "https://avatars.akamai.steamstatic.com/3388c1a9ff4cb271d0794154ff5e3405fae7b661_medium.jpg",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            LastSeen = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Username = "viveenjoyer"
                        },
                        new
                        {
                            Guid = new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"),
                            Avatar = "https://avatars.akamai.steamstatic.com/fc13bb1f59388dc6070a14f9224b6f697e08a4d3_medium.jpg",
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            LastSeen = new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Username = "vive2enjoyer"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsFavorite = true,
                            OwnerGuid = new Guid("407898b1-cf14-42a1-9b74-775587f878da"),
                            VrSetId = 3
                        },
                        new
                        {
                            Id = 2,
                            IsFavorite = true,
                            OwnerGuid = new Guid("407898b1-cf14-42a1-9b74-775587f878da"),
                            VrSetId = 4
                        },
                        new
                        {
                            Id = 3,
                            IsFavorite = true,
                            OwnerGuid = new Guid("407898b1-cf14-42a1-9b74-775587f878da"),
                            VrSetId = 6
                        },
                        new
                        {
                            Id = 4,
                            IsFavorite = false,
                            OwnerGuid = new Guid("309f1f3c-39a7-4701-b38e-aa68dafff1d7"),
                            VrSetId = 3
                        },
                        new
                        {
                            Id = 5,
                            IsFavorite = false,
                            OwnerGuid = new Guid("fbfa8300-e0fd-410b-a7be-4357eb0fc6bc"),
                            VrSetId = 3
                        },
                        new
                        {
                            Id = 6,
                            IsFavorite = false,
                            OwnerGuid = new Guid("ca7a6018-0cf2-45da-a54c-0de1e7401bb4"),
                            VrSetId = 3
                        },
                        new
                        {
                            Id = 7,
                            IsFavorite = false,
                            OwnerGuid = new Guid("385f17c9-46b2-49f8-9425-9824369f6e84"),
                            VrSetId = 3
                        },
                        new
                        {
                            Id = 8,
                            IsFavorite = true,
                            OwnerGuid = new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"),
                            VrSetId = 1
                        },
                        new
                        {
                            Id = 9,
                            IsFavorite = true,
                            OwnerGuid = new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"),
                            VrSetId = 3
                        },
                        new
                        {
                            Id = 10,
                            IsFavorite = true,
                            OwnerGuid = new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"),
                            VrSetId = 2
                        },
                        new
                        {
                            Id = 11,
                            IsFavorite = true,
                            OwnerGuid = new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"),
                            VrSetId = 4
                        },
                        new
                        {
                            Id = 12,
                            IsFavorite = true,
                            OwnerGuid = new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"),
                            VrSetId = 5
                        },
                        new
                        {
                            Id = 13,
                            IsFavorite = true,
                            OwnerGuid = new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"),
                            VrSetId = 6
                        });
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.VrSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.ToTable("VrSets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = "https://cdn.mos.cms.futurecdn.net/3tHJyGRakZSUbsQSgpqj3B.jpg",
                            Name = "Meta Quest 2"
                        },
                        new
                        {
                            Id = 2,
                            Icon = "https://wavypack.com/wp-content/uploads/2022/10/meta1-732x732.jpg",
                            Name = "Meta Quest Pro"
                        },
                        new
                        {
                            Id = 3,
                            Icon = "https://preview.free3d.com/img/2019/02/2188275829300004551/7br30t7k-900.jpg",
                            Name = "Meta Quest 3"
                        },
                        new
                        {
                            Id = 4,
                            Icon = "https://cf.shopee.co.th/file/e56de62ec3d3a8fc90192786bb5d45a2",
                            Name = "Valve Index VR Kit"
                        },
                        new
                        {
                            Id = 5,
                            Icon = "https://cdn.shopify.com/s/files/1/0570/6563/6015/products/vive-pro-full-kit-side_1445x.jpg?v=1622601723",
                            Name = "Htc Vive Pro"
                        },
                        new
                        {
                            Id = 6,
                            Icon = "https://www.robotistan.com/htc-vive-pro2-full-kit-38659-10-B.jpg",
                            Name = "Htc Vive Pro 2"
                        });
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.Friend", b =>
                {
                    b.HasOne("ProjectVR.DataAccess.Entities.UserInfo", "From")
                        .WithMany("Friends")
                        .HasForeignKey("FromUserGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectVR.DataAccess.Entities.UserInfo", "To")
                        .WithMany()
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

                    b.HasOne("ProjectVR.DataAccess.Entities.UserInfo", "Owner")
                        .WithMany("Games")
                        .HasForeignKey("OwnerGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.UserVrSet", b =>
                {
                    b.HasOne("ProjectVR.DataAccess.Entities.UserInfo", "Owner")
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

            modelBuilder.Entity("ProjectVR.DataAccess.Entities.UserInfo", b =>
                {
                    b.Navigation("Friends");

                    b.Navigation("Games");

                    b.Navigation("VrSets");
                });
#pragma warning restore 612, 618
        }
    }
}
