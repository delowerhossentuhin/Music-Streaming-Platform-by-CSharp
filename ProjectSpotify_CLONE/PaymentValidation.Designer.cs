
namespace ProjectSpotify_CLONE
{
    partial class PaymentValidation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentValidation));
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGenerateInvoice = new System.Windows.Forms.Button();
            this.backtoHome = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(95)))), ((int)(((byte)(10)))));
            this.label5.Location = new System.Drawing.Point(85, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(492, 37);
            this.label5.TabIndex = 18;
            this.label5.Text = "You are now Subscribed!!! Thank You";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(95)))), ((int)(((byte)(10)))));
            this.label1.Location = new System.Drawing.Point(200, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Enjoy All Premium Features";
            // 
            // buttonGenerateInvoice
            // 
            this.buttonGenerateInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.buttonGenerateInvoice.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateInvoice.ForeColor = System.Drawing.Color.White;
            this.buttonGenerateInvoice.Location = new System.Drawing.Point(225, 343);
            this.buttonGenerateInvoice.Name = "buttonGenerateInvoice";
            this.buttonGenerateInvoice.Size = new System.Drawing.Size(217, 40);
            this.buttonGenerateInvoice.TabIndex = 34;
            this.buttonGenerateInvoice.Text = "Download Invoice PDF";
            this.buttonGenerateInvoice.UseVisualStyleBackColor = false;
            this.buttonGenerateInvoice.Click += new System.EventHandler(this.buttonGenerateInvoice_Click);
            // 
            // backtoHome
            // 
            this.backtoHome.BackColor = System.Drawing.Color.Firebrick;
            this.backtoHome.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backtoHome.ForeColor = System.Drawing.Color.White;
            this.backtoHome.Location = new System.Drawing.Point(225, 398);
            this.backtoHome.Name = "backtoHome";
            this.backtoHome.Size = new System.Drawing.Size(217, 40);
            this.backtoHome.TabIndex = 35;
            this.backtoHome.Text = "Back To HomePage";
            this.backtoHome.UseVisualStyleBackColor = false;
            this.backtoHome.Click += new System.EventHandler(this.backtoHome_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(133, 119);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(420, 218);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // PaymentValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.backtoHome);
            this.Controls.Add(this.buttonGenerateInvoice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "PaymentValidation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentValidation";
            this.Load += new System.EventHandler(this.PaymentValidation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGenerateInvoice;
        private System.Windows.Forms.Button backtoHome;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}