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
            ((System.ComponentModel.ISupportInitialize)(this.numberCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRevision
            // 
            this.txtRevision.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevision.Location = new System.Drawing.Point(241, 72);
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(27, 27);
            this.txtRevision.TabIndex = 1;
            // 
            // lblReceiverNumber
            // 
            this.lblReceiverNumber.AutoSize = true;
            this.lblReceiverNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverNumber.Location = new System.Drawing.Point(18, 48);
            this.lblReceiverNumber.Name = "lblReceiverNumber";
            this.lblReceiverNumber.Size = new System.Drawing.Size(149, 21);
            this.lblReceiverNumber.TabIndex = 4;
            this.lblReceiverNumber.Text = "Receiver Number:";
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
            // txtReceiverNumber
            // 
            this.txtReceiverNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiverNumber.Location = new System.Drawing.Point(20, 72);
            this.txtReceiverNumber.Name = "txtReceiverNumber";
            this.txtReceiverNumber.Size = new System.Drawing.Size(145, 27);
            this.txtReceiverNumber.TabIndex = 0;
            this.txtReceiverNumber.TextChanged += new System.EventHandler(this.TxtReceiverNumber_TextChanged);
            // 
            // UCHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.numberCopies);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRevision);
            this.Controls.Add(this.lblReceiverNumber);
            this.Controls.Add(this.txtRevision);
            this.Controls.Add(this.txtReceiverNumber);
            this.Name = "UCHome";
            this.Size = new System.Drawing.Size(650, 150);
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
    }
}
