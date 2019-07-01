namespace GreenLabel
{
    partial class UCM2S
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
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.txtRevision = new System.Windows.Forms.TextBox();
            this.lblPartNumber = new System.Windows.Forms.Label();
            this.lblRevision = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numberCopies = new System.Windows.Forms.NumericUpDown();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numberCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartNumber.Location = new System.Drawing.Point(20, 72);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(145, 27);
            this.txtPartNumber.TabIndex = 0;
            this.txtPartNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPartNumber_KeyDown);
            // 
            // txtRevision
            // 
            this.txtRevision.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevision.Location = new System.Drawing.Point(241, 72);
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(27, 27);
            this.txtRevision.TabIndex = 1;
            this.txtRevision.Text = "A";
            this.txtRevision.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRevision_KeyDown);
            // 
            // lblPartNumber
            // 
            this.lblPartNumber.AutoSize = true;
            this.lblPartNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNumber.Location = new System.Drawing.Point(18, 48);
            this.lblPartNumber.Name = "lblPartNumber";
            this.lblPartNumber.Size = new System.Drawing.Size(113, 21);
            this.lblPartNumber.TabIndex = 4;
            this.lblPartNumber.Text = "Part Number:";
            // 
            // lblRevision
            // 
            this.lblRevision.AutoSize = true;
            this.lblRevision.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevision.Location = new System.Drawing.Point(215, 48);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(76, 21);
            this.lblRevision.TabIndex = 5;
            this.lblRevision.Text = "Revision:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(339, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Num. of Copies:";
            // 
            // numberCopies
            // 
            this.numberCopies.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberCopies.Location = new System.Drawing.Point(388, 73);
            this.numberCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberCopies.Name = "numberCopies";
            this.numberCopies.Size = new System.Drawing.Size(33, 27);
            this.numberCopies.TabIndex = 2;
            this.numberCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberCopies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumberCopies_KeyDown);
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
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // UCM2S
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblPartNumber);
            this.Controls.Add(this.numberCopies);
            this.Controls.Add(this.txtPartNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRevision);
            this.Controls.Add(this.lblRevision);
            this.Name = "UCM2S";
            this.Size = new System.Drawing.Size(650, 150);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UCM2S_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numberCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPartNumber;
        private System.Windows.Forms.TextBox txtRevision;
        private System.Windows.Forms.Label lblPartNumber;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numberCopies;
        private System.Windows.Forms.Button btnPrint;
    }
}
