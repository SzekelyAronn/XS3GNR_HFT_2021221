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

        public RestCollection<University> Universities { get; set; }

        private Student selectedStudent;

        private University selectedUni;

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
                        FacultyId = value.FacultyId,
                        NeptunId = value.NeptunId

                    };
                    OnPropertyChanged();
                    (deletestudent as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public University SelectedUni
        {
            get { return selectedUni; }

            set
            {
                if (value != null)
                {
                    selectedUni = new University()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        ShortName = value.ShortName,
                        Faculties = value.Faculties

                    };
                    OnPropertyChanged();
                    (deleteuniversity as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand createstudent { get; set; }

        public ICommand deletestudent { get; set; }

        public ICommand updatestudent { get; set; }


        public ICommand createuniversity { get; set; }

        public ICommand deleteuniversity { get; set; }

        public ICommand updateuniversity { get; set; }

        public MainWindowViewModel()
        {

            Students = new RestCollection<Student>("http://localhost:29075/", "student","hub");

            Universities = new RestCollection<University>("http://localhost:29075/", "university","hub");

            createstudent = new RelayCommand(() => 
            {
                Students.Add(new Student()
                {
                    Name = SelectedStudent.Name,
                    FacultyId = SelectedStudent.FacultyId,
                    NeptunId=SelectedStudent.NeptunId
                });
            });

            deletestudent = new RelayCommand(() =>
            {
                if (SelectedStudent != null)
                {
                    Students.Delete(SelectedStudent.Id);
                }

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


            createuniversity = new RelayCommand(() =>
            {
                if (SelectedUni != null)
                {
                    Universities.Add(new University()
                    {
                        Name = selectedUni.Name,
                        ShortName = selectedUni.ShortName
                    });
                }
            });

            deleteuniversity = new RelayCommand(() =>
            {
                if (SelectedUni != null)
                {
                    Universities.Delete(selectedUni.Id);
                }

            },
            () =>
            {
                return SelectedUni != null;
            });

            updateuniversity = new RelayCommand(() =>
            {
                Universities.Update(SelectedUni);
            });
            //SelectedStudent = new Student() { FacultyId = 1 };
        }

    }
}
