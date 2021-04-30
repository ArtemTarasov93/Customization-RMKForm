using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace UpdateCustomizationRMK
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists("C:\\Files"))
            {
                Directory.CreateDirectory("C:\\Files");
            }
            Thread.Sleep(2000);
            File.Copy(@"\\office.lamoda.ru\service\LanDesk\Soft\Softnolandesk\KKM\Настройка РМК.exe", @"C:\Files\Настройка РМК.exe", true);
            Process.Start(@"C:\Files\Настройка РМК.exe");
        }
    }
}
