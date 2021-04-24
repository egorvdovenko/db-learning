using System;
using DBLearning.Tbls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBLearning
{
    public partial class Db222zisContext : DbContext
    {
        public Db222zisContext()
        {
        }

        public Db222zisContext(DbContextOptions<Db222zisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDoctor> TblDoctor { get; set; }
        public virtual DbSet<TblPatient> TblPatient { get; set; }
        public virtual DbSet<TblTreatmentSet> TblTreatmentSet { get; set; }
        public virtual DbSet<TblTreatmentType> TblTreatmentType { get; set; }
        public virtual DbSet<TblTreatmentVisit> TblTreatmentVisit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=\\SQLEXPRESS;Database=db222zis;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDoctor>(entity =>
            {
                entity.HasKey(e => e.IntDoctorId)
                    .HasName("PK__tblDocto__3F7184FFED6156B6");

                entity.ToTable("tblDoctor");

                entity.Property(e => e.IntDoctorId).HasColumnName("intDoctorId");

                entity.Property(e => e.DatDoctorWork)
                    .HasColumnName("datDoctorWork")
                    .HasColumnType("date");

                entity.Property(e => e.TxtDoctorName)
                    .HasColumnName("txtDoctorName")
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.TxtSpecialist)
                    .HasColumnName("txtSpecialist")
                    .HasMaxLength(35)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblPatient>(entity =>
            {
                entity.HasKey(e => e.IntPatientId)
                    .HasName("PK__tblPatie__AAE3F6F0D9959E89");

                entity.ToTable("tblPatient");

                entity.Property(e => e.IntPatientId).HasColumnName("intPatientId");

                entity.Property(e => e.DatBirthday)
                    .HasColumnName("datBirthday")
                    .HasColumnType("date");

                entity.Property(e => e.TxtAddress)
                    .HasColumnName("txtAddress")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.TxtPatientName)
                    .HasColumnName("txtPatientName")
                    .HasMaxLength(25)
                    .IsFixedLength();

                entity.Property(e => e.TxtPatientSecondName)
                    .HasColumnName("txtPatientSecondName")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.TxtPatientSurname)
                    .HasColumnName("txtPatientSurname")
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblTreatmentSet>(entity =>
            {
                entity.HasKey(e => e.IntTreatmentSetId)
                    .HasName("PK__tblTreat__4C2B8C6B5B0EC7FC");

                entity.ToTable("tblTreatmentSet");

                entity.Property(e => e.IntTreatmentSetId).HasColumnName("intTreatmentSetId");

                entity.Property(e => e.DatDateBegin)
                    .HasColumnName("datDateBegin")
                    .HasColumnType("date");

                entity.Property(e => e.DatDateEnd)
                    .HasColumnName("datDateEnd")
                    .HasColumnType("date");

                entity.Property(e => e.IntDoctorId).HasColumnName("intDoctorId");

                entity.Property(e => e.IntPatientId).HasColumnName("intPatientId");

                entity.Property(e => e.IntTreatmentSetCount).HasColumnName("intTreatmentSetCount");

                entity.Property(e => e.IntTreatmentSetCountFact).HasColumnName("intTreatmentSetCountFact");

                entity.Property(e => e.IntTreatmentTypeId).HasColumnName("intTreatmentTypeId");

                entity.Property(e => e.TxtTreatmentSetRoom)
                    .HasColumnName("txtTreatmentSetRoom")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.HasOne(d => d.IntDoctor)
                    .WithMany(p => p.TblTreatmentSet)
                    .HasForeignKey(d => d.IntDoctorId)
                    .HasConstraintName("FK__tblTreatm__intDo__4F7CD00D");

                entity.HasOne(d => d.IntPatient)
                    .WithMany(p => p.TblTreatmentSet)
                    .HasForeignKey(d => d.IntPatientId)
                    .HasConstraintName("FK__tblTreatm__intPa__5070F446");

                entity.HasOne(d => d.IntTreatmentType)
                    .WithMany(p => p.TblTreatmentSet)
                    .HasForeignKey(d => d.IntTreatmentTypeId)
                    .HasConstraintName("FK__tblTreatm__intTr__5165187F");
            });

            modelBuilder.Entity<TblTreatmentType>(entity =>
            {
                entity.HasKey(e => e.IntTreatmentTypeId)
                    .HasName("PK__tblTreat__F44BD2D1AA739A82");

                entity.ToTable("tblTreatmentType");

                entity.Property(e => e.IntTreatmentTypeId).HasColumnName("intTreatmentTypeId");

                entity.Property(e => e.FltTreatmentPrice)
                    .HasColumnName("fltTreatmentPrice")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TxtTreatmentTypeDescription)
                    .HasColumnName("txtTreatmentTypeDescription")
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.TxtTreatmentTypeName)
                    .HasColumnName("txtTreatmentTypeName")
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblTreatmentVisit>(entity =>
            {
                entity.HasKey(e => e.IntTreatmentVisitId)
                    .HasName("PK__tblTreat__9E9097F45E9C66BC");

                entity.ToTable("tblTreatmentVisit");

                entity.Property(e => e.IntTreatmentVisitId).HasColumnName("intTreatmentVisitId");

                entity.Property(e => e.DatTreatmentVisitDate)
                    .HasColumnName("datTreatmentVisitDate")
                    .HasColumnType("date");

                entity.Property(e => e.IntTreatmentSetId).HasColumnName("intTreatmentSetId");

                entity.HasOne(d => d.IntTreatmentSet)
                    .WithMany(p => p.TblTreatmentVisit)
                    .HasForeignKey(d => d.IntTreatmentSetId)
                    .HasConstraintName("FK__tblTreatm__intTr__5441852A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
