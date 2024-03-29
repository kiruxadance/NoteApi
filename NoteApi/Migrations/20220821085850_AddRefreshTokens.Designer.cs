﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteApi;

#nullable disable

namespace NoteApi.Migrations
{
    [DbContext(typeof(AppDatabaseContext))]
    [Migration("20220821085850_AddRefreshTokens")]
    partial class AddRefreshTokens
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NoteApi.Models.Entities.PathWrapper", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Alpha")
                        .HasColumnType("bigint");

                    b.Property<long>("StrokeColor")
                        .HasColumnType("bigint");

                    b.Property<float>("StrokeWidth")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PathWrappers");
                });

            modelBuilder.Entity("NoteApi.Models.Entities.Point", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PathWrapperId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("X")
                        .HasColumnType("real");

                    b.Property<float>("Y")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PathWrapperId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("NoteApi.Models.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("NoteApi.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NoteApi.Models.Entities.PathWrapper", b =>
                {
                    b.HasOne("NoteApi.Models.Entities.User", "User")
                        .WithMany("pathWrappers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoteApi.Models.Entities.Point", b =>
                {
                    b.HasOne("NoteApi.Models.Entities.PathWrapper", null)
                        .WithMany("Points")
                        .HasForeignKey("PathWrapperId");
                });

            modelBuilder.Entity("NoteApi.Models.Entities.PathWrapper", b =>
                {
                    b.Navigation("Points");
                });

            modelBuilder.Entity("NoteApi.Models.Entities.User", b =>
                {
                    b.Navigation("pathWrappers");
                });
#pragma warning restore 612, 618
        }
    }
}
