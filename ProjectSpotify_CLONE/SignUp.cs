using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
namespace ProjectSpotify_CLONE
{
    public partial class SignUp : Form
    {
        private string dpFilePath = "";
        private Label stageName_Label;
        private TextBox stageName_TextBox;
        private Label StageName;
        private TextBox StageNameText;
        private string TO="";
        private string randomCode="";
        //private String FirstName, LastName, PhoneNo, SMedia, FavArtist, FavGenre, UserT, MusicPref, EmailId, UserName, PassW;

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-11TTHAE\SQLEXPRESS;Initial Catalog=Spotify_Clone;Integrated Security=True");

        public SignUp()
        {
            InitializeComponent();
            //this.Load += new EventHandler(SignUp_Load);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            perInfo_Panel.Visible = true;
            contact_Panel.Visible = false;
            preferences_panel.Visible = false;
            account_Panel.Visible = false;
            All_Info_Panel.Visible = false;

            perInfo_BTN.BackColor = Color.White;
            contacInfo_BTN.BackColor = Color.Transparent;
            preferences_BTN.BackColor = Color.Transparent;
            accountInfo_BTN.BackColor = Color.Transparent;
            All_Info_Panel.Visible = false;
            allInfo_BTN.BackColor = Color.Transparent;
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            //button1.BackColor = Color.FromArgb(153, 204, 255);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void photoUp_BTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            open.Title = "Select an Image File";
            if (open.ShowDialog() == DialogResult.OK)
            {
                dpFilePath = open.FileName;
                MessageBox.Show("File Selected: " + dpFilePath);
                ProfilePhoto.ImageLocation = dpFilePath;
            }
            dp_PicBox.ImageLocation = dpFilePath;

        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            perInfo_Panel.Visible = true;
            if(perInfo_Panel.Visible==true)
            {
                perInfo_BTN.BackColor = Color.White;
            }
            if (perInfo_Panel.Visible == true)
            {
                perInfo_BTN.BackColor = Color.White;
            }
            contact_Panel.Visible = false;
            preferences_panel.Visible = false;
            account_Panel.Visible = false;
            All_Info_Panel.Visible = false;

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void prevCI_BTN_Click(object sender, EventArgs e)
        {
            contact_Panel.Visible = false;
            perInfo_Panel.Visible = true;
            contacInfo_BTN.BackColor = Color.Transparent;
            perInfo_BTN.BackColor = Color.White;
        }

        private void next_BTN_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(dp_PicBox.ImageLocation) ||
                String.IsNullOrWhiteSpace(firstName_Txt.Text) ||
                String.IsNullOrWhiteSpace(lastName_TXT.Text) ||
                Utype_Combo.SelectedItem==null)
            {
                MessageBox.Show("Fill All Section Including your photo", "Fill Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (Utype_Combo.SelectedItem.ToString() == "Artist" && String.IsNullOrWhiteSpace(stageName_TextBox.Text))
                {
                    MessageBox.Show("Fill Stage Name Section", "Fill Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    perInfo_Panel.Visible = false;
                    contact_Panel.Visible = true;
                    perInfo_BTN.BackColor = Color.Transparent;
                    contacInfo_BTN.BackColor = Color.White;
                }
            }
        }


        private void contacInfo_BTN_Click(object sender, EventArgs e)
        {
            contact_Panel.Visible = true;
            perInfo_Panel.Visible = false;
            preferences_panel.Visible = false;
            account_Panel.Visible = false;

            contacInfo_BTN.BackColor = Color.White;
            perInfo_BTN.BackColor = Color.Transparent;
            preferences_BTN.BackColor = Color.Transparent;
            accountInfo_BTN.BackColor = Color.Transparent;
            All_Info_Panel.Visible = false;
            allInfo_BTN.BackColor = Color.Transparent;

        }

        private void nextCI_BTN_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Email_TXT.Text)||
                string.IsNullOrWhiteSpace(phn_TXT.Text)||
                string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Fill Up All Section", "Fill Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            preferences_panel.Visible = true;
            contact_Panel.Visible = false;
            contacInfo_BTN.BackColor = Color.Transparent;
            preferences_BTN.BackColor = Color.White;
        }

        private void contact_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void preferences_BTN_Click(object sender, EventArgs e)
        {
            preferences_panel.Visible = true;
            perInfo_Panel.Visible = false;
            contact_Panel.Visible = false;
            account_Panel.Visible = false;

            preferences_BTN.BackColor = Color.White;
            contacInfo_BTN.BackColor = Color.Transparent;
            perInfo_BTN.BackColor = Color.Transparent;
            accountInfo_BTN.BackColor = Color.Transparent;

            All_Info_Panel.Visible = false;
            allInfo_BTN.BackColor = Color.Transparent;
        }

        private void pre_Pref_BTN_Click(object sender, EventArgs e)
        {
            contact_Panel.Visible = true;
            preferences_panel.Visible = false;
            contacInfo_BTN.BackColor = Color.White;
            preferences_BTN.BackColor = Color.Transparent;
        }

        private void back_pre_BTN_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(favArtist_TXT.Text)||
                String.IsNullOrWhiteSpace(musicPref_TXT.Text)||
                favGenre_COMBO.SelectedItem==null)
            {
                MessageBox.Show("Fill Up All Section", "Fill Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            account_Panel.Visible = true;
            preferences_panel.Visible = false;
            preferences_BTN.BackColor = Color.Transparent;
            accountInfo_BTN.BackColor = Color.White;
        }

        private void pre_Ainfo_BTN_Click(object sender, EventArgs e)
        {
            preferences_panel.Visible = true;
            account_Panel.Visible = false;

            preferences_BTN.BackColor = Color.White;
            accountInfo_BTN.BackColor = Color.Transparent;
        }

        private void dash_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void accountInfo_BTN_Click(object sender, EventArgs e)
        {
            perInfo_BTN.BackColor = Color.Transparent;
            contacInfo_BTN.BackColor = Color.Transparent;
            preferences_BTN.BackColor = Color.Transparent;
            accountInfo_BTN.BackColor = Color.White;
            allInfo_BTN.BackColor = Color.Transparent;

            preferences_panel.Visible = false;
            perInfo_Panel.Visible = false;
            contact_Panel.Visible = false;
            account_Panel.Visible = true;
            All_Info_Panel.Visible = false;
        }

        private void showPass_CHK_CheckedChanged(object sender, EventArgs e)
        {
            if(showPass_CHK.Checked)
            {
                password_Txt.UseSystemPasswordChar = true;
            }
            else password_Txt.UseSystemPasswordChar = false;
        }

        private void reShowPass_CHK_CheckedChanged(object sender, EventArgs e)
        {
            if (reShowPass_CHK.Checked)
            {
                rePass_Txt.UseSystemPasswordChar = true;
            }
            else rePass_Txt.UseSystemPasswordChar = false;
        }

        private void back_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Welcome().Show();
        }
        
        private void perInfo_Panel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Utype_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserType.Text = Utype_Combo.SelectedItem.ToString();
            if (Utype_Combo.SelectedItem != null && Utype_Combo.SelectedItem.ToString() == "Artist")
            {
                if (stageName_Label == null)
                {
                    stageName_Label = new Label();
                    stageName_Label.Text = "Stage Name";
                    stageName_Label.Location = new Point(33, 403);
                    stageName_Label.Size = new Size(132, 25);
                    stageName_Label.Font = new Font("Cambria", (float)15.75, FontStyle.Bold);
                    stageName_Label.ForeColor = Color.FromArgb(50, 50, 50);
                    perInfo_Panel.Controls.Add(stageName_Label);
                }
                else stageName_Label.Visible = true;
                if (stageName_TextBox == null)
                {
                    stageName_TextBox = new TextBox();
                    stageName_TextBox.Location = new Point(197, 401);
                    stageName_TextBox.Size = new Size(309, 30);
                    stageName_TextBox.Font = new Font("Kalpurush", 12, FontStyle.Bold);
                    stageName_TextBox.TextChanged += stageName_TextBox_TextChanged;
                    perInfo_Panel.Controls.Add(stageName_TextBox);
                }
                else stageName_TextBox.Visible = true;

                ///info panel
                if (StageNameText == null)
                {
                    StageNameText = new TextBox();
                    StageNameText.Location = new Point(433, 186);
                    StageNameText.Size = new Size(150,19);
                    StageNameText.ReadOnly = true;
                    StageNameText.Font = new Font("Cambria", 10, FontStyle.Bold);
                    All_Info_Panel.Controls.Add(StageNameText);
                }
                else StageNameText.Visible = true;
                if (StageName == null)
                {
                    StageName = new Label();
                    StageName.Text = "Stage Name";
                    StageName.Location = new Point(325, 186);
                    StageName.Size = new Size(103, 19);
                    StageName.Font = new Font("Cambria", (float)12, FontStyle.Bold);
                    StageName.ForeColor = Color.FromArgb(50, 50, 50);
                    All_Info_Panel.Controls.Add(StageName);
                }
                else StageName.Visible = true;
            }
            else
            {
                if (stageName_Label != null) stageName_Label.Visible = false;
                if (stageName_TextBox != null) stageName_TextBox.Visible = false;
                if (StageName != null) StageName.Visible = false;
                if (StageNameText != null) StageNameText.Visible = false;
            }
            //StageName.Text = stageName_TextBox.Text;
        }

        private void allInfo_BTN_Click(object sender, EventArgs e)
        {
            contact_Panel.Visible = false;
            perInfo_Panel.Visible = false;
            preferences_panel.Visible = false;
            account_Panel.Visible = false;
            All_Info_Panel.Visible = true;

            contacInfo_BTN.BackColor = Color.Transparent;
            perInfo_BTN.BackColor = Color.Transparent;
            preferences_BTN.BackColor = Color.Transparent;
            accountInfo_BTN.BackColor = Color.Transparent;
            allInfo_BTN.BackColor = Color.White;
        }

        private void nextAinfo_BTN_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(userName_TXT.Text)||
                String.IsNullOrWhiteSpace(password_Txt.Text)||
                String.IsNullOrWhiteSpace(rePass_Txt.Text))
            {
                MessageBox.Show("Fill Up All Section", "Fill Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(password_Txt.Text!=rePass_Txt.Text)
            {
                MessageBox.Show("Password didn't match", "Matching Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            account_Panel.Visible = false;
            All_Info_Panel.Visible = true;

            allInfo_BTN.BackColor = Color.White;
            accountInfo_BTN.BackColor = Color.Transparent;
        }

        private void firstName_Txt_TextChanged(object sender, EventArgs e)
        {
            First_Name.Text = firstName_Txt.Text;
        }

        private void lastName_TXT_TextChanged(object sender, EventArgs e)
        {
            Last_Name.Text = lastName_TXT.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Email_TXT_TextChanged(object sender, EventArgs e)
        {
            Email_Id.Text = Email_TXT.Text;
        }

        private void First_Name_TextChanged(object sender, EventArgs e)
        {
            //FirstName = First_Name.Text;
        }

        private void phn_TXT_TextChanged(object sender, EventArgs e)
        {
            Phone.Text = phn_TXT.Text;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            SocialMedia.Text = textBox1.Text;
        }

        private void favArtist_TXT_TextChanged(object sender, EventArgs e)
        {
            Fav_Artist.Text = favArtist_TXT.Text;
        }

        private void musicPref_TXT_TextChanged(object sender, EventArgs e)
        {
            Music_Pref.Text = musicPref_TXT.Text;
        }

        private void favGenre_COMBO_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fav_Genre.Text = favGenre_COMBO.SelectedItem.ToString();
        }

        private void userName_TXT_TextChanged(object sender, EventArgs e)
        {
            User_Name.Text = userName_TXT.Text;
        }

        private void password_Txt_TextChanged(object sender, EventArgs e)
        {
            Password.Text = password_Txt.Text;
        }
        private void stageName_TextBox_TextChanged(object sender, EventArgs e)
        {
           
            if (StageNameText != null)
            {
                StageNameText.Text = stageName_TextBox.Text; 
            }
        }

        private void request_BTN_Click(object sender, EventArgs e)
        {
            TO = Email_Id.Text;

            if (string.IsNullOrWhiteSpace(TO))
            {
                MessageBox.Show("Please enter your Email address.", "Missing Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Generate a random OTP
                Random rand = new Random();
                randomCode = rand.Next(100000, 999999).ToString();

                // Email configuration
                string from = "souravzaman10@gmail.com"; // Replace with email
                string password = "kplgrrdwfyzlrfct"; // Replace with email password
                string subject = "Your OTP Code";

                string email = Email_Id.Text.Substring(0, 3) + $"" + Email_Id.Text.Substring(((Email_Id.Text.IndexOf('@')) - 3), 2) + $"@gmail.com. ";
                string body =
                    $"Please use this code to verify the email address " + email + " for creating account in Spotify " +
                    $"\n\nYour Email Verification Code is {randomCode}" +
                    $"\n\nThanks, \nThe Spotify Account Team \nPrivacy Statement";


                // Creating the email message
                MailMessage message = new MailMessage();
                message.To.Add(TO);
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
        
        private void LoginBTN_Click(object sender, EventArgs e)
        {
            
            ////////////////validation/////////////
            string enteredCode = VCODE.Text;
            if (string.IsNullOrWhiteSpace(enteredCode))
            {
                MessageBox.Show("Please enter the verification code.", "Missing Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (enteredCode != randomCode)
            {
                MessageBox.Show("Invalid verification code. Please try again.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var result = MessageBox.Show("Verification successful!"+"\n Wait for Admin Approval", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(result==DialogResult.OK)
            {
                string idquery2 = "select ArtistID from Artist_Info where Username='" + User_Name.Text + "' ";
                string idquery1 = "select AudienceID from Audience_Info where Username='" + User_Name.Text + "' ";
                if (UserType.Text=="Audience")
                {
                    string query1 = "Insert Into Audience_Info values ('" + First_Name.Text + "','" + Last_Name.Text + "','" + Email_Id.Text + "','" + User_Name.Text + "','" + Password.Text + "','" + Fav_Artist.Text + "','" + Music_Pref.Text + "','" + favGenre_COMBO.Text + "',3000,'" + Phone.Text + "','" + dpFilePath + "')";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    SqlDataAdapter sda= new SqlDataAdapter(idquery1,con);
                    DataTable dtb = new DataTable();
                    sda.Fill(dtb);
                    int id=0;
                    if (dtb.Rows.Count>0)
                    {
                        id = Convert.ToInt32(dtb.Rows[0]["AudienceID"]);
                    }
                    string q = "Insert Into User_Info values('" + id.ToString() + "','" + First_Name.Text + "','" + Last_Name.Text + "','"+UserType.Text+"','" + Phone.Text + "','" + Email_Id.Text + "','" + User_Name.Text + "','" + Password.Text + "',3000,'" + dpFilePath + "')";
                    SqlCommand cmd11 = new SqlCommand(q, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();
                    string qloginAud = "Insert Into Login values('" + User_Name.Text + "','" + Password.Text + "','" + UserType.Text + "',0)";
                    SqlCommand qlogAud = new SqlCommand(qloginAud, con);
                    con.Open();
                    qlogAud.ExecuteNonQuery();
                    con.Close();
                }
                else if(UserType.Text=="Artist")
                {
                    string query2 = "Insert Into Artist_Info values('" + StageNameText.Text + "','" + First_Name.Text + "','" + Last_Name.Text + "','" + Phone.Text + "','" + Email_Id.Text + "','" + Fav_Genre.Text + "','" + SocialMedia.Text + "','" + User_Name.Text + "','" + Password.Text + "',3000,'" + dpFilePath + "')";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    SqlDataAdapter sda = new SqlDataAdapter(idquery2, con);
                    DataTable dtb = new DataTable();
                    sda.Fill(dtb);
                    int id = 0;
                    if (dtb.Rows.Count > 0)
                    {
                        id = Convert.ToInt32(dtb.Rows[0]["ArtistID"]);
                    }
                    string q = "Insert Into User_Info values('" + id.ToString() + "','" + First_Name.Text + "','" + Last_Name.Text + "','" + UserType.Text + "','" + Phone.Text + "','" + Email_Id.Text + "','" + User_Name.Text + "','" + Password.Text + "',3000,'" + dpFilePath + "')";
                    SqlCommand cmd11 = new SqlCommand(q, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();
                    string qloginAud = "Insert Into Login values('" + User_Name.Text + "','" + Password.Text + "','" + UserType.Text + "',0)";
                    SqlCommand qlogAud = new SqlCommand(qloginAud, con);
                    con.Open();
                    qlogAud.ExecuteNonQuery();
                    con.Close();
                }
                

                this.Hide();
                new LoginForm().Show();
            }
        }

        private void userName_TXT_Leave(object sender, EventArgs e)
        {
            string query = "Select * from User_Info where Username='"+userName_TXT.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if(dtb.Rows.Count>0)
            {
                MessageBox.Show("This UserName is Alreary Used, Pleased write another","Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
                userName_TXT.Clear();
                userName_TXT.Focus();

            }

        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
