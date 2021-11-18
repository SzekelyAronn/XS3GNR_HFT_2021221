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
                .HasForeignKey(faculty => faculty.UniId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            University OE = new University() { Id = 1, Name = "Óbudai Egyetem", ShortName = "OE"};
            University BGE = new University() { Id = 2, Name = "Budapesti Gazdasági Egyetem", ShortName = "BGE"};
            University BME = new University() { Id = 3, Name = "Budapesti Műszaki és Gazdaságtudományi Egyetem", ShortName = "BME"};
            University ELTE = new University() { Id = 4, Name = "Eötvös Loránd Tudományegyetem", ShortName = "ELTE"};

            Faculty oe1 = new Faculty() { Id = 1, ShortName = "NIK", Name = "Neumann János Informatikai Kar", UniId = OE.Id};
            Faculty oe2 = new Faculty() { Id = 2, ShortName = "KVK", Name = "Kandó Kálmán Villamosmérnöki Kar", UniId = OE.Id };
            Faculty bge1 = new Faculty() { Id = 3, ShortName = "KVIK", Name = "Kereskedelmi, Vendéglátóipari és Idegenforgalmi Kar", UniId = BGE.Id };
            Faculty bge2 = new Faculty() { Id = 4, ShortName = "PSZK", Name = "Pénzügyi és Számviteli Kar", UniId = BGE.Id };
            Faculty bme1 = new Faculty() { Id = 5, ShortName = "ÉPK", Name = "Építészmérnöki Kar", UniId = BME.Id };
            Faculty bme2 = new Faculty() { Id = 6, ShortName = "KJK", Name = "Közlekedésmérnöki és Járműmérnöki Kar", UniId = BME.Id };
            Faculty elte1 = new Faculty() { Id = 7, ShortName = "ÁJK", Name = "Állam- és Jogtudományi Kar", UniId = ELTE.Id };
            Faculty elte2 = new Faculty() { Id = 8, ShortName = "BTK", Name = "Bölcsészettudományi Kar", UniId = ELTE.Id };

            Student stud1 = new Student() { Id = 1, Name = "Fehér Dominik", NeptunId = "GV2OA1", FacultyId = oe1.Id };
            Student stud2 = new Student() { Id = 2, Name = "Veres Árpád", NeptunId = "QAK0PS", FacultyId = oe1.Id };
            Student stud3 = new Student() { Id = 3, Name = "Orsós Emese", NeptunId = "ATCH5I", FacultyId = oe2.Id };
            Student stud4 = new Student() { Id = 4, Name = "Szabó Albert", NeptunId = "D3R6UK", FacultyId = oe2.Id };
            Student stud5 = new Student() { Id = 5, Name = "Mészáros Fanni", NeptunId = "K7KJMR", FacultyId = bge1.Id };
            Student stud6 = new Student() { Id = 6, Name = "Vass Laura", NeptunId = "ABD7HW", FacultyId = bge1.Id };
            Student stud7 = new Student() { Id = 7, Name = "Szalai Zoltán", NeptunId = "B0IRV1", FacultyId = bge2.Id };
            Student stud8 = new Student() { Id = 8, Name = "Molnár Viktória", NeptunId = "QORE45", FacultyId = bge2.Id };
            Student stud9 = new Student() { Id = 9, Name = "Magyar András", NeptunId = "VB4KOV", FacultyId = bme1.Id };
            Student stud10= new Student() { Id = 10, Name = "Papp Attila", NeptunId = "H116BR", FacultyId = bme1.Id };
            Student stud11= new Student() { Id = 11, Name = "Fodor Sára", NeptunId = "WEDTH8", FacultyId = bme2.Id };
            Student stud12= new Student() { Id = 12, Name = "Illés Dóra", NeptunId = "PMCDB6", FacultyId = bme2.Id };
            Student stud13= new Student() { Id = 13, Name = "Nagy Viktor", NeptunId = "G05YV8", FacultyId = elte1.Id};
            Student stud14= new Student() { Id = 14, Name = "Szőke Tamás", NeptunId = "SW5XP8", FacultyId = elte1.Id};
            Student stud15= new Student() { Id = 15, Name = "Gál Nikoletta", NeptunId = "AK45OF", FacultyId = elte2.Id};
            Student stud16= new Student() { Id = 16, Name = "Kiss Lajos", NeptunId = "BKV7MO", FacultyId = elte2.Id};

            modelBuilder.Entity<University>().HasData(OE, BGE, BME, ELTE);
            modelBuilder.Entity<Faculty>().HasData(oe1, oe2, bge1, bge2, bme1, bme2, elte1, elte2);
            modelBuilder.Entity<Student>().HasData(stud1, stud2, stud3, stud4, stud5, stud6, stud7, stud8, stud9,
                stud10, stud11, stud12, stud13, stud14, stud15, stud16);

        }
    }
}
