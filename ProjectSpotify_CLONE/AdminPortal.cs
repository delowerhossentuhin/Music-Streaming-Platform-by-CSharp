using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace ProjectSpotify_CLONE
{
    public partial class AdminPortal : Form
    {
        private String AdminName;
        private String AdminPass;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-11TTHAE\SQLEXPRESS;Initial Catalog=Spotify_Clone;Integrated Security=True");
        public AdminPortal(String name,String pass)
        {
            InitializeComponent();
            AdminName = name;
            AdminPass = pass;
        }

        private void DaBo_BTN_Click(object sender, EventArgs e)
        {
            dashEx_Panel.Visible = true;
            audience_panel.Visible = false;
            Artist_Panel.Visible = false;
            Music_Panel.Visible = false;
            AdminADD_Panel.Visible = false;
        }
        private void AdminPortal_Load(object sender, EventArgs e)
        {
            string fetchIdentity = "Select Role from Login where Username='" + AdminName + "' and Password='" + AdminPass + "'";
            SqlDataAdapter sda = new SqlDataAdapter(fetchIdentity,con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if(dtb.Rows.Count>0 && dtb.Rows[0]["Role"].ToString()=="Executive")
            {
                addAdmin_BTN.Visible = false;
                pictureBox5.Visible = false;
            }

            String path = photoquery(AdminName, AdminPass);
            AdminName_Button.Text = "Welcome, "+AdminName;
            Admin_image.ImageLocation = path;

            allCharts();
            dataSource();
            datasource2();
            datasource3();

            //
            if (!pending_data_DGV.Columns.Contains("UserStatus"))  // Check to prevent adding the column multiple times
            {
                addColumn();
            }
            dashEx_Panel.Show();
            audience_panel.Visible = false;
            Artist_Panel.Visible = false;
            Music_Panel.Visible = false;
            AdminADD_Panel.Visible = false;

        }
        String photoquery(String name, String pass)
        {
            string path = "";
            string query = "Select Photo From Admin_Info where UserName='" + name + "' and Password='" + pass + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if (dtb.Rows.Count > 0)
            {
                path = dtb.Rows[0]["Photo"].ToString();
            }
            return path;

        }
        void dataSource()
        {
            /////////query/////////
            string query = "Select Username, Password, Role from Login where status=0";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            pending_data_DGV.DataSource = dtb;
            


        }
        void addColumn()
        {
            /////////////Column Adding/////////////

            DataGridViewCheckBoxColumn status = new DataGridViewCheckBoxColumn();
            status.HeaderText = "Approve User";
            status.Name = "UserStatus";
            status.TrueValue = true;
            status.FalseValue = false;
            pending_data_DGV.Columns.Add(status);
        }
        private void dashEx_Panel_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void allCharts()
        {
            userPie_chart.Titles.Add("User Pie Chart");
            userPie_chart.Titles[0].Font = new Font("Cambria", 16, FontStyle.Bold);
            userPie_chart.Titles[0].ForeColor = Color.Snow;
            userPie_chart.ChartAreas[0].BackColor = Color.Transparent;
            if (userPie_chart.Legends.Count > 0)
            {
                userPie_chart.Legends[0].BackColor = Color.Transparent;
                userPie_chart.Legends[0].Font = new Font("Cambria", 12, FontStyle.Regular);
                userPie_chart.Legends[0].ForeColor = Color.Snow;
            }
            ///////Audience Count
            string q90 = "Select Count(*) from Audience_Info";
            SqlDataAdapter sda90 = new SqlDataAdapter(q90, con);
            DataTable dtb90 = new DataTable();
            sda90.Fill(dtb90);
            int totalAudience = Convert.ToInt32(dtb90.Rows[0][0]);

            string q91 = "Select Count(*) from Artist_Info";
            SqlDataAdapter sda91 = new SqlDataAdapter(q91, con);
            DataTable dtb91 = new DataTable();
            sda91.Fill(dtb91);
            int totalArtist = Convert.ToInt32(dtb91.Rows[0][0]);

            string q92 = "Select Count(*) from Subscription";
            SqlDataAdapter sda92 = new SqlDataAdapter(q92,con);
            DataTable dtb92 = new DataTable();
            sda92.Fill(dtb92);
            int totalSubscriber = Convert.ToInt32(dtb92.Rows[0][0]);

            userPie_chart.Series["S1"].Points.AddXY("Audience", totalAudience);
            userPie_chart.Series["S1"].Points.AddXY("Subscriber", totalSubscriber);
            userPie_chart.Series["S1"].Points.AddXY("Artist", totalArtist);
            userPie_chart.Series["S1"].IsValueShownAsLabel = true;
            userPie_chart.Series["S1"].Font = new Font("Cambria", 14, FontStyle.Bold);
            userPie_chart.Series["S1"].LabelForeColor = Color.Snow;

            /////////////////column Chart//////////////////////////
            //Data Entry
            string qPend = "Select Count(*) From Login where status=0";
            SqlDataAdapter sdaPend = new SqlDataAdapter(qPend, con);
            DataTable dtbPend = new DataTable();
            sdaPend.Fill(dtbPend);

            string tMusic = "Select Count(*) From MusicTable";
            SqlDataAdapter tmsda = new SqlDataAdapter(tMusic,con);
            DataTable tTable = new DataTable();
            tmsda.Fill(tTable);

            string tCount = "SELECT SUM(PlayCount) FROM MusicTable";
            SqlDataAdapter tCsda = new SqlDataAdapter(tCount,con);
            DataTable tCDtb = new DataTable();
            tCsda.Fill(tCDtb);


            column_Chart.Series["Audience"].Points.AddXY("Audience", totalAudience);
            column_Chart.Series["Artists"].Points.AddXY("Artist", totalArtist);
            column_Chart.Series["Music"].Points.AddXY("Music", Convert.ToInt32(tTable.Rows[0][0]));
            column_Chart.Series["Listen Time"].Points.AddXY("Listen Time", Convert.ToInt32(tCDtb.Rows[0][0]));
            column_Chart.Series["Pending Approval"].Points.AddXY("Pending Approval", Convert.ToInt32(dtbPend.Rows[0][0]));

            ////value on head
            column_Chart.Series["Audience"].IsValueShownAsLabel = true;
            column_Chart.Series["Artists"].IsValueShownAsLabel = true;
            column_Chart.Series["Music"].IsValueShownAsLabel = true;
            column_Chart.Series["Listen Time"].IsValueShownAsLabel = true;
            column_Chart.Series["Pending Approval"].IsValueShownAsLabel = true;

            column_Chart.ChartAreas[0].BackColor = Color.Transparent;
            // Customize the column appearance (colors, borders, etc.)
            column_Chart.Series["Audience"].Color = Color.SkyBlue;
            column_Chart.Series["Artists"].Color = Color.LightCoral;
            column_Chart.Series["Music"].Color = Color.Gold;
            column_Chart.Series["Listen Time"].Color = Color.LightGreen;
            column_Chart.Series["Pending Approval"].Color = Color.Salmon;

            column_Chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            column_Chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            column_Chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Snow;

            column_Chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            column_Chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            //customizing X and Y asix title
            column_Chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            column_Chart.ChartAreas[0].AxisX.Title = "Category";
            column_Chart.ChartAreas[0].AxisX.TitleFont = new Font("Cambria", 16, FontStyle.Bold);
            column_Chart.ChartAreas[0].AxisX.TitleForeColor = Color.Snow;
            column_Chart.ChartAreas[0].AxisY.Title = "Count";
            column_Chart.ChartAreas[0].AxisY.TitleFont = new Font("Cambria", 16, FontStyle.Bold);
            column_Chart.ChartAreas[0].AxisY.TitleForeColor = Color.Snow;

            column_Chart.Titles.Add("All Current Data");
            column_Chart.Titles[0].Font = new Font("Cambria", 16, FontStyle.Bold);
            column_Chart.Titles[0].ForeColor = Color.Snow;
            column_Chart.Titles[0].Alignment = ContentAlignment.MiddleLeft;

            // Remove legend background color
            if (column_Chart.Legends.Count > 0)
            {
                column_Chart.Legends[0].BackColor = Color.Transparent;
                column_Chart.Legends[0].BorderColor = Color.FromArgb(53, 76, 143);
                column_Chart.Legends[0].Font = new Font("Cambria", 12, FontStyle.Bold);
                column_Chart.Legends[0].ForeColor = Color.Snow;
            }

            column_Chart.Series["Audience"]["PointWidth"] = "1.95";
            column_Chart.Series["Artists"]["PointWidth"] = "1.8";
            column_Chart.Series["Music"]["PointWidth"] = "1.4";
            column_Chart.Series["Listen Time"]["PointWidth"] = "1.8";
            column_Chart.Series["Pending Approval"]["PointWidth"] = "1.95";
        }

        private void audience_BTN_Click(object sender, EventArgs e)
        {
            audience_panel.Visible = true;
            dashEx_Panel.Visible = false;
            Artist_Panel.Visible = false;
            Music_Panel.Visible = false;
            AdminADD_Panel.Visible = false;
        }

        private void searchAu_TBOX_MouseEnter(object sender, EventArgs e)
        {

        }

        private void searchAu_TBOX_Leave(object sender, EventArgs e)
        {
            
        }

        private void audience_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchAu_TBOX_Enter_1(object sender, EventArgs e)
        {
            if (searchAu_TBOX.Text == "Search Audience")
            {
                searchAu_TBOX.Text = "";
                searchAu_TBOX.ForeColor = Color.Black;
            }
        }

        private void searchAu_TBOX_Leave_1(object sender, EventArgs e)
        {
            if (searchAu_TBOX.Text == "")
            {
                searchAu_TBOX.Text = "Search Audience";
                searchAu_TBOX.ForeColor = Color.FromArgb(125, 125, 125);
            }
        }

        private void back_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void pending_data_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == pending_data_DGV.Columns["UserStatus"].Index && e.RowIndex >= 0)
            {
                bool isChecked = (bool)pending_data_DGV.Rows[e.RowIndex].Cells["UserStatus"].EditedFormattedValue;
                if (isChecked)
                {
                    string username = pending_data_DGV.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                    updatedUserStatus(username);  
                    dataSource();
                    datasource2();
                    datasource3();
                }
            }
        }
        private void updatedUserStatus(String UserName)
        {
            string query = "Update Login set Status=1 where Username='" + UserName + "'";
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        void datasource2()
        {
            String query = "SELECT ai.AudienceID, ai.FirstName, ai.LastName, ai.Email, ai.Phone, ai.Username, ai.Password, ai.Photo, L.status FROM Audience_Info ai INNER JOIN Login L ON ai.Username = L.Username WHERE L.status = 'true'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            allAudience_DGV.DataSource = dtb;
            allAudience_DGV.Columns["Photo"].Visible = false;

            // Load images directly here
            if (!allAudience_DGV.Columns.Contains("UserImage"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                {
                    Name = "UserImage",
                    HeaderText = "User Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                allAudience_DGV.Columns.Insert(0, imgCol);
                allAudience_DGV.Columns[0].Width = 50;
            }
            foreach (DataGridViewRow row in allAudience_DGV.Rows)
            {
                if (row.Cells["Photo"].Value != null)
                {
                    string imagePath = row.Cells["Photo"].Value.ToString();
                    if (System.IO.File.Exists(imagePath))
                    {
                        row.Cells["UserImage"].Value = Image.FromFile(imagePath);
                    }
                    else
                    {
                        row.Cells["UserImage"].Value = null; 
                    }
                }
            }
        }
        private void allAudience_DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        void UpdateStatusInDatabase(string name)
        {
            string query = "Update Login set status=0 where Username='" + name + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void allAudience_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == allAudience_DGV.Columns["status"].Index && e.RowIndex >= 0)
            {
                bool isChecked = (bool)allAudience_DGV.Rows[e.RowIndex].Cells["status"].EditedFormattedValue;
                if (!isChecked)
                {
                    string username = allAudience_DGV.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                    UpdateStatusInDatabase(username);
                    dataSource(); 
                    datasource2();
                    
                }
            }
        }

        private void searchAu_TBOX_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void searchAu_TBOX_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void search_BTN_Click(object sender, EventArgs e)
        {
            //(allAudience_DGV.DataSource as DataTable).DefaultView.RowFilter = String.Format("Username like '%"+searchAu_TBOX.Text+"%'");

        }
        ///////////////Artist Panel
        private void Artist_Search_Enter(object sender, EventArgs e)
        {
            if (Artist_Search.Text == "Search Audience")
            {
                Artist_Search.Text = "";
                Artist_Search.ForeColor = Color.Black;
            }
        }
        private void Artist_Search_Leave(object sender, EventArgs e)
        {
            if (Artist_Search.Text == "")
            {
                Artist_Search.Text = "Search Audience";
                Artist_Search.ForeColor = Color.FromArgb(125, 125, 125);
            }
        }

        private void artist_BTN_Click(object sender, EventArgs e)
        {
            Artist_Panel.Visible = true;
            audience_panel.Visible = false;
            dashEx_Panel.Visible = false;
            Music_Panel.Visible = false;
            AdminADD_Panel.Visible = false;
        }
        void datasource3()
        {
            String query = "SELECT ai.ArtistID,ai.StageName, ai.FirstName, ai.LastName, ai.Email, ai.Phone, ai.Username, ai.Password, ai.Photo, L.status FROM Artist_Info ai INNER JOIN Login L ON ai.Username = L.Username WHERE L.status = 'true'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            dgvArtist.DataSource = dtb;
            dgvArtist.Columns["Photo"].Visible = false;

            // Load images directly here
            if (!dgvArtist.Columns.Contains("UserImage"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                {
                    Name = "UserImage",
                    HeaderText = "User Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvArtist.Columns.Insert(0, imgCol);
                dgvArtist.Columns[0].Width = 50;
            }
            foreach (DataGridViewRow row in dgvArtist.Rows)
            {
                if (row.Cells["Photo"].Value != null)
                {
                    string imagePath = row.Cells["Photo"].Value.ToString();
                    if (System.IO.File.Exists(imagePath))
                    {
                        row.Cells["UserImage"].Value = Image.FromFile(imagePath);
                    }
                    else
                    {
                        row.Cells["UserImage"].Value = null;
                    }
                }
            }
        }

        private void dgvArtist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dgvArtist.Columns["status"].Index && e.RowIndex >= 0)
            {
                bool isChecked = (bool)dgvArtist.Rows[e.RowIndex].Cells["status"].EditedFormattedValue;
                if (!isChecked)
                {
                    string username = dgvArtist.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                    UpdateStatusInDatabase(username);
                    dataSource();
                    datasource3();
                }
            }
        }

        private void userPie_chart_Click(object sender, EventArgs e)
        {

        }

        private void dashEx_Panel_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void AdminPortal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void music_BTN_Click(object sender, EventArgs e)
        {
            audience_panel.Visible = false;
            dashEx_Panel.Visible = false;
            Artist_Panel.Visible = false;
            Music_Panel.Visible = true;
            AdminADD_Panel.Visible = false;
            AllMusicDataSource();
        }
        void AllMusicDataSource()
        {
            string query = "Select MusicID,MusicTitle,Singer,PlayCount,Genres,ArtistID,FileName,CoverPage from MusicTable order by Newid()";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            AllMusic_DGV.DataSource = dtb;
            AllMusic_DGV.Columns["MusicID"].Visible = false;
            AllMusic_DGV.Columns["FileName"].Visible = false;
            AllMusic_DGV.Columns["CoverPage"].Visible = false;

            //////////////////////////column Adding////////////////////
            if (!AllMusic_DGV.Columns.Contains("Cover Photo"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                {
                    Name = "Cover Photo",
                    HeaderText = "Cover",
                    ImageLayout = DataGridViewImageCellLayout.Stretch
                };
                AllMusic_DGV.Columns.Insert(0, imgCol);
                AllMusic_DGV.Columns[0].Width = 70;
                AllMusic_DGV.Columns[4].Width = 100;
                AllMusic_DGV.Columns[5].Width = 90;
                AllMusic_DGV.Columns[6].Width = 90;
            }
            if (!AllMusic_DGV.Columns.Contains("Play Song"))
            {
                DataGridViewImageColumn imgcol3 = new DataGridViewImageColumn();
                imgcol3.Name = "Play Song";
                imgcol3.HeaderText = "Play";
                imgcol3.ImageLayout = DataGridViewImageCellLayout.Normal;
                AllMusic_DGV.Columns.Insert(8, imgcol3);
                AllMusic_DGV.Columns[8].Width = 50;
            }
            if (!AllMusic_DGV.Columns.Contains("Total Report"))
            {
                DataGridViewTextBoxColumn textCol = new DataGridViewTextBoxColumn();
                textCol.Name = "Total Report";
                textCol.HeaderText = "Total Report";
                //textCol.ImageLayout = DataGridViewImageCellLayout.Normal;
                AllMusic_DGV.Columns.Insert(9, textCol);
                AllMusic_DGV.Columns[9].Width = 120;
            }
            if(!AllMusic_DGV.Columns.Contains("Delete Song"))
            {
                DataGridViewImageColumn imgDel = new DataGridViewImageColumn();
                imgDel.Name = "Delete Song";
                imgDel.HeaderText = "Delete Music";
                imgDel.ImageLayout = DataGridViewImageCellLayout.Normal;
                AllMusic_DGV.Columns.Insert(10,imgDel);
                AllMusic_DGV.Columns[10].Width = 50;
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
                if(row.Cells["Delete Song"].Value==null)
                {
                    String image = @"F:\AIUB Semester 6\Object Oriented Programming 2 (C#)\Final Term\Project-Spotify\Images\delete.png";
                    if (System.IO.File.Exists(image))
                    {
                        row.Cells["Delete Song"].Value = Image.FromFile(image);
                    }
                    else row.Cells["Delete Song"].Value = null;
                }
                if (row.Cells["Total Report"].Value == null)
                {
                    string mID = row.Cells["MusicID"].Value.ToString();

                    string query7 = "Select count(*) from ReportMusic where MusicID='" + mID + "'";
                    SqlDataAdapter sda7 = new SqlDataAdapter(query7, con);
                    DataTable dtb7 = new DataTable();
                    sda7.Fill(dtb7);
                    string value = dtb7.Rows[0][0].ToString();
                    if(value!="0")
                    {
                        row.Cells["Total Report"].Value = value;
                    }
                    else row.Cells["Total Report"].Value = "0";
                }
            }
        }
        String listeningMusic;
        String musicID;

        private void AllMusic_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AllMusic_DGV.Columns[e.ColumnIndex].Name == "Delete Song")
            {
                int rowIndex = e.RowIndex;
                String musicNo = AllMusic_DGV.Rows[rowIndex].Cells["MusicID"].Value.ToString();
                String artistID = AllMusic_DGV.Rows[rowIndex].Cells["ArtistID"].Value.ToString();
                var result = MessageBox.Show("Are You sure about deleting this music?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    deleteMusic(musicNo,artistID);
                }
                else return;
            }
            if (AllMusic_DGV.Columns[e.ColumnIndex].Name == "Play Song")
            {
                int rowIndex = e.RowIndex;
                listeningMusic = AllMusic_DGV.Rows[rowIndex].Cells["FileName"].Value.ToString();
                musicID = AllMusic_DGV.Rows[rowIndex].Cells["MusicID"].Value.ToString();
                MusicPlayer(listeningMusic, musicID);
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
        private void deleteMusic(String MusicNo,string ArtistID)
        {
            String delQuery1 = "DELETE FROM ArtistMusic WHERE MusicID = '" + MusicNo + "'";
            String delQuery2 = "DELETE FROM MusicTable WHERE ArtistID = '" + ArtistID + "' AND MusicID = '" + MusicNo + "'";
            SqlCommand cmd = new SqlCommand(delQuery1, con);
            SqlCommand cmd2 = new SqlCommand(delQuery2, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con.Close();
            AllMusicDataSource();

        }

        private void AdminADD_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
        String ExecutivePhotoPath;
        private void UploadPic_BTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            open.Title = "Select an Image File";
            if (open.ShowDialog() == DialogResult.OK)
            {
                ExecutivePhotoPath = open.FileName;
                MessageBox.Show("File Selected: " + ExecutivePhotoPath, "Cover Photo Selected", MessageBoxButtons.OK, MessageBoxIcon.None);
                Executive_Photo.ImageLocation = ExecutivePhotoPath;
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(Executive_Photo.ImageLocation)||
                String.IsNullOrWhiteSpace(First_Name_TXT.Text)||
                String.IsNullOrWhiteSpace(Last_Name_TXT.Text)||
                String.IsNullOrWhiteSpace(Email_Id_TXT.Text)||
                String.IsNullOrWhiteSpace(Phone_TXT.Text)||
                String.IsNullOrWhiteSpace(User_Name_TXT.Text)||
                String.IsNullOrWhiteSpace(Password_TXT.Text))
            {
                MessageBox.Show("Please Fill up All Section","Fill Up",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            String query1 = "insert into Admin_Info values('" + First_Name_TXT.Text + "','" + Last_Name_TXT.Text + "','Executive','" + Phone_TXT.Text + "','" + Email_Id_TXT.Text + "','" + User_Name_TXT.Text + "','" + Password_TXT.Text + "','" + ExecutivePhotoPath + "')";
            SqlCommand cmd = new SqlCommand(query1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            String fetchQuery = "Select AdminID from Admin_Info where UserName='" + User_Name_TXT.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(fetchQuery, con);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            String ExID = "";
            if(tb.Rows.Count>0)
            {
                ExID = tb.Rows[0]["AdminID"].ToString();
            }
            string query2= "Insert Into User_Info values('" + ExID + "','" + First_Name_TXT.Text + "','" + Last_Name_TXT.Text + "','Executive','" + Phone_TXT.Text + "','" + Email_Id_TXT.Text + "','" + User_Name_TXT.Text + "','" + Password_TXT.Text + "',3000,'" + ExecutivePhotoPath + "')";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();

            string query3= "Insert Into Login values('" + User_Name_TXT.Text + "','" + Password_TXT.Text + "','Executive',0)";
            SqlCommand cmd3 = new SqlCommand(query3, con);
            con.Open();
            cmd3.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Executive Id is created, Wait for Approval","Id created",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            Executive_Photo.ImageLocation = null;
            First_Name_TXT.Clear();
            Last_Name_TXT.Clear();
            Email_Id_TXT.Clear();
            Phone_TXT.Clear();
            User_Name_TXT.Clear();
            Password_TXT.Clear();

        }

        private void addAdmin_BTN_Click(object sender, EventArgs e)
        {
            Artist_Panel.Visible = false;
            audience_panel.Visible = false;
            dashEx_Panel.Visible = false;
            Music_Panel.Visible = false;
            AdminADD_Panel.Visible = true;
        }

        private void User_Name_TXT_Leave(object sender, EventArgs e)
        {
            string query = "Select * from User_Info where Username='" + User_Name_TXT.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if (dtb.Rows.Count > 0)
            {
                MessageBox.Show("This UserName is Alreary Used, Pleased write another", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                User_Name_TXT.Clear();
                User_Name_TXT.Focus();

            }
        }

        private void cmn_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void financial_BTN_Click(object sender, EventArgs e)
        {
            AdminADD_Panel.Visible = false;
        }
    }
}
