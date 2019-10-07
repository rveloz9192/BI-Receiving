namespace GreenLabel
{
    partial class UCISAP
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblPartNumber = new System.Windows.Forms.Label();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.lblPO = new System.Windows.Forms.Label();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.numberCopies = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dateDateReceived = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numberCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(556, 72);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 28);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // lblPartNumber
            // 
            this.lblPartNumber.AutoSize = true;
            this.lblPartNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNumber.Location = new System.Drawing.Point(18, 18);
            this.lblPartNumber.Name = "lblPartNumber";
            this.lblPartNumber.Size = new System.Drawing.Size(113, 21);
            this.lblPartNumber.TabIndex = 6;
            this.lblPartNumber.Text = "Part Number:";
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartNumber.Location = new System.Drawing.Point(20, 42);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(145, 27);
            this.txtPartNumber.TabIndex = 5;
            this.txtPartNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPartNumber_KeyDown);
            // 
            // lblPO
            // 
            this.lblPO.AutoSize = true;
            this.lblPO.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPO.Location = new System.Drawing.Point(232, 19);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(49, 21);
            this.lblPO.TabIndex = 8;
            this.lblPO.Text = "PO#:";
            // 
            // txtPO
            // 
            this.txtPO.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPO.Location = new System.Drawing.Point(236, 43);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(145, 27);
            this.txtPO.TabIndex = 7;
            this.txtPO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPO_KeyDown);
            // 
            // numberCopies
            // 
            this.numberCopies.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberCopies.Location = new System.Drawing.Point(452, 43);
            this.numberCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberCopies.Name = "numberCopies";
            this.numberCopies.Size = new System.Drawing.Size(33, 27);
            this.numberCopies.TabIndex = 9;
            this.numberCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberCopies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumberCopies_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(403, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Num. of Copies:";
            // 
            // dateDateReceived
            // 
            this.dateDateReceived.CalendarFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDateReceived.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDateReceived.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateReceived.Location = new System.Drawing.Point(20, 94);
            this.dateDateReceived.Name = "dateDateReceived";
            this.dateDateReceived.Size = new System.Drawing.Size(145, 27);
            this.dateDateReceived.TabIndex = 11;
            // 
            // UCISAP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dateDateReceived);
            this.Controls.Add(this.numberCopies);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPO);
            this.Controls.Add(this.txtPO);
            this.Controls.Add(this.lblPartNumber);
            this.Controls.Add(this.txtPartNumber);
            this.Controls.Add(this.btnPrint);
            this.Name = "UCISAP";
            this.Size = new System.Drawing.Size(650, 150);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPartNumber_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numberCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblPartNumber;
        private System.Windows.Forms.TextBox txtPartNumber;
        private System.Windows.Forms.Label lblPO;
        private System.Windows.Forms.TextBox txtPO;
        private System.Windows.Forms.NumericUpDown numberCopies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateDateReceived;
    }
}
