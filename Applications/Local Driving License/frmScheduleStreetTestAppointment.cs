using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Applications.Local_Driving_License
{
    public class frmScheduleStreetTestAppointment : Form
    {
        readonly int app, user, appointment; readonly DateTimePicker date = new DateTimePicker(); readonly Button save = new Button();
        public frmScheduleStreetTestAppointment(int app, int user, int appointment = -1)
        {
            this.app = app; this.user = user; this.appointment = appointment; Text = appointment > 0 ? "Edit Street Test Appointment" : "Schedule Street Test Appointment"; StartPosition = FormStartPosition.CenterScreen; ClientSize = new Size(560, 300);
            var title = new Label { Text = Text, Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold), ForeColor = Color.Red, AutoSize = true, Location = new Point(115, 25) };
            var info = new Label { AutoSize = true, Location = new Point(75, 100), Text = "Appointment Date:" }; date.Location = new Point(230, 96); date.MinDate = DateTime.Today; date.Width = 220;
            save.Text = appointment > 0 ? "Update" : "Save"; save.Location = new Point(230, 180); save.Size = new Size(110, 38); save.Click += Save_Click;
            var close = new Button { Text = "Close", Location = new Point(350, 180), Size = new Size(100, 38) }; close.Click += (s, e) => Close(); Controls.AddRange(new Control[] { title, info, date, save, close });
            if (appointment > 0) { DataRow[] rows = clsTestAppointments.GetStreetAppointments(app).Select("TestAppointmentID = " + appointment); if (rows.Length == 1) date.Value = Convert.ToDateTime(rows[0]["AppointmentDate"]).Date; }
        }
        void Save_Click(object sender, EventArgs e) { bool ok = appointment > 0 ? clsTestAppointments.UpdateStreetAppointmentDate(appointment, date.Value.Date) : clsTestAppointments.AddStreetAppointment(app, date.Value.Date, 20, user) > 0; if (!ok) { MessageBox.Show("The appointment could not be saved.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } DialogResult = DialogResult.OK; Close(); }
    }
}
