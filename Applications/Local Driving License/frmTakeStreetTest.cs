using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Applications.Local_Driving_License
{
    public class frmTakeStreetTest : Form
    {
        readonly int appointment, user; readonly RadioButton pass = new RadioButton { Text = "Pass", Location = new Point(180, 90) }; readonly RadioButton fail = new RadioButton { Text = "Fail", Location = new Point(280, 90) }; readonly TextBox notes = new TextBox { Location = new Point(180, 130), Width = 260, Height = 70, Multiline = true }; readonly DateTimePicker date = new DateTimePicker { Location = new Point(180, 50), Width = 260 };
        public frmTakeStreetTest(int app, int appointment, int user) { this.appointment = appointment; this.user = user; Text = "Take Street Test"; StartPosition = FormStartPosition.CenterScreen; ClientSize = new Size(560, 300); var label = new Label { Text = "Appointment Date:", Location = new Point(50, 55), AutoSize = true }; var n = new Label { Text = "Notes:", Location = new Point(50, 135), AutoSize = true }; var save = new Button { Text = "Save", Location = new Point(180, 225), Size = new Size(110, 35) }; save.Click += Save_Click; var rows = clsTestAppointments.GetStreetAppointments(app).Select("TestAppointmentID = " + appointment); if (rows.Length == 1) date.Value = Convert.ToDateTime(rows[0]["AppointmentDate"]); Controls.AddRange(new Control[] { label, date, pass, fail, n, notes, save }); }
        void Save_Click(object sender, EventArgs e) { if (!pass.Checked && !fail.Checked) { MessageBox.Show("Please select Pass or Fail."); return; } if (!clsTestAppointments.CompleteStreetAppointment(appointment, pass.Checked, notes.Text.Trim(), user)) { MessageBox.Show("Unable to save the test result."); return; } DialogResult = DialogResult.OK; Close(); }
    }
}
