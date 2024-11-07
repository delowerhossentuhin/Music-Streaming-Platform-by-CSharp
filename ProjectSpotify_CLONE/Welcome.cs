using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSpotify_CLONE
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void login_Btn_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void signup_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp().Show();
        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void aboutus_Btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AboutUs().Show();
        }
    }
}
