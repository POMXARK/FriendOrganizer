// <auto-generated />
using System;
using FriendOrganizer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FriendOrganizer.DataAccess.Migrations
{
    [DbContext(typeof(FriendOrganizerDbContext))]
    [Migration("20221013203831_AddedProgrammingLanguage")]
    partial class AddedProgrammingLanguage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("FriendOrganizer.Model.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FavoriteLanguageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FavoriteLanguageId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("FriendOrganizer.Model.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages");
                });

            modelBuilder.Entity("FriendOrganizer.Model.Friend", b =>
                {
                    b.HasOne("FriendOrganizer.Model.ProgrammingLanguage", "FavoriteLanguage")
                        .WithMany()
                        .HasForeignKey("FavoriteLanguageId");

                    b.Navigation("FavoriteLanguage");
                });
#pragma warning restore 612, 618
        }
    }
}
