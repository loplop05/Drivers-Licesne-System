using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Applications.Local_Driving_License
{
    public class frmLicenseInfo : Form
    {
        public frmLicenseInfo(int licenseID)
        {
            Text = "License Info"; StartPosition = FormStartPosition.CenterScreen; ClientSize = new Size(900, 560);
            DataTable data = clsLicenses.GetLicenseInfo(licenseID); if (data.Rows.Count == 0) { MessageBox.Show("License not found."); Close(); return; } DataRow r = data.Rows[0];
            var title = new Label { Text = "Driver License Info", Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold), ForeColor = Color.DarkRed, AutoSize = true, Location = new Point(330, 30) };
            var box = new GroupBox { Text = "Driver License Info", Location = new Point(20, 90), Size = new Size(860, 390) }; int y = 35;
            Add(box, "Class:", r["ClassName"], 20, y); Add(box, "Name:", r["FullName"], 20, y += 45, Color.DarkRed); Add(box, "License ID:", r["LicenseID"], 20, y += 45); Add(box, "National No:", r["NationalNo"], 20, y += 45); Add(box, "Gender:", r["Gendor"], 20, y += 45); Add(box, "Issue Date:", Convert.ToDateTime(r["IssueDate"]).ToShortDateString(), 20, y += 45); Add(box, "Issue Reason:", "First Time", 20, y += 45); Add(box, "Notes:", string.IsNullOrWhiteSpace(r["Notes"].ToString()) ? "No Notes" : r["Notes"], 20, y += 45);
            Add(box, "Is Active?", Convert.ToBoolean(r["IsActive"]) ? "Yes" : "No", 460, 35); Add(box, "Driver ID:", r["DriverID"], 460, 80); Add(box, "Date Of Birth:", Convert.ToDateTime(r["DateOfBirth"]).ToShortDateString(), 460, 125); Add(box, "Expiration Date:", Convert.ToDateTime(r["ExpirationDate"]).ToShortDateString(), 460, 170); Add(box, "Is Detained?", Convert.ToBoolean(r["IsDetained"]) ? "Yes" : "No", 460, 215);
            var personImage = new PictureBox { SizeMode = PictureBoxSizeMode.Zoom, Location = new Point(690, 35), Size = new Size(145, 180), BorderStyle = BorderStyle.FixedSingle, BackColor = Color.Gainsboro };
            string path = r["ImagePath"] == DBNull.Value ? string.Empty : r["ImagePath"].ToString().Replace('/', Path.DirectorySeparatorChar);
            if (!string.IsNullOrWhiteSpace(path))
            {
                if (!Path.IsPathRooted(path)) path = Path.Combine(Application.StartupPath, path);
                if (File.Exists(path)) try { using (Image source = Image.FromFile(path)) personImage.Image = new Bitmap(source); } catch { personImage.Image = null; }
            }
            box.Controls.Add(personImage);
            var close = new Button { Text = "Close", Location = new Point(750, 500), Size = new Size(120, 35) }; close.Click += (s, e) => Close(); Controls.AddRange(new Control[] { title, box, close });
        }
        static void Add(Control parent, string label, object value, int x, int y, Color? color = null) { parent.Controls.Add(new Label { Text = label, Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold), AutoSize = true, Location = new Point(x, y) }); parent.Controls.Add(new Label { Text = Convert.ToString(value), ForeColor = color ?? Color.Black, AutoSize = true, Location = new Point(x + 145, y) }); }
    }
}
