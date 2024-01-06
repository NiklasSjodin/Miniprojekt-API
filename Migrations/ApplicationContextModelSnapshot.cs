﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Miniprojekt_API.Data;

#nullable disable

namespace Miniprojekt_API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.Property<int>("InterestsID")
                        .HasColumnType("int");

                    b.Property<int>("PersonsID")
                        .HasColumnType("int");

                    b.HasKey("InterestsID", "PersonsID");

                    b.HasIndex("PersonsID");

                    b.ToTable("InterestPerson");
                });

            modelBuilder.Entity("Miniprojekt_API.Models.Interest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("Miniprojekt_API.Models.InterestLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("InterestsID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InterestsID");

                    b.HasIndex("PersonID");

                    b.ToTable("InterestLinks");
                });

            modelBuilder.Entity("Miniprojekt_API.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.HasOne("Miniprojekt_API.Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Miniprojekt_API.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Miniprojekt_API.Models.InterestLink", b =>
                {
                    b.HasOne("Miniprojekt_API.Models.Interest", "Interests")
                        .WithMany("InterestLinks")
                        .HasForeignKey("InterestsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Miniprojekt_API.Models.Person", "Person")
                        .WithMany("InterestLinks")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interests");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Miniprojekt_API.Models.Interest", b =>
                {
                    b.Navigation("InterestLinks");
                });

            modelBuilder.Entity("Miniprojekt_API.Models.Person", b =>
                {
                    b.Navigation("InterestLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
