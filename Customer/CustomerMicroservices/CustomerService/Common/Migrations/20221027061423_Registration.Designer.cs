// <auto-generated />
using System;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Common.Migrations
{
    [DbContext(typeof(customerserviceDBContext))]
    [Migration("20221027061423_Registration")]
    partial class Registration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Common.Models.Country", b =>
                {
                    b.Property<int>("cId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("countryname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cId");

                    b.ToTable("Countrys");
                });

            modelBuilder.Entity("Common.Models.District", b =>
                {
                    b.Property<int>("districtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("districtname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stateId")
                        .HasColumnType("int");

                    b.HasKey("districtId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Common.Models.Registration", b =>
                {
                    b.Property<int>("registrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cId")
                        .HasColumnType("int");

                    b.Property<string>("contactnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("districtId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pancard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("registrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("stateId")
                        .HasColumnType("int");

                    b.HasKey("registrationId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("Common.Models.State", b =>
                {
                    b.Property<int>("stateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cId")
                        .HasColumnType("int");

                    b.Property<string>("statename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("stateId");

                    b.ToTable("States");
                });
#pragma warning restore 612, 618
        }
    }
}
