﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradePMR.DanielSerrano.Data;

namespace TradePMR.DanielSerrano.Data.Migrations
{
    [DbContext(typeof(TradePMRDbContext))]
    [Migration("20190521112647_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TradePMR.DanielSerrano.Common.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2019, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(2019, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Steve"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2019, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(2019, 4, 21, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "George"
                        });
                });

            modelBuilder.Entity("TradePMR.DanielSerrano.Common.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<int>("Action");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int>("Quantity");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Trades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            Action = 0,
                            DateCreated = new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 10,
                            Symbol = "GE"
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 2,
                            Action = 1,
                            DateCreated = new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 10,
                            Symbol = "GE"
                        },
                        new
                        {
                            Id = 3,
                            AccountId = 1,
                            Action = 0,
                            DateCreated = new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 10,
                            Symbol = "AAPL"
                        });
                });

            modelBuilder.Entity("TradePMR.DanielSerrano.Common.Trade", b =>
                {
                    b.HasOne("TradePMR.DanielSerrano.Common.Account", "Account")
                        .WithMany("Trades")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
