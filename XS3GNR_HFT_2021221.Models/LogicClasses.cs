using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XS3GNR_HFT_2021221.Models
{
    public class StudentResult
    {
        public string StudentName { get; set; }

        public string StudentNeptunId { get; set; }

        public string StudentsUni { get; set; }

        public string StudentFaculty { get; set; }

        public DateTime BirthDate { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is StudentResult)
            {
                var other = obj as StudentResult;
                return this.StudentName == other.StudentName && this.StudentNeptunId == other.StudentNeptunId
                    && this.StudentsUni == other.StudentsUni && this.StudentFaculty == other.StudentFaculty; 
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.StudentsUni.GetHashCode() + (int)this.StudentFaculty.Length;
        }

        public override string ToString()
        {
            return $"StudentName={StudentName}, StudentNeptunId={StudentNeptunId}, StudentsUni={StudentsUni}, StudentFaculty={StudentFaculty} ";
        }
    }

    public class EngineerUnis
    {
        public string UniversityName { get; set; }

        public string FacultyShortName { get; set; }

        public string FacultyName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is EngineerUnis)
            {
                var other = obj as EngineerUnis;
                return this.UniversityName == other.UniversityName && this.FacultyName == other.FacultyName
                    && this.FacultyShortName == other.FacultyShortName;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.UniversityName.GetHashCode() + (int)this.FacultyName.Length;
        }

        public override string ToString()
        {
            return $"UniversityName={UniversityName}, FacultyShortName={FacultyShortName}, FacultyName={FacultyName}";
        }


    }

    public class UnisbyDistrict
    {
        public string UniversityName { get; set; }

        public string FacultyName { get; set; }

        public int LocationbyDistrict { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is UnisbyDistrict)
            {
                var other = obj as UnisbyDistrict;
                return this.UniversityName == other.UniversityName && this.FacultyName == other.FacultyName
                    && this.LocationbyDistrict == other.LocationbyDistrict;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.UniversityName.GetHashCode() + (int)this.LocationbyDistrict;
        }

        public override string ToString()
        {
            return $"UniversityName={UniversityName}, Location by district={LocationbyDistrict}, FacultyName={FacultyName}";
        }


    }

    public class StudentsAverage
    {
        public string UniversityName { get; set; }

        public double AverageStudentAge { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is StudentsAverage)
            {
                var other = obj as StudentsAverage;
                return this.UniversityName == other.UniversityName && this.AverageStudentAge == other.AverageStudentAge;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.UniversityName.GetHashCode() + (int)this.AverageStudentAge;
        }

        public override string ToString()
        {
            return $"UniversityName={UniversityName}, Average student age ={AverageStudentAge}";
        }

    }
}
