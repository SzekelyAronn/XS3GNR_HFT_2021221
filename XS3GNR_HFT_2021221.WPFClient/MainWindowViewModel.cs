using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Student> Students { get; set; }

        private Student selectedStudent;

        public Student SelectedStudent
        {
            get { return selectedStudent; }

            set 
            {
                if (value != null)
                {
                    selectedStudent = new Student()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        FacultyId = value.FacultyId

                    };
                    OnPropertyChanged();
                    (deletestudent as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand createstudent { get; set; }

        public ICommand deletestudent { get; set; }

        public ICommand updatestudent { get; set; }

        public MainWindowViewModel()
        {

            Students = new RestCollection<Student>("http://localhost:29075/", "student");

            createstudent = new RelayCommand(() => 
            {
                Students.Add(new Student()
                {
                    Name = SelectedStudent.Name,
                    FacultyId = SelectedStudent.FacultyId
                });
            });

            deletestudent = new RelayCommand(() =>
            {
                Students.Delete(SelectedStudent.Id);

            },
            () =>
            {
                return SelectedStudent != null;
            });

            updatestudent = new RelayCommand(()=>
            {
                Students.Update(SelectedStudent);
            });
            SelectedStudent = new Student() { FacultyId=1};
        }
    }
}
