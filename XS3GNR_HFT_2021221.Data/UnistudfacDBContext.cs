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
        public virtual DbSet<Faculties> Faculties { get; set; }
        public virtual DbSet<Students> Students { get; set; }

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
            modelBuilder.Entity<Students>(entity =>
            {
                entity
                .HasOne(student => student.Faculty)
                .WithMany(faculty => faculty.Students)
                .HasForeignKey(student => student.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Faculties>(entity =>
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

            Faculties oe1 = new Faculties() { Id = 1, ShortName = "NIK", Name = "Neumann János Informatikai Kar", UniId = OE.Id};
            Faculties oe2 = new Faculties() { Id = 2, ShortName = "KVK", Name = "Kandó Kálmán Villamosmérnöki Kar", UniId = OE.Id };
            Faculties bge1 = new Faculties() { Id = 3, ShortName = "KVIK", Name = "Kereskedelmi, Vendéglátóipari és Idegenforgalmi Kar", UniId = BGE.Id };
            Faculties bge2 = new Faculties() { Id = 4, ShortName = "PSZK", Name = "Pénzügyi és Számviteli Kar", UniId = BGE.Id };
            Faculties bme1 = new Faculties() { Id = 5, ShortName = "ÉPK", Name = "Építészmérnöki Kar", UniId = BME.Id };
            Faculties bme2 = new Faculties() { Id = 6, ShortName = "KJK", Name = "Közlekedésmérnöki és Járműmérnöki Kar", UniId = BME.Id };
            Faculties elte1 = new Faculties() { Id = 7, ShortName = "ÁJK", Name = "Állam- és Jogtudományi Kar", UniId = ELTE.Id };
            Faculties elte2 = new Faculties() { Id = 8, ShortName = "BTK", Name = "Bölcsészettudományi Kar", UniId = ELTE.Id };

            Students stud1 = new Students() { Name = "Fehér Dominik", NeptunId = "GV2OA1", FacultyId = oe1.Id };
            Students stud2 = new Students() { Name = "Veres Árpád", NeptunId = "QAK0PS", FacultyId = oe1.Id };
            Students stud3 = new Students() { Name = "Orsós Emese", NeptunId = "ATCH5I", FacultyId = oe2.Id };
            Students stud4 = new Students() { Name = "Szabó Albert", NeptunId = "D3R6UK", FacultyId = oe2.Id };
            Students stud5 = new Students() { Name = "Mészáros Fanni", NeptunId = "K7KJMR", FacultyId = bge1.Id };
            Students stud6 = new Students() { Name = "Vass Laura", NeptunId = "ABD7HW", FacultyId = bge1.Id };
            Students stud7 = new Students() { Name = "Szalai Zoltán", NeptunId = "B0IRV1", FacultyId = bge2.Id };
            Students stud8 = new Students() { Name = "Molnár Viktória", NeptunId = "QORE45", FacultyId = bge2.Id };
            Students stud9 = new Students() { Name = "Magyar András", NeptunId = "VB4KOV", FacultyId = bme1.Id };
            Students stud10= new Students() { Name = "Papp Attila", NeptunId = "H116BR", FacultyId = bme1.Id };
            Students stud11= new Students() { Name = "Fodor Sára", NeptunId = "WEDTH8", FacultyId = bme2.Id };
            Students stud12= new Students() { Name = "Illés Dóra", NeptunId = "PMCDB6", FacultyId = bme2.Id };
            Students stud13= new Students() { Name = "Nagy Viktor", NeptunId = "G05YV8", FacultyId = elte1.Id};
            Students stud14= new Students() { Name = "Szőke Tamás", NeptunId = "SW5XP8", FacultyId = elte1.Id};
            Students stud15= new Students() { Name = "Gál Nikoletta", NeptunId = "AK45OF", FacultyId = elte2.Id};
            Students stud16= new Students() { Name = "Kiss Lajos", NeptunId = "BKV7MO", FacultyId = elte2.Id};

            modelBuilder.Entity<University>().HasData(OE, BGE, BME, ELTE);
            modelBuilder.Entity<Faculties>().HasData(oe1, oe2, bge1, bge2, bme1, bme2, elte1, elte2);
            modelBuilder.Entity<Students>().HasData(stud1, stud2, stud3, stud4, stud5, stud6, stud7, stud8, stud9,
                stud10, stud11, stud12, stud13, stud14, stud15, stud16);

        }
    }
}
