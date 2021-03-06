﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReMember.Models;

namespace ReMember.Migrations
{
    [DbContext(typeof(ReMemberContext))]
    [Migration("20190223192304_add_regex_back_in")]
    partial class add_regex_back_in
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReMember.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MemberAddress");

                    b.Property<string>("MemberFirstName");

                    b.Property<string>("MemberLastName");

                    b.Property<string>("MemberPhoneNumber")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.ToTable("Member");
                });
#pragma warning restore 612, 618
        }
    }
}
