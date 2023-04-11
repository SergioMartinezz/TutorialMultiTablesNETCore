﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TutorialMultiTablesNETCore.Context;

#nullable disable

namespace TutorialMultiTablesNETCore.Migrations
{
    [DbContext(typeof(ActividadesDbContext))]
    [Migration("20230409185243_M1")]
    partial class M1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TutorialMultiTablesNETCore.Models.Actividad", b =>
                {
                    b.Property<int>("ActividadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActividadId"));

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plazas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActividadId");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Actividades");
                });

            modelBuilder.Entity("TutorialMultiTablesNETCore.Models.Alumno", b =>
                {
                    b.Property<int>("AlumnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlumnoId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlumnoId");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("TutorialMultiTablesNETCore.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructores");
                });

            modelBuilder.Entity("TutorialMultiTablesNETCore.Models.Actividad", b =>
                {
                    b.HasOne("TutorialMultiTablesNETCore.Models.Alumno", "Alumno")
                        .WithMany()
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutorialMultiTablesNETCore.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Instructor");
                });
#pragma warning restore 612, 618
        }
    }
}
