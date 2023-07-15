﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleReSell.Data.Repository;

#nullable disable

namespace VehicleReSell.API.Migrations
{
    [DbContext(typeof(VehicleReSellDbContext))]
    [Migration("20230705142100_null_avatar")]
    partial class null_avatar
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CrudApiTemplate.Model.SystemLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewRecord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldRecord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("User")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SystemLogs");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Assessor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<int>("EntityType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Assessors");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<int>("EntityType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.CustomerEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SellerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("CustomerEvent");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.ItemReceipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ApproverId")
                        .HasColumnType("int");

                    b.Property<int?>("AssessorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<int>("ItemReceiptStatus")
                        .HasColumnType("int");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("AssessorId");

                    b.HasIndex("StaffId");

                    b.HasIndex("TransactionId");

                    b.ToTable("ItemReceipts");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.SaleOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SellerId");

                    b.HasIndex("TransactionId");

                    b.ToTable("SaleOrders");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<int>("EntityType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<int>("EntityType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ApprovalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("TotalAmount")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionStatus")
                        .HasColumnType("int");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.TransactionLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PICId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int?>("WareHouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PICId");

                    b.HasIndex("TransactionId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("WareHouseId");

                    b.ToTable("TransactionLines");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.TransferOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<string>("FromLocationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FromLocationId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LeaveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReceiveDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("ToLocationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ToLocationId")
                        .HasColumnType("int");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromLocationId");

                    b.HasIndex("StaffId");

                    b.HasIndex("ToLocationId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransferOrders");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AvatarLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long?>("AssessPrice")
                        .HasColumnType("bigint");

                    b.Property<int?>("AssessorId")
                        .HasColumnType("int");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CarModel")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imgs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NewAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("SoldPrice")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.Property<int?>("Usage")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Videos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WareHouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssessorId");

                    b.HasIndex("VehicleOwnerId");

                    b.HasIndex("WareHouseId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.VehicleOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<int>("EntityType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VehicleOwners");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.WareHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AvailableCapacity")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteById")
                        .HasColumnType("int");

                    b.Property<int?>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WareHouses");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Assessor", b =>
                {
                    b.HasOne("VehicleReSell.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.CustomerEvent", b =>
                {
                    b.HasOne("VehicleReSell.Data.Model.Customer", "Customer")
                        .WithMany("CustomerEvents")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");

                    b.Navigation("Seller");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.ItemReceipt", b =>
                {
                    b.HasOne("VehicleReSell.Data.Model.User", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.Assessor", "Assessor")
                        .WithMany("ItemReceipts")
                        .HasForeignKey("AssessorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Approver");

                    b.Navigation("Assessor");

                    b.Navigation("Staff");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.SaleOrder", b =>
                {
                    b.HasOne("VehicleReSell.Data.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.Seller", "Seller")
                        .WithMany("SaleOrders")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");

                    b.Navigation("Seller");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Seller", b =>
                {
                    b.HasOne("VehicleReSell.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Staff", b =>
                {
                    b.HasOne("VehicleReSell.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.TransactionLine", b =>
                {
                    b.HasOne("VehicleReSell.Data.Model.User", "PIC")
                        .WithMany()
                        .HasForeignKey("PICId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.Transaction", "Transaction")
                        .WithMany("TransactionLines")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VehicleReSell.Data.Model.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.WareHouse", "WareHouse")
                        .WithMany()
                        .HasForeignKey("WareHouseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("PIC");

                    b.Navigation("Transaction");

                    b.Navigation("Vehicle");

                    b.Navigation("WareHouse");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.TransferOrder", b =>
                {
                    b.HasOne("VehicleReSell.Data.Model.WareHouse", "FromLocation")
                        .WithMany()
                        .HasForeignKey("FromLocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.Staff", "Staff")
                        .WithMany("TransferOrders")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.WareHouse", "ToLocation")
                        .WithMany()
                        .HasForeignKey("ToLocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FromLocation");

                    b.Navigation("Staff");

                    b.Navigation("ToLocation");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Vehicle", b =>
                {
                    b.HasOne("VehicleReSell.Data.Model.Assessor", "Assessor")
                        .WithMany()
                        .HasForeignKey("AssessorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.VehicleOwner", "VehicleOwner")
                        .WithMany()
                        .HasForeignKey("VehicleOwnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VehicleReSell.Data.Model.WareHouse", "WareHouse")
                        .WithMany("Vehicles")
                        .HasForeignKey("WareHouseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Assessor");

                    b.Navigation("VehicleOwner");

                    b.Navigation("WareHouse");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Assessor", b =>
                {
                    b.Navigation("ItemReceipts");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Customer", b =>
                {
                    b.Navigation("CustomerEvents");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Seller", b =>
                {
                    b.Navigation("SaleOrders");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Staff", b =>
                {
                    b.Navigation("TransferOrders");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.Transaction", b =>
                {
                    b.Navigation("TransactionLines");
                });

            modelBuilder.Entity("VehicleReSell.Data.Model.WareHouse", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
