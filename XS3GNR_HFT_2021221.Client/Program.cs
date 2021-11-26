using System;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:29075");
        }
    }
}
