namespace GreenLabel
{
    partial class UCHome
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
            this.txtRevision = new System.Windows.Forms.TextBox();
            this.lblReceiverNumber = new System.Windows.Forms.Label();
            this.lblRevision = new System.Windows.Forms.Label();
            this.numberCopies = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtReceiverNumber = new System.Windows.Forms.TextBox();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.lblPO = new System.Windows.Forms.Label();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.lblPartNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numberCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRevision
            // 
            this.txtRevision.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevision.Location = new System.Drawing.Point(241, 42);
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(27, 27);
            this.txtRevision.TabIndex = 1;
            this.txtRevision.Text = "A";
            this.txtRevision.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRevision_KeyDown);
            // 
            // lblReceiverNumber
            // 
            this.lblReceiverNumber.AutoSize = true;
            this.lblReceiverNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverNumber.Location = new System.Drawing.Point(18, 18);
            this.lblReceiverNumber.Name = "lblReceiverNumber";
            this.lblReceiverNumber.Size = new System.Drawing.Size(149, 21);
            this.lblReceiverNumber.TabIndex = 4;
            this.lblReceiverNumber.Text = "Receiver Number:";
            // 
            // lblRevision
            // 
            this.lblRevision.AutoSize = true;
            this.lblRevision.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevision.Location = new System.Drawing.Point(215, 18);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(76, 21);
            this.lblRevision.TabIndex = 5;
            this.lblRevision.Text = "Revision:";
            // 
            // numberCopies
            // 
            this.numberCopies.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberCopies.Location = new System.Drawing.Point(388, 43);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(339, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Num. of Copies:";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(557, 82);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 28);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // txtReceiverNumber
            // 
            this.txtReceiverNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiverNumber.Location = new System.Drawing.Point(20, 42);
            this.txtReceiverNumber.Name = "txtReceiverNumber";
            this.txtReceiverNumber.Size = new System.Drawing.Size(145, 27);
            this.txtReceiverNumber.TabIndex = 0;
            this.txtReceiverNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtReceiverNumber_KeyDown);
            this.txtReceiverNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtReceiverNumber_KeyUp);
            // 
            // txtPO
            // 
            this.txtPO.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPO.Location = new System.Drawing.Point(241, 106);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(145, 27);
            this.txtPO.TabIndex = 4;
            this.txtPO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPO_KeyDown);
            // 
            // lblPO
            // 
            this.lblPO.AutoSize = true;
            this.lblPO.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPO.Location = new System.Drawing.Point(237, 82);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(49, 21);
            this.lblPO.TabIndex = 4;
            this.lblPO.Text = "PO#:";
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartNumber.Location = new System.Drawing.Point(22, 106);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(145, 27);
            this.txtPartNumber.TabIndex = 3;
            this.txtPartNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPartNumber_KeyDown);
            // 
            // lblPartNumber
            // 
            this.lblPartNumber.AutoSize = true;
            this.lblPartNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNumber.Location = new System.Drawing.Point(18, 82);
            this.lblPartNumber.Name = "lblPartNumber";
            this.lblPartNumber.Size = new System.Drawing.Size(35, 21);
            this.lblPartNumber.TabIndex = 4;
            this.lblPartNumber.Text = "PN:";
            // 
            // UCHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.numberCopies);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRevision);
            this.Controls.Add(this.lblPartNumber);
            this.Controls.Add(this.lblPO);
            this.Controls.Add(this.txtPartNumber);
            this.Controls.Add(this.lblReceiverNumber);
            this.Controls.Add(this.txtPO);
            this.Controls.Add(this.txtRevision);
            this.Controls.Add(this.txtReceiverNumber);
            this.Name = "UCHome";
            this.Size = new System.Drawing.Size(650, 150);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UCHome_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numberCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtRevision;
        private System.Windows.Forms.Label lblReceiverNumber;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.NumericUpDown numberCopies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtReceiverNumber;
        private System.Windows.Forms.TextBox txtPO;
        private System.Windows.Forms.Label lblPO;
        private System.Windows.Forms.TextBox txtPartNumber;
        private System.Windows.Forms.Label lblPartNumber;
    }
}
