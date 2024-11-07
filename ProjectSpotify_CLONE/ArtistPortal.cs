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
    public partial class ArtistPortal : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-11TTHAE\SQLEXPRESS;Initial Catalog=Spotify_Clone;Integrated Security=True");
        private String ArtistName;
        private string ArtistPass;
        private String ArtistID;
        //for update
        private string firstName;
        private string lastName;
        private string PhoneNo;
        private string SMedia;
        private string EmailID;
        private string StageName;
        private string photoPath;
        //////////Music Upload Elements
        private String Music_Location;
        private String Cover_Location;
        public String tMName = "", tSName = "", file = "", dp = "";
        /////////Code
        public ArtistPortal(String name, string Pass)
        {
            InitializeComponent();
            ArtistName = name;
            ArtistPass = Pass;
        }

        private void back_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            mPlayer1.Ctlcontrols.stop();
        }

        private void ArtistPortal_Load(object sender, EventArgs e)
        {
            updatedDataSource();
            updatedDataSet();
            ArtistName_BTN.Text = "Welcome, "+ArtistName;
            Singer_TXT.Text = ArtistName;
            ArtistDP_PIC.ImageLocation = photoquery();
            ArtistName2_Label.Text = ArtistName;
            TotalMusic_Label.Text = countQuery();
            ArProfilePic.ImageLocation = photoquery();
            ////////////Panel Visibility
            Profile_Panel.Visible = true;
            headPanel.Visible = false;
            Edit_Panel.Visible = false;
            MusicUpload_Panel.Visible = false;
            MyMusic_Panel.Visible = false;
            Tartist_Pnl.Visible = false;


        }
        String countQuery()
        {
            string query = "Select Count(*) from MusicTable where ArtistID='" + ArtistID + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable dta = new DataTable();
            sda.Fill(dta);
            string value = dta.Rows[0][0].ToString();
            return "Total Music:- "+value;

        }
        string photoquery()
        {
            string query = "Select Photo from Artist_Info where Username='" + ArtistName + "' and Password='" + ArtistPass + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            string path="";
            if (dtb.Rows.Count > 0)
            {
                path = dtb.Rows[0]["Photo"].ToString();
            }
            return path;
        }
        void updatedDataSource()
        {
            string query = "Select ArtistID,FirstName, LastName, Phone, StageName,Email, SocialMediaLinks,Photo From Artist_Info where Username='"+ArtistName+"' and Password='"+ArtistPass+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if(dtb.Rows.Count>0)
            {
                firstName = dtb.Rows[0]["FirstName"].ToString();
                lastName = dtb.Rows[0]["LastName"].ToString();
                StageName = dtb.Rows[0]["StageName"].ToString();
                PhoneNo = dtb.Rows[0]["Phone"].ToString();
                EmailID = dtb.Rows[0]["Email"].ToString();
                SMedia = dtb.Rows[0]["SocialMediaLinks"].ToString();
                photoPath = dtb.Rows[0]["Photo"].ToString();
                ArtistID = dtb.Rows[0]["ArtistID"].ToString();
                Email_Id.Text = EmailID;
            }
        }
        void updatedDataSet()
        {
            First_Name.Text = firstName;
            Last_Name.Text = lastName;
            Phone.Text = PhoneNo;
            SocialMedia.Text = SMedia;
            Stage_Name.Text = StageName;
            EditableDP.ImageLocation = photoPath;
            User_Name.Text = ArtistName;
            Password.Text = ArtistPass;

        }

        private void ArtistPortal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void profile_BTN_Click(object sender, EventArgs e)
        {
            Profile_Panel.Visible = true;
            headPanel.Visible = false;
            Edit_Panel.Visible = false;
            MusicUpload_Panel.Visible = false;
            MyMusic_Panel.Visible = false;
            Tartist_Pnl.Visible = false;

            TotalMusic_Label.Text = countQuery();
        }

        private void explore_BTN_Click(object sender, EventArgs e)
        {
            MusicUpload_Panel.Visible = false;
            headPanel.Visible = true;
            Tartist_Pnl.Visible = true;
            Profile_Panel.Visible = false;
            Edit_Panel.Visible = false;
            MyMusic_Panel.Visible = false;

            trendMusic();
            topMusicDataSource();
            //axWindowsMediaPlayer1.Ctlcontrols.stop();
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
        void topMusicDataSource()
        {
            string query = "Select MusicID,MusicTitle,Singer,Genres,FileName,CoverPage from MusicTable order by PlayCount Desc";
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
        private void Edit_BTN_Click(object sender, EventArgs e)
        {
            Edit_Panel.Visible = true;
            headPanel.Visible = true;
            MusicUpload_Panel.Visible = false;
            Profile_Panel.Visible = false;
            MyMusic_Panel.Visible = false;
            Tartist_Pnl.Visible = false;
        }

        private void Edit_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void First_Name_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void User_Name_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void changePicBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            open.Title = "Select an Image File";
            if (open.ShowDialog() == DialogResult.OK)
            {
                photoPath = open.FileName;
                MessageBox.Show("File Selected: " + photoPath,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                EditableDP.ImageLocation = photoPath;
            }
            //dp_PicBox.ImageLocation = dpFilePath;
        }
        void finalUpdate()
        {
            String query00 = "Update Artist_Info set FirstName='" + First_Name.Text + "', LastName='" + Last_Name.Text + "', Phone='" + Phone.Text + "', StageName='" + Stage_Name.Text + "',Email='" + Email_Id.Text + "', SocialMediaLinks='" + SocialMedia.Text + "',Photo='" + photoPath + "' where Username= '" + ArtistName + "' and Password='" + ArtistPass + "'";
            SqlCommand cmd = new SqlCommand(query00,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            string query11 = "Update User_Info set FirstName='" + First_Name.Text + "', LastName='" + Last_Name.Text + "', Phone='" + Phone.Text + "', Email='" + Email_Id.Text + "' where Username='"+ArtistName+"' and Password='"+ArtistPass+"'";
            SqlCommand cmd2 = new SqlCommand(query11, con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Information Updated Successfully, Please Login Again.","Success",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            this.Hide();
            new LoginForm().Show();
        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            finalUpdate();
        }

        private void urMusic_BTN_Click(object sender, EventArgs e)
        {
            Profile_Panel.Visible = false;
            headPanel.Visible = false;
            Edit_Panel.Visible = false;
            MusicUpload_Panel.Visible = false;
            MyMusic_Panel.Visible = true;
            Tartist_Pnl.Visible = false;
            MyMusicDataSource();
            MyMusic_DGV.Refresh();
        }

        private void uploadNew_BTN_Click(object sender, EventArgs e)
        {
            Profile_Panel.Visible = false;
            Edit_Panel.Visible = false;
            headPanel.Visible = true;
            MusicUpload_Panel.Visible = true;
            MyMusic_Panel.Visible = false;
            Tartist_Pnl.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Audio Files|*.mp3;*.wav;*.wma;*.flac";
            open.Title = "Select a Music File";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Music_Location = open.FileName;
                MessageBox.Show("File Selected: " + Music_Location, "Music Selected", MessageBoxButtons.OK, MessageBoxIcon.None);
                MusicFile_TXT.Text = Music_Location;
            }

        }

        private void CoverUpload_BTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            open.Title = "Select an Image File";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Cover_Location = open.FileName;
                MessageBox.Show("File Selected: " + Cover_Location, "Cover Photo Selected", MessageBoxButtons.OK, MessageBoxIcon.None);
                CoverPage_Picture.ImageLocation = Cover_Location;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(CoverPage_Picture.ImageLocation) ||
                String.IsNullOrWhiteSpace(Title_Txt.Text) ||
                String.IsNullOrWhiteSpace(Composer_TXT.Text) ||
                String.IsNullOrWhiteSpace(Genre_TXT.Text)||
                String.IsNullOrWhiteSpace(Language_TXT.Text))
            {
                MessageBox.Show("Fill All Section Including Cover Photo", "Fill Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query1="Insert into MusicTable values('"+Title_Txt.Text+"','"+ArtistName+"','"+Composer_TXT.Text+"','"+Genre_TXT.Text+"','"+Language_TXT.Text+"','"+Music_Location+"',0,'"+Cover_Location+"',0,'"+ArtistID+"')";
            SqlCommand cmd = new SqlCommand(query1,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            String query2 = "Select top 1 MusicID from MusicTable where ArtistID='"+ArtistID+"' Order by MusicID desc";
            SqlDataAdapter sda = new SqlDataAdapter(query2, con);
            DataTable dtb = new DataTable();
            string temp="";
            sda.Fill(dtb);
            if(dtb.Rows.Count>0)
            {
                temp = dtb.Rows[0]["MusicID"].ToString();
            }
            string query3 = "Insert into ArtistMusic values('" + ArtistID + "','" + temp + "')";
            SqlCommand cmd2 = new SqlCommand(query3, con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Music Successfully Published","Uploaded",MessageBoxButtons.OK,MessageBoxIcon.Information);
            CoverPage_Picture.ImageLocation = null;
            MusicFile_TXT.Clear();
            Language_TXT.Clear();
            Title_Txt.Clear();
            Composer_TXT.Clear();
            Genre_TXT.Clear();
            MyMusic_DGV.Refresh();

        }
        void MyMusicDataSource()
        {
            string query = "Select MusicID,MusicTitle, PlayCount, Genres,FileName, CoverPage From MusicTable where ArtistID='" + ArtistID + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            sda.Fill(table);
            MyMusic_DGV.DataSource = table;
            MyMusic_DGV.Columns["CoverPage"].Visible = false;
            MyMusic_DGV.Columns["FileName"].Visible = false;
            MyMusic_DGV.Columns["MusicID"].Visible = false;

            //creating a coverpage image collumn
            if (!MyMusic_DGV.Columns.Contains("Cover Photo"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                {
                    Name = "Cover Photo",
                    HeaderText = "Images",
                    ImageLayout = DataGridViewImageCellLayout.Stretch
                };
                MyMusic_DGV.Columns.Insert(0, imgCol);
                MyMusic_DGV.Columns[0].Width = 80;
            }
            if (!MyMusic_DGV.Columns.Contains("Delete Song"))
            {
                DataGridViewImageColumn imgCol2 = new DataGridViewImageColumn
                {
                    Name = "Delete Song",
                    HeaderText = "Delete",
                    ImageLayout = DataGridViewImageCellLayout.Normal
                };
                MyMusic_DGV.Columns.Insert(6, imgCol2);
                MyMusic_DGV.Columns[6].Width = 60;
            }
            if(!MyMusic_DGV.Columns.Contains("Play Song"))
            {
                DataGridViewImageColumn imgcol3 = new DataGridViewImageColumn();
                imgcol3.Name = "Play Song";
                imgcol3.HeaderText = "Play";
                imgcol3.ImageLayout = DataGridViewImageCellLayout.Normal;
                MyMusic_DGV.Columns.Insert(5,imgcol3);
                MyMusic_DGV.Columns[5].Width = 60;
            }
            if (!MyMusic_DGV.Columns.Contains("Total Report"))
            {
                DataGridViewTextBoxColumn textCol = new DataGridViewTextBoxColumn();
                textCol.Name = "Total Report";
                textCol.HeaderText = "Total Report";
                //textCol.ImageLayout = DataGridViewImageCellLayout.Normal;
                MyMusic_DGV.Columns.Insert(6, textCol);
                MyMusic_DGV.Columns[6].Width = 120;
            }
            if (!MyMusic_DGV.Columns.Contains("Premium"))
            {
                DataGridViewImageColumn imgcol3 = new DataGridViewImageColumn();
                imgcol3.Name = "Premium";
                imgcol3.HeaderText = "Add To Premium";
                imgcol3.ImageLayout = DataGridViewImageCellLayout.Normal;
                MyMusic_DGV.Columns.Insert(7, imgcol3);
                MyMusic_DGV.Columns[7].Width = 60;
            }
            foreach (DataGridViewRow row in MyMusic_DGV.Rows)
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
                        row.Cells["cPhoto"].Value = null;
                    }
                }
                if(row.Cells["Delete Song"].Value==null)

                {
                    string image = @"F:\AIUB Semester 6\Object Oriented Programming 2 (C#)\Final Term\Project-Spotify\Images\delete.png";
                    if (System.IO.File.Exists(image))
                    {
                        row.Cells["Delete Song"].Value = Image.FromFile(image);
                    }
                    else row.Cells["Delete Song"].Value = null;
                }
                if(row.Cells["Play Song"].Value==null)
                {
                    String image = @"F:\AIUB Semester 6\Object Oriented Programming 2 (C#)\Final Term\Project-Spotify\Images\playMusic.png";
                    if (System.IO.File.Exists(image))
                    {
                        row.Cells["Play Song"].Value = Image.FromFile(image);
                    }
                    else row.Cells["Play Song"].Value = null;

                }
                if (row.Cells["Total Report"].Value == null)
                {
                    string mID = row.Cells["MusicID"].Value.ToString();

                    string query7 = "Select count(*) from ReportMusic where MusicID='" + mID + "'";
                    SqlDataAdapter sda7 = new SqlDataAdapter(query7, con);
                    DataTable dtb7 = new DataTable();
                    sda7.Fill(dtb7);
                    string value = dtb7.Rows[0][0].ToString();
                    if (value != "0")
                    {
                        row.Cells["Total Report"].Value = value;
                    }
                    else row.Cells["Total Report"].Value = "0";
                }
                if (row.Cells["Premium"].Value == null)
                {
                    String image = @"F:\AIUB Semester 6\Object Oriented Programming 2 (C#)\Final Term\Project-Spotify\Images\addTopre.png";
                    if (System.IO.File.Exists(image))
                    {
                        row.Cells["Premium"].Value = Image.FromFile(image);
                    }
                    else row.Cells["Premium"].Value = null;

                }
            }

        }
        String listeningMusic;
        String musicID;
        private void MyMusic_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MyMusic_DGV.Columns[e.ColumnIndex].Name == "Delete Song")
            {
                int rowIndex = e.RowIndex;
                String musicNo = MyMusic_DGV.Rows[rowIndex].Cells["MusicID"].Value.ToString();
                var result = MessageBox.Show("Are You sure about deleting this music?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    deleteMusic(musicNo);
                }
                else return;
            }
            if(MyMusic_DGV.Columns[e.ColumnIndex].Name=="Play Song")
            {
                int rowIndex = e.RowIndex;
                listeningMusic = MyMusic_DGV.Rows[rowIndex].Cells["FileName"].Value.ToString();
                musicID= MyMusic_DGV.Rows[rowIndex].Cells["MusicID"].Value.ToString();
                MusicPlayer(listeningMusic,musicID);
            }
            if(MyMusic_DGV.Columns[e.ColumnIndex].Name=="Premium")
            {
                int rowIndex = e.RowIndex;
                int count = Convert.ToInt32(MyMusic_DGV.Rows[rowIndex].Cells["PlayCount"].Value);
                string musictitle = MyMusic_DGV.Rows[rowIndex].Cells["MusicTitle"].Value.ToString();
                int aID = Convert.ToInt32(ArtistID);
                int musicNo= Convert.ToInt32(MyMusic_DGV.Rows[rowIndex].Cells["MusicID"].Value);

                ////find Artist in Premium list
                string findArtist = "Select ArtistID from PremiumArtist where ArtistID='" + aID + "'";
                SqlDataAdapter find = new SqlDataAdapter(findArtist, con);
                int x = 0;
                DataTable findt = new DataTable();
                find.Fill(findt);
                if (findt.Rows.Count < 1)
                {
                    string addArtist = "Insert into PremiumArtist values('" + aID + "','"+x+"')";
                    SqlCommand addcmd = new SqlCommand(addArtist, con);
                    con.Open();
                    addcmd.ExecuteNonQuery();
                    con.Close();
                }


                string q = "Select MusicID from PremiumList where MusicID='" + musicNo + "'";
                SqlDataAdapter sddd = new SqlDataAdapter(q, con);
                DataTable dttt = new DataTable();
                sddd.Fill(dttt);
                if(dttt.Rows.Count>0)
                {
                    MessageBox.Show("This Music is Already been Added", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (count >= 10)
                    {
                        string query = "Insert Into PremiumList values('" + musicNo + "','" + musictitle + "','" + aID + "')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        string update = "Update PremiumArtist set NumberOfMusic=NumberOfMusic+1 where ArtistID='" + aID + "'";
                        SqlCommand cmd2 = new SqlCommand(update,con);
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Music is Added Successfully in Premium List", "Successfully Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("You can't add this music in premium list because of few playcount [At least 10 Playcount needed for adding in list]", "Limitation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }   
            }
            
        }
        private void MusicPlayer(String name,string musicNo)
        {
            axWindowsMediaPlayer1.URL = name;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            //string query = "Update MusicTable set PlayCount= PlayCount+1 where MusicID='" + musicNo + "'";
            //SqlCommand cmd = new SqlCommand(query, con);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mPlayer1.URL = file;
            mPlayer1.Ctlcontrols.play();
        }

        private void Tartist_Pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void deleteMusic(String MusicNo)
        {
            String delQuery1="DELETE FROM ArtistMusic WHERE MusicID = '"+MusicNo+"'";
            String delQuery2="DELETE FROM MusicTable WHERE ArtistID = '"+ArtistID+"' AND MusicID = '"+MusicNo+"'";
            SqlCommand cmd = new SqlCommand(delQuery1,con);
            SqlCommand cmd2 = new SqlCommand(delQuery2, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con.Close();
            MyMusicDataSource();

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
    }
}
