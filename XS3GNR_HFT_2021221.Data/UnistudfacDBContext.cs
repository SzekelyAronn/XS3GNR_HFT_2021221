using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Data
{
    public class UnistudfacDBContext : DbContext
    {
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        public UnistudfacDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\UniDb.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity
                .HasOne(student => student.Faculty)
                .WithMany(faculty => faculty.Students)
                .HasForeignKey(student => student.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity
                .HasOne(faculty => faculty.University)
                .WithMany(university => university.Faculties)
                .HasForeignKey(faculty => faculty.UniversityId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            University OE = new University() { Id = 1, Name = "Óbudai Egyetem", ShortName = "OE"};
            University BGE = new University() { Id = 2, Name = "Budapesti Gazdasági Egyetem", ShortName = "BGE"};
            University BME = new University() { Id = 3, Name = "Budapesti Műszaki és Gazdaságtudományi Egyetem", ShortName = "BME"};
            University ELTE = new University() { Id = 4, Name = "Eötvös Loránd Tudományegyetem", ShortName = "ELTE"};

            Faculty oe1 = new Faculty() { Id = 1, ShortName = "NIK", Name = "Neumann János Informatikai Kar", UniversityId = OE.Id, LocationbyDistrict = 3};
            Faculty oe2 = new Faculty() { Id = 2, ShortName = "KVK", Name = "Kandó Kálmán Villamosmérnöki Kar", UniversityId = OE.Id, LocationbyDistrict = 3 };
            Faculty bge1 = new Faculty() { Id = 3, ShortName = "KVIK", Name = "Kereskedelmi, Vendéglátóipari és Idegenforgalmi Kar", UniversityId = BGE.Id, LocationbyDistrict = 5 };
            Faculty bge2 = new Faculty() { Id = 4, ShortName = "PSZK", Name = "Pénzügyi és Számviteli Kar", UniversityId = BGE.Id, LocationbyDistrict = 14 };
            Faculty bme1 = new Faculty() { Id = 5, ShortName = "ÉPK", Name = "Építészmérnöki Kar", UniversityId = BME.Id, LocationbyDistrict = 11};
            Faculty bme2 = new Faculty() { Id = 6, ShortName = "KJK", Name = "Közlekedésmérnöki és Járműmérnöki Kar", UniversityId = BME.Id,LocationbyDistrict = 11};
            Faculty elte1 = new Faculty() { Id = 7, ShortName = "ÁJK", Name = "Állam- és Jogtudományi Kar", UniversityId = ELTE.Id, LocationbyDistrict = 5 };
            Faculty elte2 = new Faculty() { Id = 8, ShortName = "BTK", Name = "Bölcsészettudományi Kar", UniversityId = ELTE.Id, LocationbyDistrict = 8};

            Student stud1 = new Student() { Id = 1, Name = "Fehér Dominik", NeptunId = "GV2OA1", FacultyId = oe1.Id, BirthDate = new DateTime(2002,01,02) };
            Student stud2 = new Student() { Id = 2, Name = "Veres Árpád", NeptunId = "QAX0PS", FacultyId = oe1.Id ,BirthDate = new DateTime(1998,02,04) };
            Student stud3 = new Student() { Id = 3, Name = "Orsós Emese", NeptunId = "ATCH5I", FacultyId = oe2.Id, BirthDate = new DateTime(1990,04,12) };
            Student stud4 = new Student() { Id = 4, Name = "Szabó Albert", NeptunId = "D3R6UK", FacultyId = oe2.Id, BirthDate = new DateTime(2000,06,17) };
            Student stud5 = new Student() { Id = 5, Name = "Mészáros Fanni", NeptunId = "K7KJMR", FacultyId = bge1.Id, BirthDate = new DateTime(1999,08,13) };
            Student stud6 = new Student() { Id = 6, Name = "Vass Laura", NeptunId = "ABD7HW", FacultyId = bge1.Id, BirthDate = new DateTime(1996,10,18) };
            Student stud7 = new Student() { Id = 7, Name = "Szalai Zoltán", NeptunId = "B0IRV1", FacultyId = bge2.Id, BirthDate = new DateTime(1995,12,23) };
            Student stud8 = new Student() { Id = 8, Name = "Molnár Viktória", NeptunId = "QORE45", FacultyId = bge2.Id, BirthDate = new DateTime(1997,11,25) };
            Student stud9 = new Student() { Id = 9, Name = "Magyar András", NeptunId = "VB4KOV", FacultyId = bme1.Id, BirthDate = new DateTime(1998,07,20) };
            Student stud10= new Student() { Id = 10, Name = "Papp Attila", NeptunId = "H116BR", FacultyId = bme1.Id, BirthDate = new DateTime(1999,03,16) };
            Student stud11= new Student() { Id = 11, Name = "Fodor Sára", NeptunId = "WEDTH8", FacultyId = bme2.Id, BirthDate = new DateTime(2000,08,14) };
            Student stud12= new Student() { Id = 12, Name = "Illés Dóra", NeptunId = "PMCDB6", FacultyId = bme2.Id, BirthDate = new DateTime(2001,04,12) };
            Student stud13= new Student() { Id = 13, Name = "Nagy Viktor", NeptunId = "G05YV8", FacultyId = elte1.Id, BirthDate = new DateTime(2002,07,02) };
            Student stud14= new Student() { Id = 14, Name = "Szőke Tamás", NeptunId = "SW5XP8", FacultyId = elte1.Id, BirthDate = new DateTime(1993,06,09) };
            Student stud15= new Student() { Id = 15, Name = "Gál Nikoletta", NeptunId = "AK45OF", FacultyId = elte2.Id, BirthDate = new DateTime(1994,01,07) };
            Student stud16= new Student() { Id = 16, Name = "Kiss Lajos", NeptunId = "BKV7MO", FacultyId = elte2.Id, BirthDate = new DateTime(1997,12,09) };

            modelBuilder.Entity<University>().HasData(OE, BGE, BME, ELTE);
            modelBuilder.Entity<Faculty>().HasData(oe1, oe2, bge1, bge2, bme1, bme2, elte1, elte2);
            modelBuilder.Entity<Student>().HasData(stud1, stud2, stud3, stud4, stud5, stud6, stud7, stud8, stud9,
                stud10, stud11, stud12, stud13, stud14, stud15, stud16);

        }
    }
}
