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
    public partial class Payment : Form
    {
        private String AudienceName;
        private string AudiencePass;
        private string Package;
        private int AudienceId;
        private int money;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-11TTHAE\SQLEXPRESS;Initial Catalog=Spotify_Clone;Integrated Security=True");
        public Payment(String aname,String pass, int aID,String pack,int money )
        {
            AudienceId = aID;
            AudienceName = aname;
            //PayMethod = pMethod;
            AudiencePass = pass;
            Package = pack;
            this.money = money;
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            totalTK.Text = money.ToString()+" TK";
            validUntil_Panel.Visible = false;
        }
        string selectedPaymentMethod;
        private void payMethod_Combe_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPaymentMethod = payMethod_Combe.SelectedItem.ToString();

            if (selectedPaymentMethod == "Credit Card" || selectedPaymentMethod == "Debit Card")
            {
                cardNumber_Label.Text = "Card Number";
                validUntil_Panel.Visible = true;
            }
            else if (selectedPaymentMethod == "Bkash" || selectedPaymentMethod == "Nagad")
            {
                cardNumber_Label.Text = "Contact Number";
            }

            if (selectedPaymentMethod == "Credit Card" || selectedPaymentMethod == "Debit Card")
            {
                CVV_Label.Text = "CVV";
            }
            else if (selectedPaymentMethod == "Bkash" || selectedPaymentMethod == "Nagad")
            {
                CVV_Label.Text = "Pin";
                validUntil_Panel.Visible = false;
            }
            // Hide all PictureBoxes initially  
            ammex_pictureBox.Visible = false;
            master_card_pictureBox.Visible = false;
            visa_pictureBox.Visible = false;
            unionpay_pictureBox.Visible = false;
            nexuspay_pictureBox.Visible = false;
            bkash_pictureBox.Visible = false;
            nagad_pictureBox.Visible = false;

            // Show and position PictureBoxes based on the selected payment method  
            if (selectedPaymentMethod == "Credit Card")
            {
                ammex_pictureBox.Visible = true;
                master_card_pictureBox.Visible = true;
                visa_pictureBox.Visible = true;
                unionpay_pictureBox.Visible = true;
            }
            else if (selectedPaymentMethod == "Debit Card")
            {
                ammex_pictureBox.Visible = true;
                master_card_pictureBox.Visible = true;
                visa_pictureBox.Visible = true;
                unionpay_pictureBox.Visible = true;
                nexuspay_pictureBox.Visible = true;
            }
            else if (selectedPaymentMethod == "Bkash")
            {
                bkash_pictureBox.Location = ammex_pictureBox.Location; // Position pictureBox6 in the same location as pictureBox1  
                bkash_pictureBox.Visible = true;
            }
            else if (selectedPaymentMethod == "Nagad")
            {
                nagad_pictureBox.Location = ammex_pictureBox.Location; // Position pictureBox7 in the same location as pictureBox1  
                nagad_pictureBox.Visible = true;
            }

        }

        private void Back_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AudiencePortal(AudienceName, AudiencePass).Show();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if(payMethod_Combe.SelectedItem==null||
                    String.IsNullOrWhiteSpace(firstName_Txt.Text)||
                    string.IsNullOrWhiteSpace(lastName_Txt.Text)||
                    string.IsNullOrWhiteSpace(email_Txt.Text)||
                    string.IsNullOrWhiteSpace(card_TXT.Text)||
                    string.IsNullOrWhiteSpace(pinCVV_TXT.Text))
            {
                MessageBox.Show("Fill Up All");
                return;
            }

            string query = "Insert into Subscription values('" + selectedPaymentMethod + "','" + AudienceId + "','" + Package + "','" + money + "')";
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            this.Hide();
            new PaymentValidation(AudienceName, AudiencePass, Package, selectedPaymentMethod, money.ToString()).Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
