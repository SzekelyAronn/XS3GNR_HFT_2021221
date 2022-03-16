using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.WPFClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Student> Students { get; set; }

        public MainWindowViewModel()
        {
            Students = new RestCollection<Student>("http://localhost:29075/", "student");
        }
    }
}
