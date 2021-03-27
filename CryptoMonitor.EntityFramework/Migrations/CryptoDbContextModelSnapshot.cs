﻿// <auto-generated />
using System;
using CryptoMonitor.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CryptoMonitor.EntityFramework.Migrations
{
    [DbContext(typeof(CryptoDbContext))]
    partial class CryptoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("CryptoMonitor.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AccountOwnerId")
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("AccountOwnerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CryptoMonitor.Domain.Models.CryptoCurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("CurrentPrice")
                        .HasColumnType("double");

                    b.Property<string>("Ticker")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CryptoCurrencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentPrice = 0.0,
                            Ticker = "BTC"
                        },
                        new
                        {
                            Id = 2,
                            CurrentPrice = 0.0,
                            Ticker = "ETH"
                        },
                        new
                        {
                            Id = 3,
                            CurrentPrice = 0.0,
                            Ticker = "BNB"
                        },
                        new
                        {
                            Id = 4,
                            CurrentPrice = 0.0,
                            Ticker = "USDT"
                        },
                        new
                        {
                            Id = 5,
                            CurrentPrice = 0.0,
                            Ticker = "ADA"
                        },
                        new
                        {
                            Id = 6,
                            CurrentPrice = 0.0,
                            Ticker = "DOT"
                        },
                        new
                        {
                            Id = 7,
                            CurrentPrice = 0.0,
                            Ticker = "XRP"
                        },
                        new
                        {
                            Id = 8,
                            CurrentPrice = 0.0,
                            Ticker = "UNI"
                        },
                        new
                        {
                            Id = 9,
                            CurrentPrice = 0.0,
                            Ticker = "LTC"
                        },
                        new
                        {
                            Id = 10,
                            CurrentPrice = 0.0,
                            Ticker = "LINK"
                        });
                });

            modelBuilder.Entity("CryptoMonitor.Domain.Models.CryptoInvestment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateInvested")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsPurchase")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("CryptoInvestments");
                });

            modelBuilder.Entity("CryptoMonitor.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CryptoMonitor.Domain.Models.Account", b =>
                {
                    b.HasOne("CryptoMonitor.Domain.Models.User", "AccountOwner")
                        .WithMany()
                        .HasForeignKey("AccountOwnerId");

                    b.Navigation("AccountOwner");
                });

            modelBuilder.Entity("CryptoMonitor.Domain.Models.CryptoInvestment", b =>
                {
                    b.HasOne("CryptoMonitor.Domain.Models.Account", "Account")
                        .WithMany("CryptoInvestments")
                        .HasForeignKey("AccountId");

                    b.OwnsOne("CryptoMonitor.Domain.Models.CryptoCurrencyInvest", "CryptoCurrencyInvest", b1 =>
                        {
                            b1.Property<int>("CryptoInvestmentId")
                                .HasColumnType("int");

                            b1.Property<double>("Price")
                                .HasColumnType("double");

                            b1.Property<string>("Ticker")
                                .HasColumnType("text");

                            b1.HasKey("CryptoInvestmentId");

                            b1.ToTable("CryptoInvestments");

                            b1.WithOwner()
                                .HasForeignKey("CryptoInvestmentId");
                        });

                    b.Navigation("Account");

                    b.Navigation("CryptoCurrencyInvest");
                });

            modelBuilder.Entity("CryptoMonitor.Domain.Models.Account", b =>
                {
                    b.Navigation("CryptoInvestments");
                });
#pragma warning restore 612, 618
        }
    }
}
