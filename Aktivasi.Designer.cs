namespace InstoTech_Colorimeter_1._0
{
    partial class Aktivasi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aktivasi));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txSerial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txActivation = new System.Windows.Forms.TextBox();
            this.tbCopy = new System.Windows.Forms.Button();
            this.tbAktivasi = new System.Windows.Forms.Button();
            this.txKata = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Activation Key";
            // 
            // txSerial
            // 
            this.txSerial.BackColor = System.Drawing.SystemColors.Control;
            this.txSerial.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txSerial.Location = new System.Drawing.Point(150, 19);
            this.txSerial.Name = "txSerial";
            this.txSerial.Size = new System.Drawing.Size(164, 27);
            this.txSerial.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(131, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = ":";
            // 
            // txActivation
            // 
            this.txActivation.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txActivation.Location = new System.Drawing.Point(150, 62);
            this.txActivation.Name = "txActivation";
            this.txActivation.Size = new System.Drawing.Size(245, 27);
            this.txActivation.TabIndex = 5;
            // 
            // tbCopy
            // 
            this.tbCopy.Font = new System.Drawing.Font("Product Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCopy.Location = new System.Drawing.Point(320, 17);
            this.tbCopy.Name = "tbCopy";
            this.tbCopy.Size = new System.Drawing.Size(75, 30);
            this.tbCopy.TabIndex = 6;
            this.tbCopy.Text = "Copy";
            this.tbCopy.UseVisualStyleBackColor = true;
            this.tbCopy.Click += new System.EventHandler(this.tbCopy_Click);
            // 
            // tbAktivasi
            // 
            this.tbAktivasi.Font = new System.Drawing.Font("Product Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAktivasi.Location = new System.Drawing.Point(242, 103);
            this.tbAktivasi.Name = "tbAktivasi";
            this.tbAktivasi.Size = new System.Drawing.Size(153, 40);
            this.tbAktivasi.TabIndex = 7;
            this.tbAktivasi.Text = "Activate";
            this.tbAktivasi.UseVisualStyleBackColor = true;
            this.tbAktivasi.Click += new System.EventHandler(this.tbAktivasi_Click);
            // 
            // txKata
            // 
            this.txKata.AutoSize = true;
            this.txKata.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txKata.ForeColor = System.Drawing.Color.Red;
            this.txKata.Location = new System.Drawing.Point(12, 113);
            this.txKata.Name = "txKata";
            this.txKata.Size = new System.Drawing.Size(13, 20);
            this.txKata.TabIndex = 8;
            this.txKata.Text = ".";
            this.txKata.Visible = false;
            // 
            // Aktivasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 155);
            this.Controls.Add(this.txKata);
            this.Controls.Add(this.tbAktivasi);
            this.Controls.Add(this.tbCopy);
            this.Controls.Add(this.txActivation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txSerial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Product Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Aktivasi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Activation";
            this.Load += new System.EventHandler(this.Aktivasi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txActivation;
        private System.Windows.Forms.Button tbCopy;
        private System.Windows.Forms.Button tbAktivasi;
        private System.Windows.Forms.Label txKata;
    }
}