using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using DrvFRLib;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.IO.Ports;
using System.Collections;
using System.ServiceProcess;
using System.Management;

namespace CustomizationRMKForm
{
    public partial class CustomizationRMKForm : Form
    {
        const string PatchFirmware = @"\\office\service\LanDesk\Soft\Softnolandesk\KKM\firmware\upd_app.bin";
        const string NewPatchFirmware = @"C:\Files\KKM\upd_app.bin";
        const string PatchFirmwareKey = @"\\office\service\LanDesk\Soft\Softnolandesk\KKM\firmware\upd_app_key.bin";
        const string NewPatchFirmwareKey = @"C:\Files\KKM\upd_app_key.bin";
        const string DirNewPatch = @"C:\Files\KKM";
        const string OfdKKTProfiles = @"\\office\service\LanDesk\Soft\Softnolandesk\KKM\ofd\KKTProfiles.ini";
        const string OfdSettings = @"\\office\service\LanDesk\Soft\Softnolandesk\KKM\ofd\Settings.ini";
        string SerialNumber;
        string Organization = "";
        string Adress = "";
        public CustomizationRMKForm()
        {
            InitializeComponent();
            Driver = new DrvFR();
        }

        readonly DrvFR Driver;

        //************************************************************KKT*******************************************************************

        private void UpdateResult() //Функция вывода информации о выполнении команды
        {
            tbResult.Text = string.Format("{0}, {1}", Driver.ResultCode, Driver.ResultCodeDescription);
        }
        
        private void ShowProperties_Click(object sender, EventArgs e) //Кнопка "Свойства"
        {
            UpdateFirmwareTimer.Stop();
            tbResult.Text = string.Format("{0}", "");
            ShowProperties.BackColor = Color.Transparent;
            Driver.ShowProperties();
        }
        private void CollectionData_Click(object sender, EventArgs e) // Кнопка "Сбор данных"
        {
            UpdateFirmwareTimer.Stop();
            Driver.ComputerName = "192.168.137.111";
            Driver.ProtocolType = 0;
            Driver.ConnectionType = 6;
            Driver.TCPPort = 7778;
            Driver.Timeout = 1000;
            Driver.IPAddress = "192.168.137.111";
            Driver.GetECRStatus();
            CollectionDataResult();
            Licence.Enabled = true;
            if (Driver.ECRBuild != 19018)
            {
                if (Driver.ECRMode == 4)
                {
                    if (Driver.ECRAdvancedMode == 0)
                    {
                        Firmware.Enabled = true;
                        FirmwareKey.Enabled = true;
                    }
                    else
                    {
                        tbResult.Text = string.Format("{0}", "Вставьте чековую ленту в ККМ");
                    }
                }
                else if (Driver.ECRMode == 0)
                {
                    ShowProperties.BackColor = Color.Lime;
                    Licence.Enabled = false;
                    tbResult.Text = string.Format("{0}", "Проверьте связь 'Зеленая кнопка'");
                }
                else
                {
                    tbResult.Text = string.Format("{0}", "Переведите кассу в режим 'Закрытая смена'");
                }
            }
            else
            {
                tbResult.Text = string.Format("{0}", "Установлена актуальная прошивка");
            }
        }
        private void CollectionDataResult() //Функция текстового описания режимов
        {
            switch (Driver.ECRMode)
            {
                case 0:
                    PrintOut("Принтер в рабочем режиме");
                    break;
                case 1:
                    PrintOut("Выдача данных");
                    break;
                case 2:
                    PrintOut("Открытая смена, 24 часа не кончились");
                    break;
                case 3:
                    PrintOut("Открытая смена, 24 часа кончились");
                    break;
                case 4:
                    PrintOut("Закрытая смена");
                    break;
                case 5:
                    PrintOut("Блокировка по неправильному паролю налогового инспектора");
                    break;
                case 6:
                    PrintOut("Ожидание подтверждения ввода даты");
                    break;
                case 7:
                    PrintOut("Разрешение изменения положения десятичной точки");
                    break;
                case 8:
                    PrintOut("Открытый документ");
                    break;
                case 9:
                    PrintOut("Режим разрешения технологического обнуления");
                    break;
                case 10:
                    PrintOut("Тестовый прогон");
                    break;
                case 11:
                    PrintOut("Печать полного фискального отчета");
                    break;
                case 12:
                    PrintOut("Печать длинного отчета ЭКЛЗ");
                    break;
                case 13:
                    PrintOut("Работа с фискальным подкладным документом");
                    break;
                case 14:
                    PrintOut("Печать подкладного документа");
                    break;
                case 15:
                    PrintOut("Фискальный подкладной документ сформирован");
                    break;
            }
        }
        private void PrintOut(string a) //Функция вывода информации
        {
            UpdateResult();
            if (Driver.ResultCode == 0)
            {
                Driver.ReadSerialNumber();
                SerialNumber = Driver.SerialNumber;
                Driver.FNGetInfoExchangeStatus();
                ReadTable();
                PrintStringOut.Text = string.Format(
                    "Сборка ПО: {0}" +
                    "\r\nРежим: {1}, {2}" +
                    "\r\nМодель: {3}" +
                    "\r\nЗН: {4}" +
                    "\r\nПодрежим: {5}" +
                    "\r\nЧеков не передано: {6}" +
                    "\r\nОрганизация: {7}" +
                    "\r\nАдрес: {8}", Driver.ECRBuild, Driver.ECRMode, a, Driver.UDescription, SerialNumber, Driver.ECRAdvancedModeDescription, Driver.MessageCount, Organization, Adress);
                Licence.Enabled = true;
            }
        }
        private void ReadTable() //Функция чтения таблиц
        {
            Driver.GetFieldStruct();
            Driver.TableNumber = 18;
            Driver.RowNumber = 1;
            Driver.FieldNumber = 7;
            Driver.ReadTable();
            Organization = Driver.ValueOfFieldString;
            Driver.TableNumber = 18;
            Driver.RowNumber = 1;
            Driver.FieldNumber = 9;
            Driver.ReadTable();
            Adress = Driver.ValueOfFieldString;
        }
        private void Firmware_Click(object sender, EventArgs e) //Кнопка "Прошивка с ключами"
        {
            Frimware(PatchFirmware, NewPatchFirmware);
        }
        private void FirmwareKey_Click(object sender, EventArgs e)
        {
            Frimware(PatchFirmwareKey, NewPatchFirmwareKey);
        }
        private void Frimware(string Patch, string NewPatch) //Функция прошивки
        {
            if (File.Exists(PatchFirmwareKey))
            {
                if (Directory.Exists(DirNewPatch))
                {
                    FirmwareUpdate(NewPatchFirmwareKey, "Файл скопирован. Идёт обновление прошивки", Patch, NewPatch);
                    UpdateFirmwareTimer.Start();
                }
                else
                {
                    Directory.CreateDirectory(DirNewPatch);
                    FirmwareUpdate(NewPatchFirmwareKey, "Папки созданы, файл скопирован. Идёт обновление прошивки", Patch, NewPatch);
                    UpdateFirmwareTimer.Start();
                }
            }
            else
            {
                tbResult.Text = string.Format("{0}", "Проблема с доступом к файлу");
            }
        }
        private void FirmwareUpdate(string b, string g, string p, string newp) //Функция обновления информации по прошивке
        {
            File.Copy(p, newp, true);
            tbResult.Text = string.Format("{0}", g);
            Driver.UpdateFirmwareMethod = 0;
            Driver.FileName = b;
            Driver.UpdateFirmware();
            Firmware.Enabled = false;
            FirmwareKey.Enabled = false;
        }
        private void UpdateFirmwareTimer_Tick(object sender, EventArgs e) //Таймер обновления информации по прошивке
        {
            tbResult.Text = string.Format("{0}", Driver.UpdateFirmwareStatusMessage);
            if (Driver.UpdateFirmwareStatus == 0)
            {
                UpdateFirmwareTimer.Stop();
            }
        }
        private void Licence_Click(object sender, EventArgs e) //Кнопка "Установить лицензию"
        {
            UpdateFirmwareTimer.Stop();
            string LicencesText = File.ReadAllText(@"\\office\service\LanDesk\Soft\Softnolandesk\KKM\Licenses\Licenses_All.slf"); //Читаем текст в файле
            string[] SolitLicencesText = LicencesText.Split('	', '\n'); //Делим текст на массив по разделителям
            int index = Array.IndexOf(SolitLicencesText, SerialNumber); //Сравниваем элементы массива с зоводским номером кассы
            string LicenseHEX = SolitLicencesText[index + 1]; //Следущее значение после зоводского номера в файле это НЕХ лицезии
            string DigitalSignHEX = SolitLicencesText[index + 2]; //Второе значение после заводского номера DigitalSign

            if (index > 0)
            {
                Driver.License = LicenseHEX;
                Driver.DigitalSign = DigitalSignHEX;
                Driver.WriteFeatureLicenses();
                UpdateResult();
                if (Driver.ResultCode == 0)
                {
                    tbResult.Text = string.Format("{0}", "Лицензия установлена на ККТ");
                }
            }
            else
            {
                tbResult.Text = string.Format("{0}", "Лицензии на ККМ не существует");
            }
        }

        private void OfdConnect_Click(object sender, EventArgs e) //Кнопка "Настрока связи с ОФД"
        {
            if (File.Exists(OfdKKTProfiles))
            {
                if (Directory.Exists(@"C:\Program Files (x86)\SHTRIH-M\DrvFR 4.14\Bin\OFDConnect") == false)
                {
                    tbResult.Text = string.Format("{0}", "Не установлен тест драйвера 4.14");
                    return;
                }
                if (Directory.Exists(DirNewPatch) == false)
                {
                    Directory.CreateDirectory(DirNewPatch);
                }
                try
                {
                    File.Copy(OfdKKTProfiles, @"C:\Program Files (x86)\SHTRIH-M\DrvFR 4.14\Bin\OFDConnect\KKTProfiles.ini", true);
                    File.Copy(OfdSettings, @"C:\Program Files (x86)\SHTRIH-M\DrvFR 4.14\Bin\OFDConnect\Settings.ini", true);
                }
                catch (Exception)
                {
                    tbResult.Text = string.Format("{0}", "Не достаточно прав доступа");
                    return;
                }
                try
                {
                    ServiceController Ofdconnect = new ServiceController("ofdconnect");
                    TimeSpan timeout = TimeSpan.FromMinutes(1);
                    if (Ofdconnect.Status != ServiceControllerStatus.Stopped)
                    {
                        Ofdconnect.Stop();
                        Ofdconnect.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    }
                    if (Ofdconnect.Status != ServiceControllerStatus.Running)
                    {
                        Ofdconnect.Start();
                        Ofdconnect.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    }
                    tbResult.Text = string.Format("{0}", "Служба перезапущена");
                }
                catch (Exception)
                {
                    tbResult.Text = string.Format("{0}", "Ошибка при перезапуске службы");
                    return;
                }
            }
            else
            {
                tbResult.Text = string.Format("{0}", "Нет доступа к шаре");
            }
        }
        private void StatickIP_Click(object sender, EventArgs e) // Кнопка "Установить IP Адрес"
        {
            Process StatickIP = new Process();
            StatickIP.StartInfo.Arguments = @"$var1 = Get-NetAdapter -interfaceDescription *'Remote NDIS based Internet Sharing Device'* | select -expand ifIndex" + 
                                    "\r\n" + "New-NetIPAddress -interfaceIndex $var1 -IPAddress 192.168.137.1 -PrefixLength 24";
            StatickIP.StartInfo.FileName = @"powershell";
            try
            {
                StatickIP.Start();
            }
            catch
            {
                tbResult.Text = string.Format("{0}", "Ошибка запуска скрипта PS");
            }
        }

        private void Regsvr_Click(object sender, EventArgs e) // Кнопка "Регистрация библиотек"
        {
            if (Directory.Exists(@"C:\sc552") == false)
            {
                TerminalResult.Text = string.Format("{0}", @"Нет папки C:\sc552");
                return;
            }
            if (File.Exists(@"C:\sc552\1C\3_par\SBRFCOM.dll"))
            {
                File.Copy(@"C:\sc552\1C\3_par\SBRFCOM.dll", @"C:\sc552\SBRFCOM.dll", true);
                Process RegsvrProcess = new Process();
                RegsvrProcess.StartInfo.Arguments = @"C:\sc552\SBRFCOM.dll";
                RegsvrProcess.StartInfo.FileName = @"Regsvr32";
                try
                {
                    RegsvrProcess.Start();
                }
                catch
                {
                    TerminalResult.Text = string.Format("{0}", "Ошибка регистрации библиотек");
                }
            }
            else
            {
                TerminalResult.Text = string.Format("{0}", "Нет библиотеки на 3 параметра в папке sc552");
            }
        }

        private void VerifyResults_Click(object sender, EventArgs e) // Кнопка "Сверка итогов"
        {
            Process VerifyResultsProcess = new Process();
            VerifyResultsProcess.StartInfo.Arguments = "7";
            VerifyResultsProcess.StartInfo.FileName = @"C:\sc552\LoadParm.exe";
            try
            {
                VerifyResultsProcess.Start();
            }
            catch
            {
                TerminalResult.Text = string.Format("{0}", "Ошибка запуска сверки итогов");
            }
        }
    }
}

