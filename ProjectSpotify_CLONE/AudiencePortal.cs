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
    public partial class AudiencePortal : Form
    {
        private String AudienceName;
        private String AudiencePassword;
        private int AudienceID;
        private bool isPremium=false;
        //private String AudiencePhoto;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-11TTHAE\SQLEXPRESS;Initial Catalog=Spotify_Clone;Integrated Security=True");
        public AudiencePortal(String auName, String auPass)
        {
            AudienceName = auName;
            AudiencePassword = auPass;
            InitializeComponent();
            string q = "Select AudienceID from Audience_Info where Username='" + AudienceName + "' and Password='" + AudiencePassword + "'";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataTable t = new DataTable();
            sda.Fill(t);
            AudienceID = Convert.ToInt32(t.Rows[0]["AudienceID"]);
            String q2 = "Select Count(*) from Subscription where AudienceID='"+AudienceID+"'";
            SqlDataAdapter sda2 = new SqlDataAdapter(q2, con);
            DataTable t3 = new DataTable();
            sda2.Fill(t3);
            if(Convert.ToInt32(t3.Rows[0][0])==1)
            {
                isPremium = true;
            }
        }

        private void recent_BTN_Click(object sender, EventArgs e)
        {

        }

        private void explore_BTN_Click(object sender, EventArgs e)
        {
            Tartist_Pnl.Visible = true;
            head_Panel.Visible = true;
            AllMusic_Panel.Visible = false;
            artistPanel.Visible = false;
            Subscription_Panel.Visible = false;
            trendMusic();
            topMusicDataSource();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void genre_BTN_Click(object sender, EventArgs e)
        {
            Tartist_Pnl.Visible = false;
            head_Panel.Visible = false;
            AllMusic_Panel.Visible = true;
            artistPanel.Visible = false;
            Subscription_Panel.Visible = false;

            mPlayer1.Ctlcontrols.stop();
            AllMusicDataSource();
        }
        void AllMusicDataSource()
        {
            string query="Select MusicID,MusicTitle,Singer,Genres,FileName,CoverPage from MusicTable order by Newid()";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            AllMusic_DGV.DataSource = dtb;
            AllMusic_DGV.Columns["MusicID"].Visible = false;
            AllMusic_DGV.Columns["FileName"].Visible = false;
            AllMusic_DGV.Columns["CoverPage"].Visible = false;

            ///column Adding
            if (!AllMusic_DGV.Columns.Contains("Cover Photo"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                {
                    Name = "Cover Photo",
                    HeaderText = "Cover",
                    ImageLayout = DataGridViewImageCellLayout.Stretch
                };
                AllMusic_DGV.Columns.Insert(0, imgCol);
                AllMusic_DGV.Columns[0].Width = 80;
            }
            if (!AllMusic_DGV.Columns.Contains("Play Song"))
            {
                DataGridViewImageColumn imgcol3 = new DataGridViewImageColumn();
                imgcol3.Name = "Play Song";
                imgcol3.HeaderText = "Play";
                imgcol3.ImageLayout = DataGridViewImageCellLayout.Normal;
                AllMusic_DGV.Columns.Insert(5, imgcol3);
                AllMusic_DGV.Columns[5].Width = 60;
            }
            if (!AllMusic_DGV.Columns.Contains("Report Song"))
            {
                DataGridViewImageColumn imgcol4 = new DataGridViewImageColumn();
                imgcol4.Name = "Report Song";
                imgcol4.HeaderText = "Report";
                imgcol4.ImageLayout = DataGridViewImageCellLayout.Normal;
                AllMusic_DGV.Columns.Insert(6, imgcol4);
                AllMusic_DGV.Columns[6].Width = 60;
            }
            foreach (DataGridViewRow row in AllMusic_DGV.Rows)
            {
                //row.Height = 100;
                if (row.Cells["Cover Photo"].Value == null)
                {
                    string imagePath = row.Cells["CoverPage"].Value.ToString();
                    if (System.IO.File.Exists(imagePath))
                    {
                        row.Cells["Cover Photo"].Value = Image.FromFile(imagePath);
                    }
                    else
                    {
                        row.Cells["Cover Photo"].Value = null;
                    }
                }
                if (row.Cells["Play Song"].Value == null)
                {
                    String image = @"F:\AIUB Semester 6\Object Oriented Programming 2 (C#)\Final Term\Project-Spotify\Images\playMusic.png";
                    if (System.IO.File.Exists(image))
                    {
                        row.Cells["Play Song"].Value = Image.FromFile(image);
                    }
                    else row.Cells["Play Song"].Value = null;
                }
                if (row.Cells["Report Song"].Value == null)
                {
                    String image = @"F:\AIUB Semester 6\Object Oriented Programming 2 (C#)\Final Term\Project-Spotify\Images\report.png";
                    if (System.IO.File.Exists(image))
                    {
                        row.Cells["Report Song"].Value = Image.FromFile(image);
                    }
                    else row.Cells["Report Song"].Value = null;
                }
            }
        }
        void topMusicDataSource()
        {
            string query = "Select Top 10 MusicID,MusicTitle,Singer,Genres,FileName,CoverPage from MusicTable order by PlayCount Desc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            TopMusic_DGV.DataSource = dtb;
            TopMusic_DGV.Columns["MusicID"].Visible = false;
            TopMusic_DGV.Columns["FileName"].Visible = false;
            TopMusic_DGV.Columns["CoverPage"].Visible = false;

            ///column Adding
            if (!TopMusic_DGV.Columns.Contains("Cover Photo"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                {
                    Name = "Cover Photo",
                    HeaderText = "Cover",
                    ImageLayout = DataGridViewImageCellLayout.Stretch
                };
                TopMusic_DGV.Columns.Insert(0, imgCol);
                TopMusic_DGV.Columns[0].Width = 80;
            }
            if (!TopMusic_DGV.Columns.Contains("Play Song"))
            {
                DataGridViewImageColumn imgcol3 = new DataGridViewImageColumn();
                imgcol3.Name = "Play Song";
                imgcol3.HeaderText = "Play";
                imgcol3.ImageLayout = DataGridViewImageCellLayout.Normal;
                TopMusic_DGV.Columns.Insert(5, imgcol3);
                TopMusic_DGV.Columns[5].Width = 60;
            }
            foreach (DataGridViewRow row in TopMusic_DGV.Rows)
            {
                //row.Height = 100;
                if (row.Cells["Cover Photo"].Value == null)
                {
                    string imagePath = row.Cells["CoverPage"].Value.ToString();
                    if (System.IO.File.Exists(imagePath))
                    {
                        row.Cells["Cover Photo"].Value = Image.FromFile(imagePath);
                    }
                    else
                    {
                        row.Cells["Cover Photo"].Value = null;
                    }
                }
                if (row.Cells["Play Song"].Value == null)
                {
                    String image = @"F:\AIUB Semester 6\Object Oriented Programming 2 (C#)\Final Term\Project-Spotify\Images\playMusic.png";
                    if (System.IO.File.Exists(image))
                    {
                        row.Cells["Play Song"].Value = Image.FromFile(image);
                    }
                    else row.Cells["Play Song"].Value = null;

                }
            }
        }

        private void live_BTN_MouseEnter(object sender, EventArgs e)
        {
            live_BTN.ForeColor = Color.FromArgb(0, 120, 215);
        }

        private void music_BTN_MouseLeave(object sender, EventArgs e)
        {
            music_BTN.ForeColor = Color.FromArgb(125, 125, 125);
        }

        private void podcast_BTN_MouseLeave(object sender, EventArgs e)
        {
            podcast_BTN.ForeColor= Color.FromArgb(125, 125, 125);
        }

        private void live_BTN_MouseLeave(object sender, EventArgs e)
        {
            live_BTN.ForeColor= Color.FromArgb(125, 125, 125);
        }

        private void music_BTN_MouseEnter_1(object sender, EventArgs e)
        {
            music_BTN.ForeColor= Color.FromArgb(0, 120, 215);
        }

        private void podcast_BTN_MouseEnter(object sender, EventArgs e)
        {
            podcast_BTN.ForeColor = Color.FromArgb(0, 120, 215);
        }

        private void music_BTN_Click(object sender, EventArgs e)
        {

        }

        private void search_TBOX_Enter(object sender, EventArgs e)
        {
            //if (search_TBOX.Text == "Search")
            //{
            //    search_TBOX.Text = "";
            //    search_TBOX.ForeColor = Color.Black;
            //}
        }

        private void search_TBOX_MouseLeave(object sender, EventArgs e)
        {
            //if (search_TBOX.Text == "")
            //{
            //    search_TBOX.Text = "Search";
            //    search_TBOX.ForeColor = Color.FromArgb(125,125,125);
            //}
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }


        public String tMName = "", tSName = "", file = "", dp = "";

        private void button2_Click(object sender, EventArgs e)
        {
            mPlayer1.URL = file;
            mPlayer1.Ctlcontrols.play();
        }
        private void playMusic(String file)
        {
            mPlayer1.URL = file;
            mPlayer1.Ctlcontrols.play();
        }
        private void playCountIncrement(int a)
        {
            string query = "Update MusicTable set PlayCount=PlayCount+1 where MusicID=a";
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
        }

        private void userName_BTN_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void back_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();new LoginForm().Show();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void AudiencePortal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
        String listeningMusic, musicID;
        
        private void AllMusic_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AllMusic_DGV.Columns[e.ColumnIndex].Name == "Play Song")
            {
                int rowIndex = e.RowIndex;
                listeningMusic = AllMusic_DGV.Rows[rowIndex].Cells["FileName"].Value.ToString();
                musicID = AllMusic_DGV.Rows[rowIndex].Cells["MusicID"].Value.ToString();
                string query45 = "Select * from PremiumList where MusicID='" + musicID + "'";
                SqlDataAdapter sda45 = new SqlDataAdapter(query45, con);
                DataTable dtb45 = new DataTable();
                sda45.Fill(dtb45);
                if (dtb45.Rows.Count==1 && isPremium == true)
                {
                    MusicPlayer(listeningMusic, musicID);
                }
                else if (dtb45.Rows.Count == 1 && isPremium == false)
                {
                    MessageBox.Show("This is a Premium Music, To listen it buy our subscription", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                   
                }
                else if(dtb45.Rows.Count==0)
                {
                    MusicPlayer(listeningMusic, musicID);
                }
                
            }
            if (AllMusic_DGV.Columns[e.ColumnIndex].Name == "Report Song")
            {
                int rowindex2 = e.RowIndex;
                var result=MessageBox.Show("Are You Sure for Report","Report",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string uploadername= AllMusic_DGV.Rows[rowindex2].Cells["Singer"].Value.ToString();
                    int mID = Convert.ToInt32(AllMusic_DGV.Rows[rowindex2].Cells["MusicID"].Value);
                    string title = AllMusic_DGV.Rows[rowindex2].Cells["MusicTitle"].Value.ToString();
                    string query = "Insert into ReportMusic values('" + AudienceName + "','" + uploadername + "','" + mID + "','" + AudienceID + "','"+ title + "')";
                    SqlCommand cmd = new SqlCommand(query,con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Your Report Has Been Sent to Admin", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AllMusicDataSource();

                }
                else return;
            }
        }
        
        private void MusicPlayer(String name, string musicNo)
        {
            axWindowsMediaPlayer1.URL = name;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            string query = "Update MusicTable set PlayCount= PlayCount+1 where MusicID='" + musicNo + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void mPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void TopMusic_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TopMusic_DGV.Columns[e.ColumnIndex].Name == "Play Song")
            {
                int rowIndex = e.RowIndex;
                listeningMusic = TopMusic_DGV.Rows[rowIndex].Cells["FileName"].Value.ToString();
                musicID = TopMusic_DGV.Rows[rowIndex].Cells["MusicID"].Value.ToString();
                MusicPlayer2(listeningMusic, musicID);
            }
        }
        private void MusicPlayer2(String name, string musicNo)
        {
            mPlayer1.URL = name;
            mPlayer1.Ctlcontrols.play();
            string query = "Update MusicTable set PlayCount= PlayCount+1 where MusicID='" + musicNo + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "Search Music")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search Music";
                textBox1.ForeColor = Color.FromArgb(125,125,125);
            }
        }

        private void artist_BTN_Click(object sender, EventArgs e)
        {
            Tartist_Pnl.Visible = false;
            head_Panel.Visible = true;
            AllMusic_Panel.Visible = false;
            artistPanel.Visible = true;
            Subscription_Panel.Visible = false;
            topArtistDataSource();
        }

        /////Top Artist DataSource//////////

        private void topArtistDataSource()
        {
            string query = "Select top 7 A.Photo as Picture from MusicTable M join Artist_Info A on M.Singer=A.Username Group by A.Photo, M.Singer order by sum(M.PlayCount) desc ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            DataTable flippedTable = new DataTable();

            // Add five columns
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                flippedTable.Columns.Add("Column " + (i + 1), typeof(Image));
            }

            DataRow singerRow = flippedTable.NewRow();
            DataRow followRow = flippedTable.NewRow();

            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                string imagePath = dtb.Rows[i]["Picture"].ToString();
                if (System.IO.File.Exists(imagePath))
                {
                    singerRow[i] = Image.FromFile(imagePath);
                }
                else
                {
                    singerRow[i] = null;
                }

                string followImagePath = @"F:\AIUB Semester 6\Object Oriented Programming 2 (C#)\Final Term\Project-Spotify\Images\follow.png";
                if (System.IO.File.Exists(followImagePath))
                {
                    followRow[i] = Image.FromFile(followImagePath);
                }
                else
                {
                    followRow[i] = null;
                }
            }

            flippedTable.Rows.Add(singerRow);
            flippedTable.Rows.Add(followRow);

            topArtist_DGV.DataSource = flippedTable;

            // Hide headers
            topArtist_DGV.ColumnHeadersVisible = false;
            topArtist_DGV.RowHeadersVisible = false;

            // Adjust column widths and add gaps
            int gap = 20; // Define the gap size
            foreach (DataGridViewColumn column in topArtist_DGV.Columns)
            {
                column.Width = 80 + gap; // Set column width plus gap
            }

            // Set row heights
            topArtist_DGV.RowTemplate.Height = 80;
            topArtist_DGV.Rows[0].Height = 80;
            topArtist_DGV.Rows[1].Height = 80;

            // Set image layout
            foreach (DataGridViewColumn column in topArtist_DGV.Columns)
            {
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)column;
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

            // Set the CellBorderStyle to None for better visuals
            topArtist_DGV.CellBorderStyle = DataGridViewCellBorderStyle.None;
        }

        private void AllMusic_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void SubsMonthly_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Payment(AudienceName, AudiencePassword, AudienceID, "Monthly",200).Show();
        }

        private void SubsWeekly_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Payment(AudienceName, AudiencePassword, AudienceID, "Weekly", 80).Show();
        }

        private void SubsYearly_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Payment(AudienceName, AudiencePassword, AudienceID, "Yearly", 2000).Show();
        }

        private void Subscription_BTN_Click(object sender, EventArgs e)
        {
            Tartist_Pnl.Visible = false;
            head_Panel.Visible = true;
            AllMusic_Panel.Visible = false;
            artistPanel.Visible = false;
            Subscription_Panel.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //(AllMusic_DGV.DataSource as DataTable).DefaultView.RowFilter = string.Format("MusicTitle like '%"+textBox1.Text+"%'");
        }
        String photoquery(String name, String pass)
        {
            string path = "";
            string query = "Select Photo From Audience_Info where Username='" + name + "' and Password='"+pass+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if(dtb.Rows.Count>0)
            {
                path = dtb.Rows[0]["Photo"].ToString();
            }
            return path;

        }
        private void AudiencePortal_Load(object sender, EventArgs e)
        {
            userName_BTN.Text = "Welcome, " + AudienceName;
            string path = photoquery(AudienceName, AudiencePassword);
            userDP_PIC.ImageLocation = path;

            trendMusic();
            topMusicDataSource();
            
            Tartist_Pnl.Visible = true;
            head_Panel.Visible = true;
            AllMusic_Panel.Visible = false;
            artistPanel.Visible = false;
            Subscription_Panel.Visible = false;
            ///is Premium or not??
            string query = "Select * from Subscription where AudienceID='" + AudienceID + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if(dtb.Rows.Count>0)
            {
                Subscription_BTN.Visible = false;
                pictureBox7.Visible = false;
                premiumPic.Visible = true;
            }
            else
            {
                Subscription_BTN.Visible = true;
                pictureBox7.Visible = true;
                premiumPic.Visible = false;
            }

            
        }
        void trendMusic()
        {
            String query1 = "select MusicTitle,Singer,FileName,CoverPage from MusicTable where PlayCount=(select max(PlayCount) from MusicTable)";
            SqlDataAdapter sda = new SqlDataAdapter(query1, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if (dtb.Rows.Count == 1)
            {
                tMName = dtb.Rows[0]["MusicTitle"].ToString();
                tSName = dtb.Rows[0]["Singer"].ToString();
                file = dtb.Rows[0]["FileName"].ToString();
                dp = dtb.Rows[0]["CoverPage"].ToString();

                trMusicName_Lbl.Text = tMName;
                trArtist_Lbl.Text = tSName;
                trApic_PBOX.Image = Image.FromFile(dp);
            }
            else
            {
                trMusicName_Lbl.Text = "Music Name";
                trArtist_Lbl.Text = "Artist Name";
                trApic_PBOX.Image = Image.FromFile(@"F:\AIUB Semester 6\Object Oriented Programming 2 (C#)\Final Term\Project-Spotify\Images\profile_48.png");
            }
        }
        //void datashow()
        //{
        //    string query2 = "Select top 20 MusicID,CoverPage,MusicTitle,Singer,FileName from MusicTable order by PlayCount Desc";
        //    SqlDataAdapter sda = new SqlDataAdapter(query2, con);
        //    DataTable dtb = new DataTable();
        //    sda.Fill(dtb);
        //    topChartsData_DGV.DataSource = dtb;
        //    topChartsData_DGV.Columns["FileName"].Visible = false;
        //    topChartsData_DGV.Columns["MusicID"].Visible = false;
        //}
        //private void addButton()
        //{
        //    if(topChartsData_DGV.Columns["Play"]==null)
        //    {
        //        //Image playIcon = Image.FromFile(@"F:\AIUB Semester 6\Object Oriented Programming 2 (C#)\Final Term\Project-Spotify\Images\pBLUE32.png");
        //        DataGridViewButtonColumn play = new DataGridViewButtonColumn();
        //        play.HeaderText = "Play Music";
        //        play.Text = "Play";
        //        play.Name = "Play";
        //        play.UseColumnTextForButtonValue = true;
        //        //play.Image = playIcon;
        //        topChartsData_DGV.Columns.Add(play);
        //    }
        //    if(topChartsData_DGV.Columns["Favourite"]==null)
        //    {
        //        DataGridViewButtonColumn fav = new DataGridViewButtonColumn();
        //        fav.HeaderText = "Add to Favourite";
        //        fav.Text = "Favourite";
        //        fav.Name = "Favourite";
        //        fav.UseColumnTextForButtonValue = true;
        //        topChartsData_DGV.Columns.Add(fav);
        //    }
        //    if(topChartsData_DGV.Columns["Add_To"]==null)
        //    {
        //        DataGridViewButtonColumn add = new DataGridViewButtonColumn();
        //        add.HeaderText = "Add to playlist";
        //        add.Text = "Add To";
        //        add.Name = "Add_To";
        //        add.UseColumnTextForButtonValue = true;
        //        topChartsData_DGV.Columns.Add(add);
        //    }
        //}
    }
}
