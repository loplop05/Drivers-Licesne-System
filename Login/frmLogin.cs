using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Login

{
    public partial class frmLogin : Form
    {
        private readonly string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DVLD_login_cache.txt");

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (File.Exists(savePath))
            {
                string[] savedLines = File.ReadAllLines(savePath);
                
                if (savedLines.Length >= 2)
                {
                    cbRemmberme.Checked = true;       
                    txtUsername.Text = savedLines[0];    
                    txtPassword.Text = savedLines[1];    
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                clsUsers user = clsUsers.Login(txtUsername.Text.Trim(), txtPassword.Text.Trim());

                // Login succeeds only if user exists (which means username, password match AND IsActive = 1)
                if (user != null)
                {
                    if (cbRemmberme.Checked)
                    {
                        string[] credentials = {
                            txtUsername.Text,
                            txtPassword.Text
                        };
                        File.WriteAllLines(savePath, credentials);
                    }
                    else
                    {
                        if (File.Exists(savePath))
                        {
                            File.Delete(savePath);
                        }
                    }

                    this.Hide();
                    frmMain mainForm = new frmMain();
                    mainForm.ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Invalid username or password, or account is inactive.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
