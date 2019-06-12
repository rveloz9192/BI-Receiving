namespace BISync_Receiving
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.serialNumberTextBox = new System.Windows.Forms.TextBox();
            this.serialNumberLabel = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.sroGroupBox = new System.Windows.Forms.GroupBox();
            this.sroListBox = new System.Windows.Forms.ListBox();
            this.infoGroupBox = new System.Windows.Forms.GroupBox();
            this.reasonDataLabel = new System.Windows.Forms.Label();
            this.statusDataLabel = new System.Windows.Forms.Label();
            this.codeDataLabel = new System.Windows.Forms.Label();
            this.itemDataLabel = new System.Windows.Forms.Label();
            this.dateDataLabel = new System.Windows.Forms.Label();
            this.lineDataLabel = new System.Windows.Forms.Label();
            this.sroDataLabel = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.itemLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.lineLabel = new System.Windows.Forms.Label();
            this.sroLabel = new System.Windows.Forms.Label();
            this.debugGroupBox = new System.Windows.Forms.GroupBox();
            this.listOutput = new System.Windows.Forms.ListBox();
            this.manualCheckBox = new System.Windows.Forms.CheckBox();
            this.productLabel = new System.Windows.Forms.Label();
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.stationComboBox = new System.Windows.Forms.ComboBox();
            this.stationLabel = new System.Windows.Forms.Label();
            this.sroGroupBox.SuspendLayout();
            this.infoGroupBox.SuspendLayout();
            this.debugGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialNumberTextBox
            // 
            this.serialNumberTextBox.Enabled = false;
            this.serialNumberTextBox.Location = new System.Drawing.Point(13, 99);
            this.serialNumberTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(151, 26);
            this.serialNumberTextBox.TabIndex = 3;
            this.serialNumberTextBox.TextChanged += new System.EventHandler(this.SerialNumberTextBox_TextChanged);
            // 
            // serialNumberLabel
            // 
            this.serialNumberLabel.AutoSize = true;
            this.serialNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.serialNumberLabel.Location = new System.Drawing.Point(9, 74);
            this.serialNumberLabel.Name = "serialNumberLabel";
            this.serialNumberLabel.Size = new System.Drawing.Size(113, 20);
            this.serialNumberLabel.TabIndex = 7;
            this.serialNumberLabel.Text = "Serial Number:";
            // 
            // runButton
            // 
            this.runButton.Enabled = false;
            this.runButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.runButton.Location = new System.Drawing.Point(193, 99);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(105, 26);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Scan";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // sroGroupBox
            // 
            this.sroGroupBox.Controls.Add(this.sroListBox);
            this.sroGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sroGroupBox.Location = new System.Drawing.Point(13, 134);
            this.sroGroupBox.Name = "sroGroupBox";
            this.sroGroupBox.Size = new System.Drawing.Size(317, 91);
            this.sroGroupBox.TabIndex = 5;
            this.sroGroupBox.TabStop = false;
            this.sroGroupBox.Text = "SROs";
            // 
            // sroListBox
            // 
            this.sroListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sroListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.sroListBox.FormattingEnabled = true;
            this.sroListBox.ItemHeight = 20;
            this.sroListBox.Location = new System.Drawing.Point(3, 22);
            this.sroListBox.Name = "sroListBox";
            this.sroListBox.Size = new System.Drawing.Size(311, 66);
            this.sroListBox.TabIndex = 0;
            // 
            // infoGroupBox
            // 
            this.infoGroupBox.Controls.Add(this.reasonDataLabel);
            this.infoGroupBox.Controls.Add(this.statusDataLabel);
            this.infoGroupBox.Controls.Add(this.codeDataLabel);
            this.infoGroupBox.Controls.Add(this.itemDataLabel);
            this.infoGroupBox.Controls.Add(this.dateDataLabel);
            this.infoGroupBox.Controls.Add(this.lineDataLabel);
            this.infoGroupBox.Controls.Add(this.sroDataLabel);
            this.infoGroupBox.Controls.Add(this.notesTextBox);
            this.infoGroupBox.Controls.Add(this.reasonLabel);
            this.infoGroupBox.Controls.Add(this.statusLabel);
            this.infoGroupBox.Controls.Add(this.codeLabel);
            this.infoGroupBox.Controls.Add(this.itemLabel);
            this.infoGroupBox.Controls.Add(this.dateLabel);
            this.infoGroupBox.Controls.Add(this.lineLabel);
            this.infoGroupBox.Controls.Add(this.sroLabel);
            this.infoGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.infoGroupBox.Location = new System.Drawing.Point(13, 231);
            this.infoGroupBox.Name = "infoGroupBox";
            this.infoGroupBox.Size = new System.Drawing.Size(317, 359);
            this.infoGroupBox.TabIndex = 6;
            this.infoGroupBox.TabStop = false;
            this.infoGroupBox.Text = "Info";
            // 
            // reasonDataLabel
            // 
            this.reasonDataLabel.AutoSize = true;
            this.reasonDataLabel.Location = new System.Drawing.Point(78, 234);
            this.reasonDataLabel.Name = "reasonDataLabel";
            this.reasonDataLabel.Size = new System.Drawing.Size(0, 20);
            this.reasonDataLabel.TabIndex = 0;
            this.reasonDataLabel.Tag = "6";
            // 
            // statusDataLabel
            // 
            this.statusDataLabel.AutoSize = true;
            this.statusDataLabel.Location = new System.Drawing.Point(78, 200);
            this.statusDataLabel.Name = "statusDataLabel";
            this.statusDataLabel.Size = new System.Drawing.Size(0, 20);
            this.statusDataLabel.TabIndex = 1;
            this.statusDataLabel.Tag = "5";
            // 
            // codeDataLabel
            // 
            this.codeDataLabel.AutoSize = true;
            this.codeDataLabel.Location = new System.Drawing.Point(78, 166);
            this.codeDataLabel.Name = "codeDataLabel";
            this.codeDataLabel.Size = new System.Drawing.Size(0, 20);
            this.codeDataLabel.TabIndex = 2;
            this.codeDataLabel.Tag = "4";
            // 
            // itemDataLabel
            // 
            this.itemDataLabel.AutoSize = true;
            this.itemDataLabel.Location = new System.Drawing.Point(78, 30);
            this.itemDataLabel.Name = "itemDataLabel";
            this.itemDataLabel.Size = new System.Drawing.Size(0, 20);
            this.itemDataLabel.TabIndex = 3;
            this.itemDataLabel.Tag = "0";
            // 
            // dateDataLabel
            // 
            this.dateDataLabel.AutoSize = true;
            this.dateDataLabel.Location = new System.Drawing.Point(78, 132);
            this.dateDataLabel.Name = "dateDataLabel";
            this.dateDataLabel.Size = new System.Drawing.Size(0, 20);
            this.dateDataLabel.TabIndex = 4;
            this.dateDataLabel.Tag = "3";
            // 
            // lineDataLabel
            // 
            this.lineDataLabel.AutoSize = true;
            this.lineDataLabel.Location = new System.Drawing.Point(78, 98);
            this.lineDataLabel.Name = "lineDataLabel";
            this.lineDataLabel.Size = new System.Drawing.Size(0, 20);
            this.lineDataLabel.TabIndex = 5;
            this.lineDataLabel.Tag = "2";
            // 
            // sroDataLabel
            // 
            this.sroDataLabel.AutoSize = true;
            this.sroDataLabel.Location = new System.Drawing.Point(78, 64);
            this.sroDataLabel.Name = "sroDataLabel";
            this.sroDataLabel.Size = new System.Drawing.Size(0, 20);
            this.sroDataLabel.TabIndex = 6;
            this.sroDataLabel.Tag = "1";
            // 
            // notesTextBox
            // 
            this.notesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notesTextBox.Location = new System.Drawing.Point(6, 262);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ReadOnly = true;
            this.notesTextBox.Size = new System.Drawing.Size(305, 87);
            this.notesTextBox.TabIndex = 7;
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(12, 234);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(55, 20);
            this.reasonLabel.TabIndex = 8;
            this.reasonLabel.Tag = "";
            this.reasonLabel.Text = "Reas: ";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 200);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(47, 20);
            this.statusLabel.TabIndex = 9;
            this.statusLabel.Tag = "";
            this.statusLabel.Text = "Stat: ";
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(12, 166);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(55, 20);
            this.codeLabel.TabIndex = 10;
            this.codeLabel.Tag = "";
            this.codeLabel.Text = "Code: ";
            // 
            // itemLabel
            // 
            this.itemLabel.AutoSize = true;
            this.itemLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.itemLabel.Location = new System.Drawing.Point(12, 30);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(49, 20);
            this.itemLabel.TabIndex = 11;
            this.itemLabel.Tag = "";
            this.itemLabel.Text = "Item: ";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(12, 132);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(52, 20);
            this.dateLabel.TabIndex = 12;
            this.dateLabel.Tag = "";
            this.dateLabel.Text = "Date: ";
            // 
            // lineLabel
            // 
            this.lineLabel.AutoSize = true;
            this.lineLabel.Location = new System.Drawing.Point(12, 98);
            this.lineLabel.Name = "lineLabel";
            this.lineLabel.Size = new System.Drawing.Size(47, 20);
            this.lineLabel.TabIndex = 13;
            this.lineLabel.Tag = "";
            this.lineLabel.Text = "Line: ";
            // 
            // sroLabel
            // 
            this.sroLabel.AutoSize = true;
            this.sroLabel.Location = new System.Drawing.Point(12, 64);
            this.sroLabel.Name = "sroLabel";
            this.sroLabel.Size = new System.Drawing.Size(52, 20);
            this.sroLabel.TabIndex = 14;
            this.sroLabel.Tag = "";
            this.sroLabel.Text = "SRO: ";
            // 
            // debugGroupBox
            // 
            this.debugGroupBox.Controls.Add(this.listOutput);
            this.debugGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.debugGroupBox.Location = new System.Drawing.Point(362, 92);
            this.debugGroupBox.Name = "debugGroupBox";
            this.debugGroupBox.Size = new System.Drawing.Size(315, 498);
            this.debugGroupBox.TabIndex = 3;
            this.debugGroupBox.TabStop = false;
            this.debugGroupBox.Text = "Status";
            // 
            // listOutput
            // 
            this.listOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listOutput.FormattingEnabled = true;
            this.listOutput.ItemHeight = 20;
            this.listOutput.Location = new System.Drawing.Point(3, 22);
            this.listOutput.Name = "listOutput";
            this.listOutput.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listOutput.Size = new System.Drawing.Size(309, 473);
            this.listOutput.TabIndex = 0;
            // 
            // manualCheckBox
            // 
            this.manualCheckBox.AutoSize = true;
            this.manualCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.manualCheckBox.Location = new System.Drawing.Point(193, 77);
            this.manualCheckBox.Name = "manualCheckBox";
            this.manualCheckBox.Size = new System.Drawing.Size(108, 17);
            this.manualCheckBox.TabIndex = 2;
            this.manualCheckBox.Text = "Manual Selection";
            this.manualCheckBox.UseVisualStyleBackColor = true;
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.productLabel.Location = new System.Drawing.Point(9, 9);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(68, 20);
            this.productLabel.TabIndex = 2;
            this.productLabel.Text = "Product:";
            // 
            // productComboBox
            // 
            this.productComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Location = new System.Drawing.Point(13, 33);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(151, 28);
            this.productComboBox.TabIndex = 0;
            // 
            // stationComboBox
            // 
            this.stationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stationComboBox.FormattingEnabled = true;
            this.stationComboBox.Location = new System.Drawing.Point(193, 33);
            this.stationComboBox.Name = "stationComboBox";
            this.stationComboBox.Size = new System.Drawing.Size(137, 28);
            this.stationComboBox.TabIndex = 1;
            // 
            // stationLabel
            // 
            this.stationLabel.AutoSize = true;
            this.stationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.stationLabel.Location = new System.Drawing.Point(189, 9);
            this.stationLabel.Name = "stationLabel";
            this.stationLabel.Size = new System.Drawing.Size(64, 20);
            this.stationLabel.TabIndex = 0;
            this.stationLabel.Text = "Station:";
            // 
            // MainForm
            // 
            this.AcceptButton = this.runButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(343, 599);
            this.Controls.Add(this.stationLabel);
            this.Controls.Add(this.stationComboBox);
            this.Controls.Add(this.productComboBox);
            this.Controls.Add(this.productLabel);
            this.Controls.Add(this.manualCheckBox);
            this.Controls.Add(this.debugGroupBox);
            this.Controls.Add(this.infoGroupBox);
            this.Controls.Add(this.sroGroupBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.serialNumberLabel);
            this.Controls.Add(this.serialNumberTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Receiving";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.sroGroupBox.ResumeLayout(false);
            this.infoGroupBox.ResumeLayout(false);
            this.infoGroupBox.PerformLayout();
            this.debugGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serialNumberTextBox;
        private System.Windows.Forms.Label serialNumberLabel;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.GroupBox sroGroupBox;
        private System.Windows.Forms.ListBox sroListBox;
        private System.Windows.Forms.GroupBox infoGroupBox;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label lineLabel;
        private System.Windows.Forms.Label sroLabel;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Label reasonDataLabel;
        private System.Windows.Forms.Label statusDataLabel;
        private System.Windows.Forms.Label codeDataLabel;
        private System.Windows.Forms.Label itemDataLabel;
        private System.Windows.Forms.Label dateDataLabel;
        private System.Windows.Forms.Label lineDataLabel;
        private System.Windows.Forms.Label sroDataLabel;
        private System.Windows.Forms.GroupBox debugGroupBox;
        private System.Windows.Forms.ListBox listOutput;
        private System.Windows.Forms.CheckBox manualCheckBox;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.ComboBox stationComboBox;
        private System.Windows.Forms.Label stationLabel;
    }
}

