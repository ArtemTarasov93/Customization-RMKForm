namespace CustomizationRMKForm
{
    partial class CustomizationRMKForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CollectionData = new System.Windows.Forms.Button();
            this.PrintStringOut = new System.Windows.Forms.TextBox();
            this.ShowProperties = new System.Windows.Forms.Button();
            this.Firmware = new System.Windows.Forms.Button();
            this.Licence = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.KKMPage = new System.Windows.Forms.TabPage();
            this.ContinuePrint = new System.Windows.Forms.Button();
            this.RebootKKM = new System.Windows.Forms.Button();
            this.FirmwareNotKey = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.TerminalPage = new System.Windows.Forms.TabPage();
            this.SettingConnection = new System.Windows.Forms.Button();
            this.VerifyResults = new System.Windows.Forms.Button();
            this.TerminalResult = new System.Windows.Forms.TextBox();
            this.Regsvr = new System.Windows.Forms.Button();
            this.AdminPage = new System.Windows.Forms.TabPage();
            this.AdminResult = new System.Windows.Forms.TextBox();
            this.MakeSettings = new System.Windows.Forms.Button();
            this.OfdConnect = new System.Windows.Forms.Button();
            this.StatickIP = new System.Windows.Forms.Button();
            this.UpdateDrvFR = new System.Windows.Forms.Button();
            this.UpdateFirmwareTimer = new System.Windows.Forms.Timer(this.components);
            this.AdditionalParams = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.KKMPage.SuspendLayout();
            this.TerminalPage.SuspendLayout();
            this.AdminPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // CollectionData
            // 
            this.CollectionData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CollectionData.Location = new System.Drawing.Point(178, 6);
            this.CollectionData.Name = "CollectionData";
            this.CollectionData.Size = new System.Drawing.Size(149, 23);
            this.CollectionData.TabIndex = 1;
            this.CollectionData.Text = "Сбор данных";
            this.CollectionData.UseVisualStyleBackColor = true;
            this.CollectionData.Click += new System.EventHandler(this.CollectionData_Click);
            // 
            // PrintStringOut
            // 
            this.PrintStringOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintStringOut.Font = new System.Drawing.Font("Lucida Fax", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrintStringOut.Location = new System.Drawing.Point(5, 127);
            this.PrintStringOut.Multiline = true;
            this.PrintStringOut.Name = "PrintStringOut";
            this.PrintStringOut.Size = new System.Drawing.Size(322, 156);
            this.PrintStringOut.TabIndex = 6;
            // 
            // ShowProperties
            // 
            this.ShowProperties.BackColor = System.Drawing.Color.Transparent;
            this.ShowProperties.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ShowProperties.Location = new System.Drawing.Point(5, 6);
            this.ShowProperties.Name = "ShowProperties";
            this.ShowProperties.Size = new System.Drawing.Size(149, 23);
            this.ShowProperties.TabIndex = 0;
            this.ShowProperties.Text = "Свойства";
            this.ShowProperties.UseVisualStyleBackColor = false;
            this.ShowProperties.Click += new System.EventHandler(this.ShowProperties_Click);
            // 
            // Firmware
            // 
            this.Firmware.Enabled = false;
            this.Firmware.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Firmware.Location = new System.Drawing.Point(178, 35);
            this.Firmware.Name = "Firmware";
            this.Firmware.Size = new System.Drawing.Size(149, 23);
            this.Firmware.TabIndex = 5;
            this.Firmware.Text = "Прошивка с ключами";
            this.Firmware.UseVisualStyleBackColor = true;
            this.Firmware.Click += new System.EventHandler(this.Firmware_Click);
            // 
            // Licence
            // 
            this.Licence.Enabled = false;
            this.Licence.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Licence.Location = new System.Drawing.Point(5, 35);
            this.Licence.Name = "Licence";
            this.Licence.Size = new System.Drawing.Size(149, 23);
            this.Licence.TabIndex = 4;
            this.Licence.Text = "Установить лицензию";
            this.Licence.UseVisualStyleBackColor = true;
            this.Licence.Click += new System.EventHandler(this.Licence_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.KKMPage);
            this.TabControl.Controls.Add(this.TerminalPage);
            this.TabControl.Controls.Add(this.AdminPage);
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(343, 341);
            this.TabControl.TabIndex = 11;
            // 
            // KKMPage
            // 
            this.KKMPage.Controls.Add(this.AdditionalParams);
            this.KKMPage.Controls.Add(this.ContinuePrint);
            this.KKMPage.Controls.Add(this.RebootKKM);
            this.KKMPage.Controls.Add(this.FirmwareNotKey);
            this.KKMPage.Controls.Add(this.PrintStringOut);
            this.KKMPage.Controls.Add(this.ShowProperties);
            this.KKMPage.Controls.Add(this.tbResult);
            this.KKMPage.Controls.Add(this.CollectionData);
            this.KKMPage.Controls.Add(this.Firmware);
            this.KKMPage.Controls.Add(this.Licence);
            this.KKMPage.Location = new System.Drawing.Point(4, 22);
            this.KKMPage.Name = "KKMPage";
            this.KKMPage.Padding = new System.Windows.Forms.Padding(3);
            this.KKMPage.Size = new System.Drawing.Size(335, 315);
            this.KKMPage.TabIndex = 0;
            this.KKMPage.Text = "ККМ";
            this.KKMPage.UseVisualStyleBackColor = true;
            // 
            // ContinuePrint
            // 
            this.ContinuePrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ContinuePrint.Location = new System.Drawing.Point(5, 93);
            this.ContinuePrint.Name = "ContinuePrint";
            this.ContinuePrint.Size = new System.Drawing.Size(149, 23);
            this.ContinuePrint.TabIndex = 14;
            this.ContinuePrint.Text = "Продолжить печать";
            this.ContinuePrint.UseVisualStyleBackColor = true;
            this.ContinuePrint.Click += new System.EventHandler(this.ContinuePrint_Click);
            // 
            // RebootKKM
            // 
            this.RebootKKM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RebootKKM.Location = new System.Drawing.Point(5, 64);
            this.RebootKKM.Name = "RebootKKM";
            this.RebootKKM.Size = new System.Drawing.Size(149, 23);
            this.RebootKKM.TabIndex = 13;
            this.RebootKKM.Text = "Перезагрузить ККМ";
            this.RebootKKM.UseVisualStyleBackColor = true;
            this.RebootKKM.Click += new System.EventHandler(this.RebootKKM_Click);
            // 
            // FirmwareNotKey
            // 
            this.FirmwareNotKey.Enabled = false;
            this.FirmwareNotKey.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FirmwareNotKey.Location = new System.Drawing.Point(178, 64);
            this.FirmwareNotKey.Name = "FirmwareNotKey";
            this.FirmwareNotKey.Size = new System.Drawing.Size(149, 23);
            this.FirmwareNotKey.TabIndex = 12;
            this.FirmwareNotKey.Text = "Прошивка без ключей";
            this.FirmwareNotKey.UseVisualStyleBackColor = true;
            this.FirmwareNotKey.Click += new System.EventHandler(this.FirmwareNotKey_Click);
            // 
            // tbResult
            // 
            this.tbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResult.Location = new System.Drawing.Point(5, 289);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(322, 20);
            this.tbResult.TabIndex = 7;
            // 
            // TerminalPage
            // 
            this.TerminalPage.Controls.Add(this.SettingConnection);
            this.TerminalPage.Controls.Add(this.VerifyResults);
            this.TerminalPage.Controls.Add(this.TerminalResult);
            this.TerminalPage.Controls.Add(this.Regsvr);
            this.TerminalPage.Location = new System.Drawing.Point(4, 22);
            this.TerminalPage.Name = "TerminalPage";
            this.TerminalPage.Padding = new System.Windows.Forms.Padding(3);
            this.TerminalPage.Size = new System.Drawing.Size(335, 315);
            this.TerminalPage.TabIndex = 1;
            this.TerminalPage.Text = "Эквайринг";
            this.TerminalPage.UseVisualStyleBackColor = true;
            // 
            // SettingConnection
            // 
            this.SettingConnection.BackColor = System.Drawing.Color.Transparent;
            this.SettingConnection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SettingConnection.Location = new System.Drawing.Point(178, 35);
            this.SettingConnection.Name = "SettingConnection";
            this.SettingConnection.Size = new System.Drawing.Size(149, 23);
            this.SettingConnection.TabIndex = 18;
            this.SettingConnection.Text = "Настройка связи";
            this.SettingConnection.UseVisualStyleBackColor = false;
            this.SettingConnection.Click += new System.EventHandler(this.SettingConnection_Click);
            // 
            // VerifyResults
            // 
            this.VerifyResults.BackColor = System.Drawing.Color.Transparent;
            this.VerifyResults.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VerifyResults.Location = new System.Drawing.Point(178, 6);
            this.VerifyResults.Name = "VerifyResults";
            this.VerifyResults.Size = new System.Drawing.Size(149, 23);
            this.VerifyResults.TabIndex = 17;
            this.VerifyResults.Text = "Сверка итогов";
            this.VerifyResults.UseVisualStyleBackColor = false;
            this.VerifyResults.Click += new System.EventHandler(this.VerifyResults_Click);
            // 
            // TerminalResult
            // 
            this.TerminalResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TerminalResult.Location = new System.Drawing.Point(8, 288);
            this.TerminalResult.Multiline = true;
            this.TerminalResult.Name = "TerminalResult";
            this.TerminalResult.Size = new System.Drawing.Size(322, 20);
            this.TerminalResult.TabIndex = 16;
            // 
            // Regsvr
            // 
            this.Regsvr.BackColor = System.Drawing.Color.Transparent;
            this.Regsvr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Regsvr.Location = new System.Drawing.Point(5, 6);
            this.Regsvr.Name = "Regsvr";
            this.Regsvr.Size = new System.Drawing.Size(149, 23);
            this.Regsvr.TabIndex = 15;
            this.Regsvr.Text = "Регистрация библиотек";
            this.Regsvr.UseVisualStyleBackColor = false;
            this.Regsvr.Click += new System.EventHandler(this.Regsvr_Click);
            // 
            // AdminPage
            // 
            this.AdminPage.Controls.Add(this.AdminResult);
            this.AdminPage.Controls.Add(this.MakeSettings);
            this.AdminPage.Controls.Add(this.OfdConnect);
            this.AdminPage.Controls.Add(this.StatickIP);
            this.AdminPage.Controls.Add(this.UpdateDrvFR);
            this.AdminPage.Location = new System.Drawing.Point(4, 22);
            this.AdminPage.Name = "AdminPage";
            this.AdminPage.Size = new System.Drawing.Size(335, 315);
            this.AdminPage.TabIndex = 2;
            this.AdminPage.Text = "Админ";
            this.AdminPage.UseVisualStyleBackColor = true;
            // 
            // AdminResult
            // 
            this.AdminResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminResult.Location = new System.Drawing.Point(5, 289);
            this.AdminResult.Name = "AdminResult";
            this.AdminResult.Size = new System.Drawing.Size(322, 20);
            this.AdminResult.TabIndex = 21;
            this.AdminResult.Text = "Здарова отец!";
            // 
            // MakeSettings
            // 
            this.MakeSettings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MakeSettings.Location = new System.Drawing.Point(5, 6);
            this.MakeSettings.Name = "MakeSettings";
            this.MakeSettings.Size = new System.Drawing.Size(149, 23);
            this.MakeSettings.TabIndex = 20;
            this.MakeSettings.Text = "Внести настройки 1С";
            this.MakeSettings.UseVisualStyleBackColor = true;
            this.MakeSettings.Click += new System.EventHandler(this.MakeSettings_Click);
            // 
            // OfdConnect
            // 
            this.OfdConnect.BackColor = System.Drawing.Color.Transparent;
            this.OfdConnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OfdConnect.Location = new System.Drawing.Point(178, 6);
            this.OfdConnect.Name = "OfdConnect";
            this.OfdConnect.Size = new System.Drawing.Size(149, 23);
            this.OfdConnect.TabIndex = 19;
            this.OfdConnect.Text = "Настрока связи с ОФД";
            this.OfdConnect.UseVisualStyleBackColor = false;
            this.OfdConnect.Click += new System.EventHandler(this.OfdConnect_Click);
            // 
            // StatickIP
            // 
            this.StatickIP.BackColor = System.Drawing.Color.Transparent;
            this.StatickIP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StatickIP.Location = new System.Drawing.Point(5, 35);
            this.StatickIP.Name = "StatickIP";
            this.StatickIP.Size = new System.Drawing.Size(149, 23);
            this.StatickIP.TabIndex = 18;
            this.StatickIP.Text = "Установить IP Адрес";
            this.StatickIP.UseVisualStyleBackColor = false;
            this.StatickIP.Click += new System.EventHandler(this.StatickIP_Click);
            // 
            // UpdateDrvFR
            // 
            this.UpdateDrvFR.BackColor = System.Drawing.Color.Transparent;
            this.UpdateDrvFR.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UpdateDrvFR.Location = new System.Drawing.Point(178, 35);
            this.UpdateDrvFR.Name = "UpdateDrvFR";
            this.UpdateDrvFR.Size = new System.Drawing.Size(149, 23);
            this.UpdateDrvFR.TabIndex = 17;
            this.UpdateDrvFR.Text = "Обновить драйвер";
            this.UpdateDrvFR.UseVisualStyleBackColor = false;
            this.UpdateDrvFR.Click += new System.EventHandler(this.UpdateDrvFR_Click);
            // 
            // UpdateFirmwareTimer
            // 
            this.UpdateFirmwareTimer.Interval = 200;
            this.UpdateFirmwareTimer.Tick += new System.EventHandler(this.UpdateFirmwareTimer_Tick);
            // 
            // AdditionalParams
            // 
            this.AdditionalParams.BackColor = System.Drawing.Color.Transparent;
            this.AdditionalParams.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AdditionalParams.Location = new System.Drawing.Point(178, 93);
            this.AdditionalParams.Name = "AdditionalParams";
            this.AdditionalParams.Size = new System.Drawing.Size(149, 23);
            this.AdditionalParams.TabIndex = 15;
            this.AdditionalParams.Text = "Доп. параметры";
            this.AdditionalParams.UseVisualStyleBackColor = false;
            this.AdditionalParams.Click += new System.EventHandler(this.AdditionalParams_Click);
            // 
            // CustomizationRMKForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 340);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CustomizationRMKForm";
            this.Text = "Настройка РМК";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CustomizationRMKForm_Load);
            this.TabControl.ResumeLayout(false);
            this.KKMPage.ResumeLayout(false);
            this.KKMPage.PerformLayout();
            this.TerminalPage.ResumeLayout(false);
            this.TerminalPage.PerformLayout();
            this.AdminPage.ResumeLayout(false);
            this.AdminPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CollectionData;
        private System.Windows.Forms.TextBox PrintStringOut;
        private System.Windows.Forms.Button ShowProperties;
        private System.Windows.Forms.Button Firmware;
        private System.Windows.Forms.Button Licence;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage KKMPage;
        private System.Windows.Forms.TabPage TerminalPage;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Timer UpdateFirmwareTimer;
        private System.Windows.Forms.Button FirmwareNotKey;
        private System.Windows.Forms.TextBox TerminalResult;
        private System.Windows.Forms.Button Regsvr;
        private System.Windows.Forms.Button VerifyResults;
        private System.Windows.Forms.Button SettingConnection;
        private System.Windows.Forms.TabPage AdminPage;
        private System.Windows.Forms.TextBox AdminResult;
        private System.Windows.Forms.Button MakeSettings;
        private System.Windows.Forms.Button OfdConnect;
        private System.Windows.Forms.Button StatickIP;
        private System.Windows.Forms.Button UpdateDrvFR;
        private System.Windows.Forms.Button RebootKKM;
        private System.Windows.Forms.Button ContinuePrint;
        private System.Windows.Forms.Button AdditionalParams;
    }
}

