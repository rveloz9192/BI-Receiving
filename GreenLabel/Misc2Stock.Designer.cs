namespace GreenLabel
{
    partial class Misc2Stock
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
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.lblPartNumber = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.numberCopies = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRevision = new System.Windows.Forms.TextBox();
            this.lblRevision = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numberCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Location = new System.Drawing.Point(12, 30);
            this.txtPartNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(124, 24);
            this.txtPartNumber.TabIndex = 0;
            // 
            // lblPartNumber
            // 
            this.lblPartNumber.AutoSize = true;
            this.lblPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPartNumber.Location = new System.Drawing.Point(9, 8);
            this.lblPartNumber.Name = "lblPartNumber";
            this.lblPartNumber.Size = new System.Drawing.Size(96, 18);
            this.lblPartNumber.TabIndex = 5;
            this.lblPartNumber.Text = "Part Number:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSubmit.FlatAppearance.BorderSize = 2;
            this.btnSubmit.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSubmit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSubmit.Location = new System.Drawing.Point(256, 31);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 26);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // numberCopies
            // 
            this.numberCopies.Location = new System.Drawing.Point(151, 61);
            this.numberCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberCopies.Name = "numberCopies";
            this.numberCopies.Size = new System.Drawing.Size(37, 24);
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
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of Copies:";
            // 
            // txtRevision
            // 
            this.txtRevision.Location = new System.Drawing.Point(151, 30);
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(37, 24);
            this.txtRevision.TabIndex = 1;
            // 
            // lblRevision
            // 
            this.lblRevision.AutoSize = true;
            this.lblRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblRevision.Location = new System.Drawing.Point(148, 9);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(69, 18);
            this.lblRevision.TabIndex = 6;
            this.lblRevision.Text = "Revision:";
            // 
            // Misc2Stock
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(343, 113);
            this.Controls.Add(this.lblRevision);
            this.Controls.Add(this.txtRevision);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberCopies);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblPartNumber);
            this.Controls.Add(this.txtPartNumber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Misc2Stock";
            this.Text = "Misc2Stock";
            ((System.ComponentModel.ISupportInitialize)(this.numberCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPartNumber;
        private System.Windows.Forms.Label lblPartNumber;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.NumericUpDown numberCopies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRevision;
        private System.Windows.Forms.Label lblRevision;
    }
}

