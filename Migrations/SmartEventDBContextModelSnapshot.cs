﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _1.SmartEvent.Data.DbContexte;

#nullable disable

namespace _1.Migrations
{
    [DbContext(typeof(SmartEventDBContext))]
    partial class SmartEventDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EvenementUtilisateur", b =>
                {
                    b.Property<int>("EvenementsInscritsId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantsId")
                        .HasColumnType("int");

                    b.HasKey("EvenementsInscritsId", "ParticipantsId");

                    b.HasIndex("ParticipantsId");

                    b.ToTable("EvenementUtilisateur");
                });

            modelBuilder.Entity("_1.SmartEvent.Core.Modèles.Evenement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CapaciteMax")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lieu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Evenements");
                });

            modelBuilder.Entity("_1.SmartEvent.Core.Modèles.Inscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateInscription")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EvenementId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvenementId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Inscriptions");
                });

            modelBuilder.Entity("_1.SmartEvent.Core.Modèles.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.ToTable("Personne");

                    b.HasDiscriminator<string>("Role").HasValue("Personne");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("_1.SmartEvent.Core.Modèles.Admin", b =>
                {
                    b.HasBaseType("_1.SmartEvent.Core.Modèles.Personne");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("_1.SmartEvent.Core.Modèles.Utilisateur", b =>
                {
                    b.HasBaseType("_1.SmartEvent.Core.Modèles.Personne");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("EvenementUtilisateur", b =>
                {
                    b.HasOne("_1.SmartEvent.Core.Modèles.Evenement", null)
                        .WithMany()
                        .HasForeignKey("EvenementsInscritsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_1.SmartEvent.Core.Modèles.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_1.SmartEvent.Core.Modèles.Inscription", b =>
                {
                    b.HasOne("_1.SmartEvent.Core.Modèles.Evenement", "Evenement")
                        .WithMany("Inscriptions")
                        .HasForeignKey("EvenementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_1.SmartEvent.Core.Modèles.Utilisateur", "Utilisateur")
                        .WithMany("Inscriptions")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evenement");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("_1.SmartEvent.Core.Modèles.Evenement", b =>
                {
                    b.Navigation("Inscriptions");
                });

            modelBuilder.Entity("_1.SmartEvent.Core.Modèles.Utilisateur", b =>
                {
                    b.Navigation("Inscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
