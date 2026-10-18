using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Applications.Local_Driving_License
{
    public class frmLicenseHistory : Form
    {
        public frmLicenseHistory(int personID)
        {
            Text = "License History";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Normal;
            ClientSize = new Size(1100, 800);

            clsPeople person = clsPeople.Find(personID);
            if (person == null) { MessageBox.Show("Person not found."); Close(); return; }

            var title = new Label { Text = "License History", Font = new Font("Microsoft Sans Serif", 24, FontStyle.Bold), ForeColor = Color.DarkRed, AutoSize = true, Location = new Point(430, 35) };
            var personPicture = new PictureBox { Location = new Point(35, 145), Size = new Size(180, 210), SizeMode = PictureBoxSizeMode.StretchImage, BorderStyle = BorderStyle.FixedSingle, BackColor = Color.Gainsboro};
            LoadPersonImage(personPicture, person.ImagePath);
            var info = new GroupBox { Text = "Person Information", Location = new Point(250, 95), Size = new Size(800, 270) };
            Add(info, "Person ID:", person.PersonID, 20, 35); Add(info, "Name:", person.FirstName + " " + person.SecondName + " " + person.ThirdName + " " + person.LastName, 20, 80, Color.DarkRed); Add(info, "National No:", person.NationalNo, 20, 125); Add(info, "Gender:", person.Gendor, 20, 170); Add(info, "Date Of Birth:", person.DateOfBirth.ToShortDateString(), 430, 35); Add(info, "Phone:", person.Phone, 430, 80); Add(info, "Email:", person.Email, 430, 125); Add(info, "Address:", person.Address, 430, 170);

            var tabs = new TabControl { Location = new Point(15, 390), Size = new Size(1060, 350) };
            var localTab = new TabPage("Local");
            var internationalTab = new TabPage("International");
            var licenses = new DataGridView { Location = new Point(10, 10), Size = new Size(1035, 270), ReadOnly = true, AllowUserToAddRows = false, AllowUserToDeleteRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, BackgroundColor = SystemColors.ButtonFace, DataSource = clsLicenses.GetLicenseHistory(personID) };
            localTab.Controls.Add(licenses);
            internationalTab.Controls.Add(new Label { Text = "No international licenses found.", AutoSize = true, Font = new Font("Microsoft Sans Serif", 12), Location = new Point(25, 25) });
            tabs.TabPages.Add(localTab); tabs.TabPages.Add(internationalTab);

            var records = new Label { Text = "# Records: " + licenses.Rows.Count, AutoSize = true, Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold), Location = new Point(25, 750) };
            var close = new Button { Text = "Close", Location = new Point(930, 760), Size = new Size(120, 35) }; close.Click += (s, e) => Close();
            Controls.AddRange(new Control[] { title, personPicture, info, tabs, records, close });
        }

        static void LoadPersonImage(PictureBox picture, string storedPath)
        {
            if (string.IsNullOrWhiteSpace(storedPath)) return;
            string path = storedPath.Replace('/', Path.DirectorySeparatorChar);
            if (!Path.IsPathRooted(path)) path = Path.Combine(Application.StartupPath, path);
            if (!File.Exists(path)) return;
            try { using (Image source = Image.FromFile(path)) picture.Image = new Bitmap(source); } catch { picture.Image = null; }
        }

        static void Add(Control parent, string label, object value, int x, int y, Color? color = null)
        {
            parent.Controls.Add(new Label { Text = label, Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold), AutoSize = true, Location = new Point(x, y) });
            parent.Controls.Add(new Label { Text = Convert.ToString(value), ForeColor = color ?? Color.Black, AutoSize = true, Location = new Point(x + 125, y) });
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmLicenseHistory
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "frmLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            
            







        }
    }
}
