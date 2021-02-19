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
            this.FirmwareKey = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.TerminalPage = new System.Windows.Forms.TabPage();
            this.UpdateFirmwareTimer = new System.Windows.Forms.Timer(this.components);
            this.TerminalUpdate = new System.Windows.Forms.Timer(this.components);
            this.OfdConnect = new System.Windows.Forms.Button();
            this.StatickIP = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.KKMPage.SuspendLayout();
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
            this.PrintStringOut.Size = new System.Drawing.Size(322, 141);
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
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(343, 326);
            this.TabControl.TabIndex = 11;
            // 
            // KKMPage
            // 
            this.KKMPage.Controls.Add(this.StatickIP);
            this.KKMPage.Controls.Add(this.OfdConnect);
            this.KKMPage.Controls.Add(this.FirmwareKey);
            this.KKMPage.Controls.Add(this.PrintStringOut);
            this.KKMPage.Controls.Add(this.ShowProperties);
            this.KKMPage.Controls.Add(this.tbResult);
            this.KKMPage.Controls.Add(this.CollectionData);
            this.KKMPage.Controls.Add(this.Firmware);
            this.KKMPage.Controls.Add(this.Licence);
            this.KKMPage.Location = new System.Drawing.Point(4, 22);
            this.KKMPage.Name = "KKMPage";
            this.KKMPage.Padding = new System.Windows.Forms.Padding(3);
            this.KKMPage.Size = new System.Drawing.Size(335, 300);
            this.KKMPage.TabIndex = 0;
            this.KKMPage.Text = "ККМ";
            this.KKMPage.UseVisualStyleBackColor = true;
            // 
            // FirmwareKey
            // 
            this.FirmwareKey.Enabled = false;
            this.FirmwareKey.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FirmwareKey.Location = new System.Drawing.Point(178, 64);
            this.FirmwareKey.Name = "FirmwareKey";
            this.FirmwareKey.Size = new System.Drawing.Size(149, 23);
            this.FirmwareKey.TabIndex = 12;
            this.FirmwareKey.Text = "Прошивка без ключей";
            this.FirmwareKey.UseVisualStyleBackColor = true;
            this.FirmwareKey.Click += new System.EventHandler(this.FirmwareKey_Click);
            // 
            // tbResult
            // 
            this.tbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResult.Location = new System.Drawing.Point(5, 274);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(322, 20);
            this.tbResult.TabIndex = 7;
            // 
            // TerminalPage
            // 
            this.TerminalPage.Location = new System.Drawing.Point(4, 22);
            this.TerminalPage.Name = "TerminalPage";
            this.TerminalPage.Padding = new System.Windows.Forms.Padding(3);
            this.TerminalPage.Size = new System.Drawing.Size(335, 300);
            this.TerminalPage.TabIndex = 1;
            this.TerminalPage.Text = "Эквайринг";
            this.TerminalPage.UseVisualStyleBackColor = true;
            // 
            // UpdateFirmwareTimer
            // 
            this.UpdateFirmwareTimer.Interval = 200;
            this.UpdateFirmwareTimer.Tick += new System.EventHandler(this.UpdateFirmwareTimer_Tick);
            // 
            // OfdConnect
            // 
            this.OfdConnect.BackColor = System.Drawing.Color.Transparent;
            this.OfdConnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OfdConnect.Location = new System.Drawing.Point(178, 93);
            this.OfdConnect.Name = "OfdConnect";
            this.OfdConnect.Size = new System.Drawing.Size(149, 23);
            this.OfdConnect.TabIndex = 13;
            this.OfdConnect.Text = "Настрока связи с ОФД";
            this.OfdConnect.UseVisualStyleBackColor = false;
            this.OfdConnect.Click += new System.EventHandler(this.OfdConnect_Click);
            // 
            // StatickIP
            // 
            this.StatickIP.BackColor = System.Drawing.Color.Transparent;
            this.StatickIP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StatickIP.Location = new System.Drawing.Point(5, 93);
            this.StatickIP.Name = "StatickIP";
            this.StatickIP.Size = new System.Drawing.Size(149, 23);
            this.StatickIP.TabIndex = 14;
            this.StatickIP.Text = "Установить IP Адрес";
            this.StatickIP.UseVisualStyleBackColor = false;
            this.StatickIP.Click += new System.EventHandler(this.StatickIP_Click);
            // 
            // CustomizationRMKForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 332);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CustomizationRMKForm";
            this.Text = "Настройка РМК";
            this.TopMost = true;
            this.TabControl.ResumeLayout(false);
            this.KKMPage.ResumeLayout(false);
            this.KKMPage.PerformLayout();
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
        private System.Windows.Forms.Timer TerminalUpdate;
        private System.Windows.Forms.Button FirmwareKey;
        private System.Windows.Forms.Button OfdConnect;
        private System.Windows.Forms.Button StatickIP;
    }
}

