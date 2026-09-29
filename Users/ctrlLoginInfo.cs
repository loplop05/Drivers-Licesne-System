using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class ctrlLoginInfo : UserControl
    {
        public ctrlLoginInfo()
        {
            InitializeComponent();
        }

        public void LoadUser(int userID, string username, bool isActive)
        {
            lblUserID.Text = userID.ToString();
            lblUserName.Text = username;
            lblIsActive.Text = isActive ? "Yes" : "No";
        }
    }
}
