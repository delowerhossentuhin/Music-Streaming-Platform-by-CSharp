using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectSpotify_CLONE
{
    public partial class ForgetPass : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-11TTHAE\SQLEXPRESS;Initial Catalog=Spotify_Clone;Integrated Security=True");
        private string to;
        private string randomCode;

        public ForgetPass()
        {
            InitializeComponent();
        }

        private void textBoxEm_Click(object sender, EventArgs e)
        {
            labelEm.Visible = false;
        }
        private string username;
        private void buttonPanelFP1_Click(object sender, EventArgs e)
        {
            to = textBoxEm.Text;
            username = textBox1.Text;

            if (string.IsNullOrWhiteSpace(to)||String.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your User Name and Email address.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query="Select Username, Email from User_Info where Username='"+username+"' and Email='"+to+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if(dtb.Rows.Count==1)
            {
                try
                {
                    // Generate a random OTP
                    Random rand = new Random();
                    randomCode = rand.Next(100000, 999999).ToString();

                    // Email configuration
                    string from = "souravzaman10@gmail.com"; // Replace with email
                    string password = "kplgrrdwfyzlrfct"; // Replace with email password
                    string subject = "Your OTP Code";

                    string email = textBoxEm.Text.Substring(0, 3) + $"" + textBoxEm.Text.Substring(((textBoxEm.Text.IndexOf('@')) - 3), 2) + $"@gmail.com. ";
                    string body =
                        $"Please use this code to verify the email address " + email + " for creating account in Spotify " +
                        $"\n\nYour Email Verification Code is {randomCode}" +
                        $"\n\nThanks, \nThe Spotify Account Team \nPrivacy Statement";


                    // Creating the email message
                    MailMessage message = new MailMessage();
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = body;
                    message.Subject = subject;

                    // Configuring the SMTP client
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, password);
                    smtp.Send(message);
                    MessageBox.Show("OTP has been sent to your email.", "OTP Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelFM1.Visible = false;
                    panelFM2.Visible = true;
                    panelLine12.BackColor = System.Drawing.Color.Black;
                    circularPanel2.BorderColor = System.Drawing.Color.Black;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Sending OTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }



        private void pictureBoxBack1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void textBoxCode1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCode1.Text.Length == 1)
            {
                textBoxCode2.Focus();
            }
        }

        private void textBoxCode2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCode2.Text.Length == 1)
            {
                textBoxCode3.Focus();
            }
        }

        private void textBoxCode3_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCode3.Text.Length == 1)
            {
                textBoxCode4.Focus();
            }
        }

        private void textBoxCode4_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCode4.Text.Length == 1)
            {
                textBoxCode5.Focus();
            }
        }

        private void textBoxCode5_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCode5.Text.Length == 1)
            {
                textBoxCode6.Focus();
            }
        }

        private void textBoxCode6_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCode6.Text.Length == 1)
            {
                buttonPanelFP2.Focus();
            }
        }


        private void buttonPanelFP2_Click(object sender, EventArgs e)
        {
            string enteredCode = textBoxCode1.Text.Trim() + textBoxCode2.Text.Trim() + textBoxCode3.Text.Trim() +
                                 textBoxCode4.Text.Trim() + textBoxCode5.Text.Trim() + textBoxCode6.Text.Trim();

            if (string.IsNullOrWhiteSpace(enteredCode))
            {
                MessageBox.Show("Please enter the verification code.", "Missing Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (enteredCode == randomCode)
            {
                MessageBox.Show("Verification successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); panelFM2.Visible = false;
                panelFM3.Visible = true;
                panelLine23.BackColor = System.Drawing.Color.Black;
                circularPanel3.BorderColor = System.Drawing.Color.Black;
            }
            else
            {
                MessageBox.Show("Invalid verification code. Please try again.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void linkLabelReCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            to = textBoxEm.Text;


            try
            {
                // Generate a random OTP
                Random rand = new Random();
                randomCode = rand.Next(100000, 999999).ToString();

                // Email configuration
                string from = "souravzaman10@gmail.com"; // Replace with email
                string password = "kplgrrdwfyzlrfct"; // Replace with email password
                string subject = "Your OTP Code";

                string email = textBoxEm.Text.Substring(0, 3) + $"" + textBoxEm.Text.Substring(((textBoxEm.Text.IndexOf('@')) - 3), 2) + $"@gmail.com. ";
                string body =
                    $"Please use this code to verify the email address " + email + " for creating account in Spotify " +
                    $"\n\nYour Email Verification Code is {randomCode}" +
                    $"\n\nThanks, \nThe Spotify Account Team \nPrivacy Statement";


                // Creating the email message
                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = body;
                message.Subject = subject;

                // Configuring the SMTP client
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, password);
                smtp.Send(message);
                MessageBox.Show("OTP has been sent to your email.", "OTP Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Sending OTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxBack2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp().Show();
        }


        private void textBoxRepass_TextChanged(object sender, EventArgs e)
        {
            int repassLength = textBoxRepass.Text.Length;
            if (repassLength <= textBoxPass.Text.Length)
            {
                if (textBoxRepass.Text == textBoxPass.Text.Substring(0, repassLength))
                {
                    panel3.BackColor = Color.Black;
                }
                else
                {
                    panel3.BackColor = Color.Red;
                }
            }
            else
            {
                panel3.BackColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxPass.Text == textBoxRepass.Text)
            {
                //Update quary
                string query1 = "Update User_Info set Password='" + textBoxPass.Text + "' where Username='" + username + "'";
                String query2 = "Update Login set Password='" + textBoxPass.Text + "' where Username='" + username + "'";
                SqlCommand cmd = new SqlCommand(query1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd = new SqlCommand(query2, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                string type = "";
                string query3 = "Select UserType from User_Info where Username='" + username + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query3, con);
                DataTable dtb = new DataTable();
                sda.Fill(dtb);
                type = dtb.Rows[0]["UserType"].ToString();
                string qqType="";
                if (type == "Audience")
                {
                    qqType= "Update Audience_Info set Password='" + textBoxPass.Text + "' where Username='" + username + "'";
                }
                else if(type=="Artist")
                {
                    qqType = "Update Artist_Info set Password='" + textBoxPass.Text + "' where Username='" + username + "'";
                }
                if(type=="Executive")
                {
                    qqType = "Update Admin_Info set Password='" + textBoxPass.Text + "' where UserName='" + username + "'";

                }
                SqlCommand cmd2 = new SqlCommand(qqType, con);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Your Password is Updated", "Password Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new LoginForm().Show();


            }
            else
            {
                MessageBox.Show("Your Password Didn't match", "Didn't Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void pictureBoxBack3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp().Show();
        }


        private void circularPanel1_Click(object sender, EventArgs e)
        {
            panelFM1.Visible = true;
            panelFM2.Visible = false;
            panelFM3.Visible = false;
            circularPanel1.BorderColor = System.Drawing.Color.Black;
            circularPanel2.BorderColor = System.Drawing.Color.White;
            circularPanel3.BorderColor = System.Drawing.Color.White;
        }

        private void circularPanel2_Click(object sender, EventArgs e)
        {
            panelFM1.Visible = false;
            panelFM2.Visible = true;
            panelFM3.Visible = false;
            circularPanel1.BorderColor = System.Drawing.Color.White;
            circularPanel2.BorderColor = System.Drawing.Color.Black;
            circularPanel3.BorderColor = System.Drawing.Color.White;
        }

        private void circularPanel3_Click(object sender, EventArgs e)
        {
            panelFM1.Visible = false;
            panelFM2.Visible = false;
            panelFM3.Visible = true;
            circularPanel1.BorderColor = System.Drawing.Color.White;
            circularPanel2.BorderColor = System.Drawing.Color.White;
            circularPanel3.BorderColor = System.Drawing.Color.Black;
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {

        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelEm_Click(object sender, EventArgs e)
        {
            labelEm.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Hide();
        }

        private void textBoxEm_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void ForgetPass_Load(object sender, EventArgs e)
        {

        }
    }


}
