﻿// <auto-generated />
using System;
using MagicPost__Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicPost__Data.Migrations
{
    [DbContext(typeof(MagicPostDbContext))]
    partial class MagicPostDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MagicPost__Data.Entities.AppConfig", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Key");

                    b.ToTable("AppConfigs", (string)null);

                    b.HasData(
                        new
                        {
                            Key = "HomeTitle",
                            Value = "This is home page of MagicPost"
                        },
                        new
                        {
                            Key = "HomeKeyword",
                            Value = "This is keyword of MagicPost"
                        },
                        new
                        {
                            Key = "HomeDescription",
                            Value = "This is description of MagicPost"
                        });
                });

            modelBuilder.Entity("MagicPost__Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                            ConcurrencyStamp = "e40c990d-6d60-40f5-b72d-1aa2cbb5756a",
                            Description = "Trưởng điểm giao dịch và tập kết ",
                            Name = "TruongDiem",
                            NormalizedName = "TruongDiem"
                        },
                        new
                        {
                            Id = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            ConcurrencyStamp = "db6f0daa-c07b-4e7f-9211-e088c7dd6e0d",
                            Description = "Lãnh đạo",
                            Name = "LanhDao",
                            NormalizedName = "LanhDao"
                        },
                        new
                        {
                            Id = new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"),
                            ConcurrencyStamp = "23bdc0cf-7d7b-40e7-add8-fe2e312f6908",
                            Description = "Giao dịch viên",
                            Name = "GiaoDichVien",
                            NormalizedName = "GiaoDichVien"
                        },
                        new
                        {
                            Id = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                            ConcurrencyStamp = "a083c1c4-afe0-47f7-a9aa-0854703a4bea",
                            Description = "Nhân viên tập kết",
                            Name = "NhanVienTapKet",
                            NormalizedName = "NhanVienTapKet"
                        });
                });

            modelBuilder.Entity("MagicPost__Data.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DiemGiaoDichId")
                        .HasColumnType("int");

                    b.Property<int?>("DiemTapKetId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiemGiaoDichId");

                    b.HasIndex("DiemTapKetId");

                    b.ToTable("AppUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "06b673b7-6bb4-4558-8502-d4c6f958278c",
                            Dob = new DateTime(2003, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hieumai09042003@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Hieu",
                            LastName = "Nguyen",
                            LockoutEnabled = false,
                            NormalizedEmail = "hieumai09042003@gmail.com",
                            NormalizedUserName = "NhanVienTapKet",
                            PasswordHash = "AQAAAAEAACcQAAAAEESBStYU69S+dMcCgi3LneaZxYtIr6CQ8PfPmPGNdc2Cv9kNXWLhcLGkmgyoD+n9tw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "NhanVienTapKet"
                        });
                });

            modelBuilder.Entity("MagicPost__Data.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Contacts", (string)null);
                });

            modelBuilder.Entity("MagicPost__Data.Entities.DiemGiaoDich", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DiemTapKetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DiemTapKetId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("DiemGiaoDichs", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "144 Xuan Thuy, Cau Giay, Ha Noi",
                            DiemTapKetId = 1,
                            Name = "Diem Giao Dich 1.1",
                            UserId = new Guid("7dba6422-7136-4d8d-488c-08dbf31d70c7")
                        },
                        new
                        {
                            Id = 2,
                            Address = "36 Xuan Thuy, Cau Giay, Ha Noi",
                            DiemTapKetId = 1,
                            Name = "Diem Giao Dich 1.2",
                            UserId = new Guid("d756ad9c-bd14-4e57-88f2-08dbf52dd1ef")
                        },
                        new
                        {
                            Id = 3,
                            Address = "27 Xuan Thuy, Cau Giay, Ha Noi",
                            DiemTapKetId = 1,
                            Name = "Diem Giao Dich 1.3"
                        },
                        new
                        {
                            Id = 4,
                            Address = "27 De La Thanh, Ba Dinh, Ha Noi",
                            DiemTapKetId = 2,
                            Name = "Diem Giao Dich 2.1"
                        },
                        new
                        {
                            Id = 5,
                            Address = "39 De La Thanh, Ba Dinh, Ha Noi",
                            DiemTapKetId = 2,
                            Name = "Diem Giao Dich 2.2"
                        });
                });

            modelBuilder.Entity("MagicPost__Data.Entities.DiemTapKet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("DiemTapKets", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Xuan Thuy, Cau Giay, Ha Noi",
                            Name = "Diem Tap Ket 1",
                            UserId = new Guid("7dba6422-7136-4d8d-488c-08dbf31d70c7")
                        },
                        new
                        {
                            Id = 2,
                            Address = "De La Thanh, Ba Dinh, Ha Noi",
                            Name = "Diem Tap Ket 2",
                            UserId = new Guid("d756ad9c-bd14-4e57-88f2-08dbf52dd1ef")
                        });
                });

            modelBuilder.Entity("MagicPost__Data.Entities.Language", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Languages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "vi",
                            IsDefault = true,
                            Name = "Tiếng Việt"
                        },
                        new
                        {
                            Id = "en",
                            IsDefault = false,
                            Name = "English"
                        });
                });

            modelBuilder.Entity("MagicPost__Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cuoc")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("KhoiLuong")
                        .HasColumnType("float");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiveAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceivePhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SendAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SendName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SendPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "MAX123",
                            Cuoc = 100000m,
                            KhoiLuong = 1.2,
                            OrderDate = new DateTime(2023, 12, 9, 21, 15, 56, 653, DateTimeKind.Local).AddTicks(8696),
                            ReceiveAddress = "Xuan Thuy",
                            ReceiveName = "Hung",
                            ReceivePhoneNumber = "088965072",
                            SendAddress = "Cau giay",
                            SendName = "Hieu",
                            SendPhoneNumber = "0827259403",
                            Status = 0,
                            UserId = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc")
                        });
                });

            modelBuilder.Entity("MagicPost__Data.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.ToTable("OrderDetails", (string)null);
                });

            modelBuilder.Entity("MagicPost__Data.Entities.OrderImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("ProductImages", (string)null);
                });

            modelBuilder.Entity("MagicPost__Data.Entities.OrderTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LanguageId")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("SeoAlias")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SeoDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("OrderTranslations", (string)null);
                });

            modelBuilder.Entity("MagicPost__Data.Entities.Slide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Slides", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Magic Post siêu uy tín, uy tín số 1 Việt Nam",
                            Image = "/themes/images/carousel/1.png",
                            Name = "Magic Post siêu uy tín",
                            SortOrder = 1,
                            Status = 1,
                            Url = "#"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Magic Post siêu uy tín, uy tín số 1 Việt Nam",
                            Image = "/themes/images/carousel/2.png",
                            Name = "Magic Post siêu uy tín",
                            SortOrder = 2,
                            Status = 1,
                            Url = "#"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Magic Post siêu uy tín, uy tín số 1 Việt Nam",
                            Image = "/themes/images/carousel/3.png",
                            Name = "Magic Post siêu uy tín",
                            SortOrder = 3,
                            Status = 1,
                            Url = "#"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Magic Post siêu uy tín, uy tín số 1 Việt Nam",
                            Image = "/themes/images/carousel/4.png",
                            Name = "Magic Post siêu uy tín",
                            SortOrder = 4,
                            Status = 1,
                            Url = "#"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Magic Post siêu uy tín, uy tín số 1 Việt Nam",
                            Image = "/themes/images/carousel/5.png",
                            Name = "Magic Post siêu uy tín",
                            SortOrder = 5,
                            Status = 1,
                            Url = "#"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Magic Post siêu uy tín, uy tín số 1 Việt Nam",
                            Image = "/themes/images/carousel/6.png",
                            Name = "Magic Post siêu uy tín",
                            SortOrder = 6,
                            Status = 1,
                            Url = "#"
                        });
                });

            modelBuilder.Entity("MagicPost__Data.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ExternalTransactionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AppUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                            RoleId = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens", (string)null);
                });

            modelBuilder.Entity("MagicPost__Data.Entities.AppUser", b =>
                {
                    b.HasOne("MagicPost__Data.Entities.DiemGiaoDich", "DiemGiaoDich")
                        .WithMany()
                        .HasForeignKey("DiemGiaoDichId");

                    b.HasOne("MagicPost__Data.Entities.DiemTapKet", "DiemTapKet")
                        .WithMany()
                        .HasForeignKey("DiemTapKetId");

                    b.Navigation("DiemGiaoDich");

                    b.Navigation("DiemTapKet");
                });

            modelBuilder.Entity("MagicPost__Data.Entities.DiemGiaoDich", b =>
                {
                    b.HasOne("MagicPost__Data.Entities.DiemTapKet", "DiemTapKet")
                        .WithMany("DiemGiaoDichs")
                        .HasForeignKey("DiemTapKetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MagicPost__Data.Entities.AppUser", "TruongDiemGiaoDich")
                        .WithOne()
                        .HasForeignKey("MagicPost__Data.Entities.DiemGiaoDich", "UserId");

                    b.Navigation("DiemTapKet");

                    b.Navigation("TruongDiemGiaoDich");
                });

            modelBuilder.Entity("MagicPost__Data.Entities.DiemTapKet", b =>
                {
                    b.HasOne("MagicPost__Data.Entities.AppUser", "TruongDiemTapKet")
                        .WithOne()
                        .HasForeignKey("MagicPost__Data.Entities.DiemTapKet", "UserId");

                    b.Navigation("TruongDiemTapKet");
                });

            modelBuilder.Entity("MagicPost__Data.Entities.Order", b =>
                {
                    b.HasOne("MagicPost__Data.Entities.AppUser", "AppUser")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("MagicPost__Data.Entities.OrderDetail", b =>
                {
                    b.HasOne("MagicPost__Data.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MagicPost__Data.Entities.OrderImage", b =>
                {
                    b.HasOne("MagicPost__Data.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MagicPost__Data.Entities.OrderTranslation", b =>
                {
                    b.HasOne("MagicPost__Data.Entities.Language", "Language")
                        .WithMany("ProductTranslations")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("MagicPost__Data.Entities.Transaction", b =>
                {
                    b.HasOne("MagicPost__Data.Entities.AppUser", "AppUser")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("MagicPost__Data.Entities.AppUser", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("MagicPost__Data.Entities.DiemTapKet", b =>
                {
                    b.Navigation("DiemGiaoDichs");
                });

            modelBuilder.Entity("MagicPost__Data.Entities.Language", b =>
                {
                    b.Navigation("ProductTranslations");
                });

            modelBuilder.Entity("MagicPost__Data.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
