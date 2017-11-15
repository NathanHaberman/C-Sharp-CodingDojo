using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TheDojoLeague.Models;

namespace CodeFirstTemplate.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("TheDojoLeague.Models.Dojo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("Dojos");
                });

            modelBuilder.Entity("TheDojoLeague.Models.Membership", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DojoId");

                    b.Property<int>("NinjaId");

                    b.Property<int>("PendingNinjaId");

                    b.HasKey("id");

                    b.HasIndex("DojoId");

                    b.HasIndex("NinjaId");

                    b.HasIndex("PendingNinjaId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("TheDojoLeague.Models.Ninja", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Dojoid");

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("id");

                    b.HasIndex("Dojoid");

                    b.HasIndex("UserId");

                    b.ToTable("Ninjas");
                });

            modelBuilder.Entity("TheDojoLeague.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TheDojoLeague.Models.Dojo", b =>
                {
                    b.HasOne("TheDojoLeague.Models.User", "User")
                        .WithMany("Dojos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheDojoLeague.Models.Membership", b =>
                {
                    b.HasOne("TheDojoLeague.Models.Dojo", "Dojo")
                        .WithMany()
                        .HasForeignKey("DojoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TheDojoLeague.Models.Ninja", "Ninja")
                        .WithMany()
                        .HasForeignKey("NinjaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TheDojoLeague.Models.Ninja", "PendingNinja")
                        .WithMany()
                        .HasForeignKey("PendingNinjaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheDojoLeague.Models.Ninja", b =>
                {
                    b.HasOne("TheDojoLeague.Models.Dojo")
                        .WithMany("Ninjas")
                        .HasForeignKey("Dojoid");

                    b.HasOne("TheDojoLeague.Models.User", "User")
                        .WithMany("Ninjas")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
