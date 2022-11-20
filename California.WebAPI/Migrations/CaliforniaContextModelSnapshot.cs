﻿// <auto-generated />
using California.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace California.WebAPI.Migrations
{
    [DbContext(typeof(CaliforniaContext))]
    partial class CaliforniaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("California.WebAPI.Entities.UserInfoEntity", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Sys_User");
                });
#pragma warning restore 612, 618
        }
    }
}