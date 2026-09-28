using DVLD_Business;
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

namespace DVLD.People.Controls
{
    public partial class ctrlPersonDetails : UserControl
    {
        private int _PersonID = -1;

        public ctrlPersonDetails()
        {
            InitializeComponent();
        }


        public void LoadPerson(int PersonID)
        {
            _PersonID = PersonID;

            clsPeople Person = clsPeople.Find(PersonID);

            if (Person == null)
            {
                MessageBox.Show("Person not found.");
                return;
            }


            lblName.Text = Person.FirstName + " " +
               Person.SecondName + " " +
               Person.ThirdName + " " +
               Person.LastName;

            lblPersonID.Text = Person.PersonID.ToString();

            clsCountries Country = clsCountries.Find(Person.NationalityCountryID);

            if (Country != null)
            {
                lblCountry.Text = Country.CountryName;
            }
            lblDOB.Text = Person.DateOfBirth.ToString();

            lblNationalNo.Text = Person.NationalNo;

            lblGendor.Text = Person.Gendor;
            lblAddress.Text = Person.Address;
            lblEmail.Text = Person.Email;
            lblPhone.Text = Person.Phone;
            if (!string.IsNullOrEmpty(Person.ImagePath))
            {
                string imagePath = Path.Combine(
                    Application.StartupPath,
                    Person.ImagePath
                );

                if (File.Exists(imagePath))
                {
                    using (Image tempImage = Image.FromFile(imagePath))
                    {
                        pbPersonImage.Image = new Bitmap(tempImage);
                    }
                }
            }

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddPeople frm = new frmAddPeople(_PersonID);
            frm.ShowDialog();
            LoadPerson(_PersonID);
        }




































































    }
}
