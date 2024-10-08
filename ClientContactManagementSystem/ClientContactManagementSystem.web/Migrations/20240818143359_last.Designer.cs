﻿// <auto-generated />
using System;
using ClientContactManagementSystem.web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClientContactManagementSystem.web.Migrations
{
    [DbContext(typeof(ClientManagementDbContext))]
    [Migration("20240818143359_last")]
    partial class last
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClientContactManagementSystem.web.Models.Entities.Clients", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfLinkedContact")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.ToTable("tblClients");
                });

            modelBuilder.Entity("ClientContactManagementSystem.web.Models.Entities.Contact", b =>
                {
                    b.Property<Guid>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("linkClientCheck")
                        .HasColumnType("bit");

                    b.HasKey("ContactId");

                    b.ToTable("tblContacts");
                });

            modelBuilder.Entity("ClientsContact", b =>
                {
                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactsContactId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClientId", "ContactsContactId");

                    b.HasIndex("ContactsContactId");

                    b.ToTable("ClientsContact");
                });

            modelBuilder.Entity("ClientsContact", b =>
                {
                    b.HasOne("ClientContactManagementSystem.web.Models.Entities.Clients", null)
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientContactManagementSystem.web.Models.Entities.Contact", null)
                        .WithMany()
                        .HasForeignKey("ContactsContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
