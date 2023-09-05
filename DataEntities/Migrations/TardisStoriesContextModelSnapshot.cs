﻿// <auto-generated />
using System;
using DataEntities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataEntities.Migrations
{
    [DbContext(typeof(TardisContext))]
    partial class TardisStoriesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataEntities.Entities.Tardis.Module", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(1024)");

                    b.Property<double>("DefaultVersion")
                        .HasColumnType("float");

                    b.Property<double>("MinimumVersion")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Name");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("DataEntities.Entities.Tardis.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("BirthLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeathLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("GivenName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("DataEntities.Entities.Tardis.PersonHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArchiveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("BirthLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeathLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("GivenName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PeopleHistory");
                });

            modelBuilder.Entity("DataEntities.Entities.Tardis.PersonHistory", b =>
                {
                    b.HasOne("DataEntities.Entities.Tardis.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
