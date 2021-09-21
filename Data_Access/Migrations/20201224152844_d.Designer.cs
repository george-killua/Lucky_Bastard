﻿// <auto-generated />
using System;
using Data_Access.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data_Access.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20201224152844_d")]
    partial class d
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Data_Access.GameInstraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("GameImageURL")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("GameName")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("GameURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GameInstractions");
                });

            modelBuilder.Entity("Data_Access.Grand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Creater")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("CurrentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Prize")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Grand");
                });

            modelBuilder.Entity("Data_Access.JackbotWinner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateOfWinning")
                        .HasColumnType("datetime2");

                    b.Property<bool>("GotIt")
                        .HasColumnType("bit");

                    b.Property<string>("JackbotName")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("WinnerName")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("ID");

                    b.ToTable("jackbotWinner");
                });

            modelBuilder.Entity("Data_Access.Models.ChargeHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("BalanceIn")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BalanceOut")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Bonus")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ChargeTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creater")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Ip")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("ID");

                    b.HasIndex("Creater");

                    b.ToTable("ChargeHistories");
                });

            modelBuilder.Entity("Data_Access.Models.GameHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Bet")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Creater")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("FreeSpin")
                        .HasColumnType("bit");

                    b.Property<string>("GameName")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lines")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("WLAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Wild")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("Creater");

                    b.ToTable("GameHistories");
                });

            modelBuilder.Entity("Data_Access.Models.LoginHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Creater")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Ip")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("LoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Username")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("ID");

                    b.HasIndex("Creater");

                    b.ToTable("LoginHistories");
                });

            modelBuilder.Entity("Data_Access.Models.Major", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Creater")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("CurrentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Prize")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Major");
                });

            modelBuilder.Entity("Data_Access.Models.Mini", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Creater")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("CurrentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Prize")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Mini");
                });

            modelBuilder.Entity("Data_Access.Models.Minor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Creater")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("CurrentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Prize")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Mainer");
                });

            modelBuilder.Entity("Data_Access.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BalanceIn")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BalanceOut")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Creater")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("DoubleBunosActive")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Ip")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<double>("Level")
                        .HasColumnType("float");

                    b.Property<int>("LoginTimes")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PercantageOfLuck")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("Username");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Data_Access.Models.ChargeHistory", b =>
                {
                    b.HasOne("Data_Access.Models.User", "User")
                        .WithMany("ChargeHistories")
                        .HasForeignKey("Creater")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data_Access.Models.GameHistory", b =>
                {
                    b.HasOne("Data_Access.Models.User", "User")
                        .WithMany("GameHistories")
                        .HasForeignKey("Creater")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data_Access.Models.LoginHistory", b =>
                {
                    b.HasOne("Data_Access.Models.User", "User")
                        .WithMany("LoginHistories")
                        .HasForeignKey("Creater")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data_Access.Models.User", b =>
                {
                    b.Navigation("ChargeHistories");

                    b.Navigation("GameHistories");

                    b.Navigation("LoginHistories");
                });
#pragma warning restore 612, 618
        }
    }
}