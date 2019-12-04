namespace Engraver.TAD.ADM
{
    partial class HOME
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HOME));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnADM = new System.Windows.Forms.Button();
            this.btnTAD = new System.Windows.Forms.Button();
            this.lblCurrent4 = new System.Windows.Forms.Label();
            this.lblCurrent3 = new System.Windows.Forms.Label();
            this.lblCurrent2 = new System.Windows.Forms.Label();
            this.lblCurrent1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumTADs = new System.Windows.Forms.Label();
            this.numUnits = new System.Windows.Forms.NumericUpDown();
            this.lblReady = new System.Windows.Forms.Label();
            this.lblUnit3 = new System.Windows.Forms.Label();
            this.lblUnit4 = new System.Windows.Forms.Label();
            this.lblUnit2 = new System.Windows.Forms.Label();
            this.lblUnit1 = new System.Windows.Forms.Label();
            this.txtUnit4 = new System.Windows.Forms.TextBox();
            this.txtUnit3 = new System.Windows.Forms.TextBox();
            this.txtUnit2 = new System.Windows.Forms.TextBox();
            this.txtUnit1 = new System.Windows.Forms.TextBox();
            this.timerGetSettings = new System.Windows.Forms.Timer(this.components);
            this.timerReady = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pnlHeader.Controls.Add(this.btnMinimize);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(488, 50);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlHeader_MouseDown);
            this.pnlHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlHeader_MouseMove);
            this.pnlHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlHeader_MouseUp);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.Black;
            this.btnMinimize.Location = new System.Drawing.Point(426, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 28);
            this.btnMinimize.TabIndex = 10;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Text = "__";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(101)))), ((int)(((byte)(113)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(460, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 28);
            this.btnClose.TabIndex = 9;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.DimGray;
            this.lblHeader.Location = new System.Drawing.Point(112, 20);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(171, 30);
            this.lblHeader.TabIndex = 8;
            this.lblHeader.Text = "TAD Engraver";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlSide);
            this.panel1.Controls.Add(this.btnADM);
            this.panel1.Controls.Add(this.btnTAD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 350);
            this.panel1.TabIndex = 1;
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Margin = new System.Windows.Forms.Padding(5);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(10, 175);
            this.pnlSide.TabIndex = 7;
            // 
            // btnADM
            // 
            this.btnADM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnADM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(75)))));
            this.btnADM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnADM.FlatAppearance.BorderSize = 0;
            this.btnADM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnADM.ForeColor = System.Drawing.Color.White;
            this.btnADM.Location = new System.Drawing.Point(0, 175);
            this.btnADM.Margin = new System.Windows.Forms.Padding(5);
            this.btnADM.Name = "btnADM";
            this.btnADM.Size = new System.Drawing.Size(113, 175);
            this.btnADM.TabIndex = 6;
            this.btnADM.Text = "ADM";
            this.btnADM.UseVisualStyleBackColor = false;
            this.btnADM.Click += new System.EventHandler(this.BtnADM_Click);
            // 
            // btnTAD
            // 
            this.btnTAD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTAD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(75)))));
            this.btnTAD.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTAD.FlatAppearance.BorderSize = 0;
            this.btnTAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTAD.ForeColor = System.Drawing.Color.White;
            this.btnTAD.Location = new System.Drawing.Point(0, 0);
            this.btnTAD.Margin = new System.Windows.Forms.Padding(5);
            this.btnTAD.Name = "btnTAD";
            this.btnTAD.Size = new System.Drawing.Size(113, 175);
            this.btnTAD.TabIndex = 5;
            this.btnTAD.Text = "TAD";
            this.btnTAD.UseVisualStyleBackColor = false;
            this.btnTAD.Click += new System.EventHandler(this.BtnTAD_Click);
            // 
            // lblCurrent4
            // 
            this.lblCurrent4.AutoSize = true;
            this.lblCurrent4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.lblCurrent4.Location = new System.Drawing.Point(360, 291);
            this.lblCurrent4.Name = "lblCurrent4";
            this.lblCurrent4.Size = new System.Drawing.Size(0, 21);
            this.lblCurrent4.TabIndex = 49;
            // 
            // lblCurrent3
            // 
            this.lblCurrent3.AutoSize = true;
            this.lblCurrent3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.lblCurrent3.Location = new System.Drawing.Point(360, 233);
            this.lblCurrent3.Name = "lblCurrent3";
            this.lblCurrent3.Size = new System.Drawing.Size(0, 21);
            this.lblCurrent3.TabIndex = 48;
            // 
            // lblCurrent2
            // 
            this.lblCurrent2.AutoSize = true;
            this.lblCurrent2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.lblCurrent2.Location = new System.Drawing.Point(360, 175);
            this.lblCurrent2.Name = "lblCurrent2";
            this.lblCurrent2.Size = new System.Drawing.Size(0, 21);
            this.lblCurrent2.TabIndex = 47;
            // 
            // lblCurrent1
            // 
            this.lblCurrent1.AutoSize = true;
            this.lblCurrent1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.lblCurrent1.Location = new System.Drawing.Point(360, 117);
            this.lblCurrent1.Name = "lblCurrent1";
            this.lblCurrent1.Size = new System.Drawing.Size(85, 21);
            this.lblCurrent1.TabIndex = 46;
            this.lblCurrent1.Text = "Loading...";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(362, 344);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(83, 33);
            this.btnStart.TabIndex = 45;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 21);
            this.label1.TabIndex = 44;
            this.label1.Text = "Current Settings:";
            // 
            // lblNumTADs
            // 
            this.lblNumTADs.AutoSize = true;
            this.lblNumTADs.Location = new System.Drawing.Point(123, 60);
            this.lblNumTADs.Name = "lblNumTADs";
            this.lblNumTADs.Size = new System.Drawing.Size(137, 21);
            this.lblNumTADs.TabIndex = 43;
            this.lblNumTADs.Text = "Number of Units:";
            // 
            // numUnits
            // 
            this.numUnits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numUnits.Increment = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numUnits.Location = new System.Drawing.Point(261, 61);
            this.numUnits.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUnits.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUnits.Name = "numUnits";
            this.numUnits.Size = new System.Drawing.Size(30, 23);
            this.numUnits.TabIndex = 42;
            this.numUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUnits.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUnits.ValueChanged += new System.EventHandler(this.NumUnits_ValueChanged);
            // 
            // lblReady
            // 
            this.lblReady.AutoSize = true;
            this.lblReady.ForeColor = System.Drawing.Color.Red;
            this.lblReady.Location = new System.Drawing.Point(137, 347);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(0, 21);
            this.lblReady.TabIndex = 41;
            // 
            // lblUnit3
            // 
            this.lblUnit3.AutoSize = true;
            this.lblUnit3.Location = new System.Drawing.Point(125, 210);
            this.lblUnit3.Name = "lblUnit3";
            this.lblUnit3.Size = new System.Drawing.Size(64, 21);
            this.lblUnit3.TabIndex = 35;
            this.lblUnit3.Text = "TAD, 3:";
            // 
            // lblUnit4
            // 
            this.lblUnit4.AutoSize = true;
            this.lblUnit4.Location = new System.Drawing.Point(125, 268);
            this.lblUnit4.Name = "lblUnit4";
            this.lblUnit4.Size = new System.Drawing.Size(64, 21);
            this.lblUnit4.TabIndex = 36;
            this.lblUnit4.Text = "TAD, 4:";
            // 
            // lblUnit2
            // 
            this.lblUnit2.AutoSize = true;
            this.lblUnit2.Location = new System.Drawing.Point(125, 152);
            this.lblUnit2.Name = "lblUnit2";
            this.lblUnit2.Size = new System.Drawing.Size(64, 21);
            this.lblUnit2.TabIndex = 37;
            this.lblUnit2.Text = "TAD, 2:";
            // 
            // lblUnit1
            // 
            this.lblUnit1.AutoSize = true;
            this.lblUnit1.Location = new System.Drawing.Point(125, 94);
            this.lblUnit1.Name = "lblUnit1";
            this.lblUnit1.Size = new System.Drawing.Size(64, 21);
            this.lblUnit1.TabIndex = 38;
            this.lblUnit1.Text = "TAD, 1:";
            // 
            // txtUnit4
            // 
            this.txtUnit4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnit4.Location = new System.Drawing.Point(129, 294);
            this.txtUnit4.Margin = new System.Windows.Forms.Padding(5);
            this.txtUnit4.Name = "txtUnit4";
            this.txtUnit4.Size = new System.Drawing.Size(164, 20);
            this.txtUnit4.TabIndex = 40;
            this.txtUnit4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUnit4_KeyDown);
            // 
            // txtUnit3
            // 
            this.txtUnit3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnit3.Location = new System.Drawing.Point(129, 236);
            this.txtUnit3.Margin = new System.Windows.Forms.Padding(5);
            this.txtUnit3.Name = "txtUnit3";
            this.txtUnit3.Size = new System.Drawing.Size(164, 20);
            this.txtUnit3.TabIndex = 39;
            this.txtUnit3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUnit3_KeyDown);
            // 
            // txtUnit2
            // 
            this.txtUnit2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnit2.Location = new System.Drawing.Point(127, 178);
            this.txtUnit2.Margin = new System.Windows.Forms.Padding(5);
            this.txtUnit2.Name = "txtUnit2";
            this.txtUnit2.Size = new System.Drawing.Size(164, 20);
            this.txtUnit2.TabIndex = 34;
            this.txtUnit2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUnit2_KeyDown);
            // 
            // txtUnit1
            // 
            this.txtUnit1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnit1.Location = new System.Drawing.Point(127, 120);
            this.txtUnit1.Margin = new System.Windows.Forms.Padding(5);
            this.txtUnit1.Name = "txtUnit1";
            this.txtUnit1.Size = new System.Drawing.Size(164, 20);
            this.txtUnit1.TabIndex = 33;
            this.txtUnit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUnit1_KeyDown);
            // 
            // timerGetSettings
            // 
            this.timerGetSettings.Interval = 500;
            this.timerGetSettings.Tick += new System.EventHandler(this.TimerGetSettings_Tick);
            // 
            // timerReady
            // 
            this.timerReady.Interval = 500;
            this.timerReady.Tick += new System.EventHandler(this.TimerReady_Tick);
            // 
            // HOME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(488, 400);
            this.Controls.Add(this.lblCurrent4);
            this.Controls.Add(this.lblCurrent3);
            this.Controls.Add(this.lblCurrent2);
            this.Controls.Add(this.lblCurrent1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNumTADs);
            this.Controls.Add(this.numUnits);
            this.Controls.Add(this.lblReady);
            this.Controls.Add(this.lblUnit3);
            this.Controls.Add(this.lblUnit4);
            this.Controls.Add(this.lblUnit2);
            this.Controls.Add(this.lblUnit1);
            this.Controls.Add(this.txtUnit4);
            this.Controls.Add(this.txtUnit3);
            this.Controls.Add(this.txtUnit2);
            this.Controls.Add(this.txtUnit1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "HOME";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TADADM_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUnits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTAD;
        private System.Windows.Forms.Button btnADM;
        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Label lblCurrent4;
        private System.Windows.Forms.Label lblCurrent3;
        private System.Windows.Forms.Label lblCurrent2;
        private System.Windows.Forms.Label lblCurrent1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumTADs;
        private System.Windows.Forms.NumericUpDown numUnits;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Label lblUnit3;
        private System.Windows.Forms.Label lblUnit4;
        private System.Windows.Forms.Label lblUnit2;
        private System.Windows.Forms.Label lblUnit1;
        private System.Windows.Forms.TextBox txtUnit4;
        private System.Windows.Forms.TextBox txtUnit3;
        private System.Windows.Forms.TextBox txtUnit2;
        private System.Windows.Forms.TextBox txtUnit1;
        private System.Windows.Forms.Timer timerGetSettings;
        private System.Windows.Forms.Timer timerReady;
    }
}

