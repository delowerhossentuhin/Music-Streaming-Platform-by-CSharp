
namespace ProjectSpotify_CLONE
{
    partial class Payment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payment));
            this.panel1 = new System.Windows.Forms.Panel();
            this.totalTK = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.payMethod_Combe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.firstName_Txt = new System.Windows.Forms.TextBox();
            this.lastName_Txt = new System.Windows.Forms.TextBox();
            this.email_Txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pinCVV_TXT = new System.Windows.Forms.TextBox();
            this.card_TXT = new System.Windows.Forms.TextBox();
            this.CVV_Label = new System.Windows.Forms.Label();
            this.cardNumber_Label = new System.Windows.Forms.Label();
            this.validUntil_Panel = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Back_BTN = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.nagad_pictureBox = new System.Windows.Forms.PictureBox();
            this.bkash_pictureBox = new System.Windows.Forms.PictureBox();
            this.master_card_pictureBox = new System.Windows.Forms.PictureBox();
            this.visa_pictureBox = new System.Windows.Forms.PictureBox();
            this.unionpay_pictureBox = new System.Windows.Forms.PictureBox();
            this.nexuspay_pictureBox = new System.Windows.Forms.PictureBox();
            this.ammex_pictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.validUntil_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nagad_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bkash_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.master_card_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visa_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unionpay_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nexuspay_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ammex_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.totalTK);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(-3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 48);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // totalTK
            // 
            this.totalTK.AutoSize = true;
            this.totalTK.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTK.ForeColor = System.Drawing.Color.Snow;
            this.totalTK.Location = new System.Drawing.Point(213, 5);
            this.totalTK.Name = "totalTK";
            this.totalTK.Size = new System.Drawing.Size(135, 37);
            this.totalTK.TabIndex = 19;
            this.totalTK.Text = "0000 TK:-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Snow;
            this.label5.Location = new System.Drawing.Point(12, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 37);
            this.label5.TabIndex = 18;
            this.label5.Text = "Total Amount:-";
            // 
            // payMethod_Combe
            // 
            this.payMethod_Combe.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.payMethod_Combe.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payMethod_Combe.FormattingEnabled = true;
            this.payMethod_Combe.Items.AddRange(new object[] {
            "Credit Card",
            "Debit Card",
            "Bkash",
            "Nagad"});
            this.payMethod_Combe.Location = new System.Drawing.Point(16, 68);
            this.payMethod_Combe.Name = "payMethod_Combe";
            this.payMethod_Combe.Size = new System.Drawing.Size(656, 34);
            this.payMethod_Combe.TabIndex = 1;
            this.payMethod_Combe.Tag = "";
            this.payMethod_Combe.Text = "Select A Method";
            this.payMethod_Combe.SelectedIndexChanged += new System.EventHandler(this.payMethod_Combe_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(95)))), ((int)(((byte)(10)))));
            this.label2.Location = new System.Drawing.Point(25, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "First Name:-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(95)))), ((int)(((byte)(10)))));
            this.label3.Location = new System.Drawing.Point(413, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 22);
            this.label3.TabIndex = 21;
            this.label3.Text = "Last Name:-";
            // 
            // firstName_Txt
            // 
            this.firstName_Txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstName_Txt.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstName_Txt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.firstName_Txt.Location = new System.Drawing.Point(30, 132);
            this.firstName_Txt.Multiline = true;
            this.firstName_Txt.Name = "firstName_Txt";
            this.firstName_Txt.Size = new System.Drawing.Size(229, 30);
            this.firstName_Txt.TabIndex = 22;
            // 
            // lastName_Txt
            // 
            this.lastName_Txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lastName_Txt.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastName_Txt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lastName_Txt.Location = new System.Drawing.Point(418, 132);
            this.lastName_Txt.Multiline = true;
            this.lastName_Txt.Name = "lastName_Txt";
            this.lastName_Txt.Size = new System.Drawing.Size(229, 30);
            this.lastName_Txt.TabIndex = 24;
            // 
            // email_Txt
            // 
            this.email_Txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email_Txt.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_Txt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.email_Txt.Location = new System.Drawing.Point(102, 178);
            this.email_Txt.Multiline = true;
            this.email_Txt.Name = "email_Txt";
            this.email_Txt.Size = new System.Drawing.Size(545, 30);
            this.email_Txt.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(95)))), ((int)(((byte)(10)))));
            this.label1.Location = new System.Drawing.Point(25, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 22);
            this.label1.TabIndex = 25;
            this.label1.Text = "Email:-";
            // 
            // pinCVV_TXT
            // 
            this.pinCVV_TXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pinCVV_TXT.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pinCVV_TXT.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.pinCVV_TXT.Location = new System.Drawing.Point(417, 257);
            this.pinCVV_TXT.Multiline = true;
            this.pinCVV_TXT.Name = "pinCVV_TXT";
            this.pinCVV_TXT.Size = new System.Drawing.Size(229, 30);
            this.pinCVV_TXT.TabIndex = 30;
            // 
            // card_TXT
            // 
            this.card_TXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card_TXT.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.card_TXT.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.card_TXT.Location = new System.Drawing.Point(29, 257);
            this.card_TXT.Multiline = true;
            this.card_TXT.Name = "card_TXT";
            this.card_TXT.Size = new System.Drawing.Size(229, 30);
            this.card_TXT.TabIndex = 29;
            // 
            // CVV_Label
            // 
            this.CVV_Label.AutoSize = true;
            this.CVV_Label.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CVV_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(95)))), ((int)(((byte)(10)))));
            this.CVV_Label.Location = new System.Drawing.Point(415, 232);
            this.CVV_Label.Name = "CVV_Label";
            this.CVV_Label.Size = new System.Drawing.Size(55, 22);
            this.CVV_Label.TabIndex = 28;
            this.CVV_Label.Text = "CVV:-";
            // 
            // cardNumber_Label
            // 
            this.cardNumber_Label.AutoSize = true;
            this.cardNumber_Label.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardNumber_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(95)))), ((int)(((byte)(10)))));
            this.cardNumber_Label.Location = new System.Drawing.Point(24, 232);
            this.cardNumber_Label.Name = "cardNumber_Label";
            this.cardNumber_Label.Size = new System.Drawing.Size(123, 22);
            this.cardNumber_Label.TabIndex = 27;
            this.cardNumber_Label.Text = "Card Number:-";
            this.cardNumber_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // validUntil_Panel
            // 
            this.validUntil_Panel.Controls.Add(this.comboBox2);
            this.validUntil_Panel.Controls.Add(this.comboBox1);
            this.validUntil_Panel.Controls.Add(this.label7);
            this.validUntil_Panel.Location = new System.Drawing.Point(64, 395);
            this.validUntil_Panel.Name = "validUntil_Panel";
            this.validUntil_Panel.Size = new System.Drawing.Size(536, 66);
            this.validUntil_Panel.TabIndex = 31;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox2.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033"});
            this.comboBox2.Location = new System.Drawing.Point(350, 17);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(158, 29);
            this.comboBox2.TabIndex = 33;
            this.comboBox2.Tag = "";
            this.comboBox2.Text = "Select A Year";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox1.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBox1.Location = new System.Drawing.Point(141, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(158, 29);
            this.comboBox1.TabIndex = 32;
            this.comboBox1.Tag = "";
            this.comboBox1.Text = "Select A Month";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(95)))), ((int)(((byte)(10)))));
            this.label7.Location = new System.Drawing.Point(36, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 22);
            this.label7.TabIndex = 32;
            this.label7.Text = "Valid Until:-";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Back_BTN
            // 
            this.Back_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.Back_BTN.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back_BTN.ForeColor = System.Drawing.Color.White;
            this.Back_BTN.Location = new System.Drawing.Point(8, 506);
            this.Back_BTN.Name = "Back_BTN";
            this.Back_BTN.Size = new System.Drawing.Size(110, 40);
            this.Back_BTN.TabIndex = 32;
            this.Back_BTN.Text = "Back";
            this.Back_BTN.UseVisualStyleBackColor = false;
            this.Back_BTN.Click += new System.EventHandler(this.Back_BTN_Click);
            // 
            // Submit
            // 
            this.Submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.Submit.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit.ForeColor = System.Drawing.Color.White;
            this.Submit.Location = new System.Drawing.Point(529, 506);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(138, 40);
            this.Submit.TabIndex = 33;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = false;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // nagad_pictureBox
            // 
            this.nagad_pictureBox.Image = global::ProjectSpotify_CLONE.Properties.Resources.nagad_removebg_preview2;
            this.nagad_pictureBox.Location = new System.Drawing.Point(488, 298);
            this.nagad_pictureBox.Name = "nagad_pictureBox";
            this.nagad_pictureBox.Size = new System.Drawing.Size(60, 60);
            this.nagad_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.nagad_pictureBox.TabIndex = 40;
            this.nagad_pictureBox.TabStop = false;
            // 
            // bkash_pictureBox
            // 
            this.bkash_pictureBox.Image = global::ProjectSpotify_CLONE.Properties.Resources.bkash_removebg_preview;
            this.bkash_pictureBox.Location = new System.Drawing.Point(410, 298);
            this.bkash_pictureBox.Name = "bkash_pictureBox";
            this.bkash_pictureBox.Size = new System.Drawing.Size(60, 60);
            this.bkash_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bkash_pictureBox.TabIndex = 39;
            this.bkash_pictureBox.TabStop = false;
            // 
            // master_card_pictureBox
            // 
            this.master_card_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("master_card_pictureBox.Image")));
            this.master_card_pictureBox.Location = new System.Drawing.Point(104, 298);
            this.master_card_pictureBox.Name = "master_card_pictureBox";
            this.master_card_pictureBox.Size = new System.Drawing.Size(60, 60);
            this.master_card_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.master_card_pictureBox.TabIndex = 38;
            this.master_card_pictureBox.TabStop = false;
            // 
            // visa_pictureBox
            // 
            this.visa_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("visa_pictureBox.Image")));
            this.visa_pictureBox.Location = new System.Drawing.Point(178, 298);
            this.visa_pictureBox.Name = "visa_pictureBox";
            this.visa_pictureBox.Size = new System.Drawing.Size(60, 60);
            this.visa_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.visa_pictureBox.TabIndex = 37;
            this.visa_pictureBox.TabStop = false;
            // 
            // unionpay_pictureBox
            // 
            this.unionpay_pictureBox.Image = global::ProjectSpotify_CLONE.Properties.Resources.union_pay_removebg_preview;
            this.unionpay_pictureBox.Location = new System.Drawing.Point(252, 298);
            this.unionpay_pictureBox.Name = "unionpay_pictureBox";
            this.unionpay_pictureBox.Size = new System.Drawing.Size(60, 60);
            this.unionpay_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.unionpay_pictureBox.TabIndex = 36;
            this.unionpay_pictureBox.TabStop = false;
            // 
            // nexuspay_pictureBox
            // 
            this.nexuspay_pictureBox.Image = global::ProjectSpotify_CLONE.Properties.Resources.nexuspay_removebg_preview;
            this.nexuspay_pictureBox.Location = new System.Drawing.Point(333, 298);
            this.nexuspay_pictureBox.Name = "nexuspay_pictureBox";
            this.nexuspay_pictureBox.Size = new System.Drawing.Size(60, 60);
            this.nexuspay_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.nexuspay_pictureBox.TabIndex = 35;
            this.nexuspay_pictureBox.TabStop = false;
            // 
            // ammex_pictureBox
            // 
            this.ammex_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ammex_pictureBox.Image")));
            this.ammex_pictureBox.Location = new System.Drawing.Point(30, 298);
            this.ammex_pictureBox.Name = "ammex_pictureBox";
            this.ammex_pictureBox.Size = new System.Drawing.Size(60, 60);
            this.ammex_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ammex_pictureBox.TabIndex = 34;
            this.ammex_pictureBox.TabStop = false;
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.nagad_pictureBox);
            this.Controls.Add(this.bkash_pictureBox);
            this.Controls.Add(this.master_card_pictureBox);
            this.Controls.Add(this.visa_pictureBox);
            this.Controls.Add(this.unionpay_pictureBox);
            this.Controls.Add(this.nexuspay_pictureBox);
            this.Controls.Add(this.ammex_pictureBox);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.Back_BTN);
            this.Controls.Add(this.validUntil_Panel);
            this.Controls.Add(this.pinCVV_TXT);
            this.Controls.Add(this.card_TXT);
            this.Controls.Add(this.CVV_Label);
            this.Controls.Add(this.cardNumber_Label);
            this.Controls.Add(this.email_Txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lastName_Txt);
            this.Controls.Add(this.firstName_Txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.payMethod_Combe);
            this.Controls.Add(this.panel1);
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.Payment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.validUntil_Panel.ResumeLayout(false);
            this.validUntil_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nagad_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bkash_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.master_card_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visa_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unionpay_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nexuspay_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ammex_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label totalTK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox payMethod_Combe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox firstName_Txt;
        private System.Windows.Forms.TextBox lastName_Txt;
        private System.Windows.Forms.TextBox email_Txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pinCVV_TXT;
        private System.Windows.Forms.TextBox card_TXT;
        private System.Windows.Forms.Label CVV_Label;
        private System.Windows.Forms.Label cardNumber_Label;
        private System.Windows.Forms.Panel validUntil_Panel;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Back_BTN;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.PictureBox ammex_pictureBox;
        private System.Windows.Forms.PictureBox nexuspay_pictureBox;
        private System.Windows.Forms.PictureBox unionpay_pictureBox;
        private System.Windows.Forms.PictureBox visa_pictureBox;
        private System.Windows.Forms.PictureBox master_card_pictureBox;
        private System.Windows.Forms.PictureBox bkash_pictureBox;
        private System.Windows.Forms.PictureBox nagad_pictureBox;
    }
}