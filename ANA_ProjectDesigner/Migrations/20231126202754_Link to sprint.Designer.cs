﻿// <auto-generated />
using System;
using ANA_ProjectDesigner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ANAProjectDesigner.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20231126202754_Link to sprint")]
    partial class Linktosprint
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.Profil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Profil");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.Ressource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SprintId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SprintId");

                    b.ToTable("Ressource");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.Sprint", b =>
                {
                    b.Property<Guid>("SprintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SprintName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SprintId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Sprint");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.WorkItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SprintId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SprintId");

                    b.ToTable("WorkItem");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.WorkItemRessource", b =>
                {
                    b.Property<Guid>("WorkItemId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<Guid>("RessourceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<int>("OriginalEstimate")
                        .HasColumnType("int");

                    b.Property<Guid>("SprintId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(2);

                    b.HasKey("WorkItemId", "RessourceId");

                    b.HasIndex("RessourceId");

                    b.HasIndex("SprintId");

                    b.ToTable("WorkItemRessource");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.Project", b =>
                {
                    b.HasOne("ANA_ProjectDesigner.Models.Domain.Profil", "Profil")
                        .WithMany("projectList")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profil");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.Ressource", b =>
                {
                    b.HasOne("ANA_ProjectDesigner.Models.Domain.Sprint", null)
                        .WithMany("Ressources")
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.Sprint", b =>
                {
                    b.HasOne("ANA_ProjectDesigner.Models.Domain.Project", "Projects")
                        .WithMany("Sprints")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.WorkItem", b =>
                {
                    b.HasOne("ANA_ProjectDesigner.Models.Domain.Sprint", null)
                        .WithMany("WorkItems")
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.WorkItemRessource", b =>
                {
                    b.HasOne("ANA_ProjectDesigner.Models.Domain.Ressource", "Ressource")
                        .WithMany("WorkItemRessources")
                        .HasForeignKey("RessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ANA_ProjectDesigner.Models.Domain.Sprint", "Sprint")
                        .WithMany()
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ANA_ProjectDesigner.Models.Domain.WorkItem", "WorkItem")
                        .WithMany("WorkItemRessources")
                        .HasForeignKey("WorkItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ressource");

                    b.Navigation("Sprint");

                    b.Navigation("WorkItem");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.Profil", b =>
                {
                    b.Navigation("projectList");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.Project", b =>
                {
                    b.Navigation("Sprints");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.Ressource", b =>
                {
                    b.Navigation("WorkItemRessources");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.Sprint", b =>
                {
                    b.Navigation("Ressources");

                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("ANA_ProjectDesigner.Models.Domain.WorkItem", b =>
                {
                    b.Navigation("WorkItemRessources");
                });
#pragma warning restore 612, 618
        }
    }
}
