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
    public partial class PaymentValidation : Form
    {
        private string AudienceName;
        private string AudiencePass;
        private string package;
        private string money;
        private string method;
        public PaymentValidation(String aName,String aPass,string pack,string money,string method)
        {
            AudiencePass = aPass;
            AudienceName = aName;
            package = pack;
            this.money = money;
            this.method = method;
            InitializeComponent();
        }

        private void buttonGenerateInvoice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Still under Developement","Not Available Feature",MessageBoxButtons.OK,MessageBoxIcon.Information);
            return;
        }

        private void PaymentValidation_Load(object sender, EventArgs e)
        {

        }

        private void backtoHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AudiencePortal(AudienceName, AudiencePass).Show();
        }
    }
}
