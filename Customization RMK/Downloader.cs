using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customization_RMK
{
    public partial class Downloader : Form
    {
        public Downloader()
        {
            InitializeComponent();
        }

        async private void Downloader_Load(object sender, EventArgs e)
        {
            string DrvFRDir = @"C:\Files";
            string DrvFRPatchShara = @"\\office\service\LanDesk\Soft\Softnolandesk\Тест драйвера ФР\DrvFR_4.14_803.exe";
            string DrvFRPatch = @"C:\Files\DrvFR_4.14_803.exe";
            if (!Directory.Exists(DrvFRDir))
            {
                Directory.CreateDirectory(DrvFRDir);
            }
            else
            {
                await Task.Run(() =>
                {

                    var from = new FileInfo(DrvFRPatchShara);
                    var to = new FileInfo(DrvFRPatch);

                    if (!to.Exists)
                        to.Create().Dispose();

                    using (var fromStream = from.OpenRead())
                    using (var toStream = to.OpenWrite())
                    {
                        byte[] buffer = new byte[16384];
                        int count;
                        long readed = 0;
                        long total = from.Length;

                        while ((count = fromStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            toStream.Write(buffer, 0, count);

                            readed += count;

                            int percent = Convert.ToInt32((readed * 100) / total);

                            BeginInvoke(new Action<int>(perc =>
                            {
                                progressBar1.Value = perc;
                            }), percent);
                        }
                    }
                });
                Process.Start(DrvFRPatch);
                Close();
            }            
        }
    }
}
