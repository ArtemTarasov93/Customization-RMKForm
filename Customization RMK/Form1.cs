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
using System.ServiceProcess;
using System.Data.OleDb;
using System.Security.Principal;
using System.Net;

namespace CustomizationRMKForm
{
    public partial class CustomizationRMKForm : Form
    {
        const string PatchFirmwareKey = @"\\office\service\LanDesk\Soft\Softnolandesk\KKM\firmware\upd_app_key.bin";
        const string NewPatchFirmwareKey = @"C:\Files\KKM\upd_app_key.bin";
        const string PatchFirmware = @"\\office\service\LanDesk\Soft\Softnolandesk\KKM\firmware\upd_app.bin";
        const string NewPatchFirmware = @"C:\Files\KKM\upd_app.bin";
        const string DirNewPatch = @"C:\Files\KKM";
        const string OfdKKTProfiles = @"\\office\service\LanDesk\Soft\Softnolandesk\KKM\ofd\KKTProfiles.ini";
        const string OfdSettings = @"\\office\service\LanDesk\Soft\Softnolandesk\KKM\ofd\Settings.ini";
        string SerialNumber;
        string Organization = "";
        string Adress = "";
        string IdPvz = "";
        string StrGuid = "";
        string OrganizationDB = "";
        const string PFile = @"C:\sc552\p";
        const string Shara = @"\\office\service\LanDesk\Soft\Softnolandesk\KKM";
        readonly OleDbConnection OleDbConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\office\service\LanDesk\Soft\Softnolandesk\KKM\DB\DatabaseKKM.mdb");
        readonly string ComputerName = Dns.GetHostName();
        public CustomizationRMKForm()
        {
            InitializeComponent();
            Driver = new DrvFR();
        }

        readonly DrvFR Driver;
        private void CustomizationRMKForm_Load(object sender, EventArgs e)
        {
            if (!IsRunAsAdmin())
            {
                StatickIP.Enabled = false;
                OfdConnect.Enabled = false;
                MakeSettings.Enabled = false;
                Regsvr.Enabled = false;
            }
        }
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
            PrintOut();
            Licence.Enabled = true;
            if (Driver.ECRBuild != 19018)
            {
                if (Driver.ECRMode == 4)
                {
                    if (Driver.ECRAdvancedMode == 0)
                    {
                        Firmware.Enabled = true;
                        FirmwareNotKey.Enabled = true;
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
        private void PrintOut() //Функция вывода информации
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
                    "\r\nАдрес: {8}", Driver.ECRBuild, Driver.ECRMode, Driver.ECRModeDescription, Driver.UDescription, SerialNumber, Driver.ECRAdvancedModeDescription, Driver.MessageCount, Organization, Adress);
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
            Frimware(PatchFirmwareKey, NewPatchFirmwareKey);
        }
        private void FirmwareNotKey_Click(object sender, EventArgs e) //Кнопка "Прошивка без ключей"
        {
            Frimware(PatchFirmware, NewPatchFirmware);
        }
        private void Frimware(string Patch, string NewPatch) //Функция прошивки
        {
            if (File.Exists(Patch))
            {
                if (Directory.Exists(DirNewPatch) == false)
                {
                    Directory.CreateDirectory(DirNewPatch);
                }
                File.Copy(Patch, NewPatch, true);
                Driver.UpdateFirmwareMethod = 0;
                Driver.FileName = NewPatch;
                Driver.UpdateFirmware();
                Firmware.Enabled = false;
                FirmwareNotKey.Enabled = false;
                UpdateFirmwareTimer.Start();
            }
            else
            {
                tbResult.Text = string.Format("{0}", "Проблема с доступом к файлу");
            }
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
            OleDbCommand SelectCommand = new OleDbCommand($"SELECT HEX, Digital_Sign FROM Licences WHERE (Fuctory_number = '{SerialNumber}')", OleDbConnection);
            UpdateFirmwareTimer.Stop();
            string LicenseHEX = "";
            string DigitalSignHEX = "";
            if (Directory.Exists(Shara))
            {
                OleDbConnection.Open();
                OleDbDataReader DataReader = SelectCommand.ExecuteReader();
                try
                {
                    while (DataReader.Read())
                    {
                        LicenseHEX = Convert.ToString(DataReader["HEX"]);
                        DigitalSignHEX = Convert.ToString(DataReader["Digital_Sign"]);
                    }
                }
                catch (Exception ex)
                {
                    tbResult.Text = string.Format("{0}: {1}", "Ошибка запроса", ex.Message);
                }
                finally
                {
                    if (DataReader != null && !DataReader.IsClosed)
                    {
                        DataReader.Close();
                    }
                    OleDbConnection.Close();
                }
                if (LicenseHEX != "" && DigitalSignHEX != "")
                {
                    Driver.License = LicenseHEX;
                    Driver.DigitalSign = DigitalSignHEX;
                    Driver.WriteFeatureLicenses();
                    UpdateResult();
                    if (Driver.ResultCode == 0)
                    {
                        tbResult.Text = string.Format("{0}", "Лицензия установлена на ККТ");
                    }
                    else
                    {
                        tbResult.Text = string.Format("{0}", "Ошибка лицензирования");
                    }
                }
                else
                {
                    tbResult.Text = string.Format("{0}", "Лицензии на ККМ не существует");
                }
            }
            else
            {
                tbResult.Text = string.Format("{0}", "Нет доступа к шаре");
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

        private void SettingConnection_Click(object sender, EventArgs e) // Кнопка "Настройка связи"
        {
            Process PCreate = new Process();
            PCreate.StartInfo.Arguments = "36";
            PCreate.StartInfo.FileName = @"C:\sc552\LoadParm.exe";
            PCreate.Start();
            Thread.Sleep(3000);
            for (int i = 0; i < 6; i++)
            {
                if (File.Exists(PFile))
                {
                    TerminalResult.Text = string.Format("{0}", "Связь установлена");
                    return;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
            if (File.Exists(PFile) == false)
            {
                string[] ports = SerialPort.GetPortNames();
                for (int i = 0; i < ports.Count(); i++)
                {
                    string PortNumbrer = ports[i].Replace("COM","");
                    string PinpadCom = "ComPort=" + PortNumbrer + "\r\nPrinterEnd=01\r\nSpeed=115200\r\nShowScreens=1\r\nNewProtocol=1";
                    File.WriteAllText(@"C:\sc552\pinpad.ini", PinpadCom);
                    PCreate.Start();
                    Thread.Sleep(3000);
                    for (int u = 0; u < 6; u++)
                    {
                        if (File.Exists(PFile))
                        {
                            TerminalResult.Text = string.Format("{0}", "Связь установлена");
                            return;
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
        }
        private void MakeSettings_Click(object sender, EventArgs e) //Кнопка "Внести настройки 1С"
        {
            if (Directory.Exists(Shara))
            {
                string OleBdSelect = $"SELECT Computers.Computer_name, " +
                    $"Computers.Id_Pvz, " +
                    $"Computers.[Guid], " +
                    $"Adress.Organization " +
                    $"FROM(Computers INNER JOIN Adress ON Computers.Id_Pvz = Adress.Id_Pvz) " +
                    $"WHERE(Computers.Computer_name = '{ComputerName}')";
                OleDbCommand SelectCommand = new OleDbCommand(OleBdSelect, OleDbConnection);
                OleDbConnection.Open();
                OleDbDataReader DataReader = SelectCommand.ExecuteReader();
                try
                {
                    while (DataReader.Read())
                    {
                        IdPvz = Convert.ToString(DataReader["Id_Pvz"]);
                        StrGuid = Convert.ToString(DataReader["Guid"]);
                        OrganizationDB = Convert.ToString(DataReader["Organization"]);
                    }
                }
                catch (Exception)
                {
                    tbResult.Text = string.Format("{0}", "Ошибка запроса");
                }
                finally
                {
                    if (DataReader != null && !DataReader.IsClosed)
                    {
                        DataReader.Close();
                    }
                    OleDbConnection.Close();
                }
                if (IdPvz != "" && StrGuid != "" && OrganizationDB != "")
                {
                    string[] Users = Directory.GetDirectories("C:\\Users\\");
                    string[] UsersArray = { @"C:\Users\All Users", @"C:\Users\Default", @"C:\Users\Default User", @"C:\Users\Public", @"C:\Users\Администратор", @"C:\Users\Administrator", @"C:\Users\AdminPickup", @"C:\Users\Все пользователи" };
                    Users = (from x in Users where !UsersArray.Contains(x) select x).ToArray();
                    string StringFileGuid =
                        "{\r\n" +
                        "{\"\"},\r\n" +
                        "{\r\n" +
                        "{\"Universal\",\r\n" +
                        "{\"ClientID\",\r\n" +
                        "{\"#\",fc01b5df-97fe-449b-83d4-218a090e681e," + StrGuid + "},\"\"},\r\n" +
                        "{\r\n" +
                        "{\"\"}\r\n" +
                        "}\r\n" +
                        "},\r\n" +
                        "{\"\"}\r\n" +
                        "}\r\n" +
                        "}";
                    for (int i = 0; i < Users.Count(); i++)
                    {
                        string UsersDirectoryGuid = Users[i] + @"\AppData\Local\1C\1cv8";
                        string UsersFileGuid = UsersDirectoryGuid + "\\1cv8u.pfl";
                        string UsersDirectory_1CEStart = Users[i] + @"\AppData\Roaming\1C\1CEStart";
                        string UsersFile_1CEStart = UsersDirectory_1CEStart + "\\ibases.v8i";
                        if (!Directory.Exists(UsersDirectoryGuid))
                        {
                            Directory.CreateDirectory(UsersDirectoryGuid);
                        }
                        if (!Directory.Exists(UsersDirectory_1CEStart))
                        {
                            Directory.CreateDirectory(UsersDirectory_1CEStart);
                        }
                        File.WriteAllText(UsersFileGuid, StringFileGuid);
                        switch (OrganizationDB)
                        {
                            case "kupishoes":
                                File.Copy(Shara + "\\kupishoes.v8i", UsersFile_1CEStart, true);
                                break;
                            case "puru":
                                File.Copy(Shara + "\\puru.v8i", UsersFile_1CEStart, true);
                                break;
                        }
                        tbResult.Text = string.Format("{0}", "Настройки внесены");
                    }
                }
                else
                {
                    tbResult.Text = string.Format("{0}", "Пвз или компьютер не найден в базе");
                }
            }
            else
            {
                tbResult.Text = string.Format("{0}", "Нет доступа к шаре");
            }
        }
        bool IsRunAsAdmin() //Функция проверки прав администратора
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}

