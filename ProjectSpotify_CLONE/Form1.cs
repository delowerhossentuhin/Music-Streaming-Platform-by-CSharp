using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ProjectSpotify_CLONE
{
    public partial class LoginForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-11TTHAE\SQLEXPRESS;Initial Catalog=Spotify_Clone;Integrated Security=True");
        public LoginForm()
        {
            InitializeComponent();

        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void passTXT_Enter(object sender, EventArgs e)
        {
            if(passTXT.Text=="Password")
            {
                passTXT.Text = "";
                passTXT.ForeColor = Color.White;
            }
        }

        private void passTXT_Leave(object sender, EventArgs e)
        {
            if(passTXT.Text=="")
            {
                passTXT.Text = "Password";
                passTXT.ForeColor = Color.Silver;
            }
        }

        private void UnameTXT_Enter(object sender, EventArgs e)
        {
            if(UnameTXT.Text=="User Name")
            {
                UnameTXT.Text = "";
                UnameTXT.ForeColor = Color.White;
            }
        }

        private void UnameTXT_Leave(object sender, EventArgs e)
        {
            if(UnameTXT.Text=="")
            {
                UnameTXT.Text = "User Name";
                UnameTXT.ForeColor = Color.Silver;
            }
        }

        private void back_BTN_Click(object sender, EventArgs e)
        {
            new Welcome().Show();
            this.Hide();
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            //////////////for testing////////
            //Random random = new Random();
            //int r = random.Next(0, 3);
            //this.Hide();
            //if (r == 0) new AudiencePortal().Show();
            //else if (r == 1) new ArtistPortal().Show();
            //else new AdminPortal().Show();
            ////////////////////////////////////////////
            /////
            String query = "Select * from Login where Username='"+UnameTXT.Text+"' and Password='"+passTXT.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            bool st;
            string portal = "";
            if (dtb.Rows.Count==1)
            {
                String q2= "Select status From Login where Username='" + UnameTXT.Text + "' and Password='" + passTXT.Text + "'";
                SqlDataAdapter sda2 = new SqlDataAdapter(q2, con);
                DataTable dtb2 = new DataTable();
                sda2.Fill(dtb2);
                st = Convert.ToBoolean(dtb2.Rows[0]["status"]);
                if(st==true)
                {
                    String q3 = "Select Role From Login where Username='" + UnameTXT.Text + "' and Password='" + passTXT.Text + "'";
                    SqlDataAdapter sda3 = new SqlDataAdapter(q3, con);
                    DataTable dtb3 = new DataTable();
                    sda3.Fill(dtb3);
                    portal = dtb3.Rows[0]["Role"].ToString();
                    if(portal=="Artist")
                    {
                        this.Hide();
                        new ArtistPortal(UnameTXT.Text,passTXT.Text).Show();
                    }
                    else if(portal=="Audience")
                    {
                        this.Hide();
                        new AudiencePortal(UnameTXT.Text,passTXT.Text).Show();
                    }
                    else if(portal=="Admin"||portal=="Executive")
                    {
                        this.Hide();
                        new AdminPortal(UnameTXT.Text,passTXT.Text).Show();
                    }
                    else
                    {
                        MessageBox.Show("Something Error, Contact with Admins","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }


                }
                else
                {
                    MessageBox.Show("Your Sign Up Request is Still Pending, Wait for Admin Approve", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Wrong Cradential","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

        }

        private void signupBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp().Show();
        }

        private void showPassCHECK_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassCHECK.Checked)
            {
                passTXT.UseSystemPasswordChar = true;
            }
            else passTXT.UseSystemPasswordChar = false;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ForgetPass().Show();
        }
    }
}
