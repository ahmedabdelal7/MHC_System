using MentCareBussinessLayer;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MentCarePresentationLayer
{
    public partial class frmAddEditPatient : Form
    {


        enum enMode
        {
            AddNew = 0, Update,
        }

        enMode _Mode;

        clsPatient _Patient;
        int _PatientID;

        public frmAddEditPatient(int PatientID)
        {
            InitializeComponent();

            _Mode = (PatientID == -1 ? enMode.AddNew : enMode.Update);

            _PatientID = PatientID;
        }

        private void frmAddEditPatient_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        void _LoadData()
        {
            if(_Mode == enMode.AddNew)
            {
                lblAddEditPatient.Text = "Add New Patient";
                lblPatientID.Text = "??";
                _Patient = new clsPatient();
                lblRemove.Visible = false;
                return;
            }

            lblAddEditPatient.Text = "Edit Patient Info";

            _Patient = clsPatient.FindByID(_PatientID);
            lblPatientID.Text =  _Patient.PatientID.ToString();
            txtFirstName.Text = _Patient.FirstName.ToString();
            txtLastName.Text = _Patient.LastName.ToString();
            txtPhone.Text = _Patient.Phone.ToString();
            txtAddress.Text = _Patient.Address.ToString();
            txtEmergencyCall.Text = _Patient.EmergencyContact.ToString();

            if(_Patient.Gender == rbMale.Tag.ToString()) 
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            dtDateOfBirth.Value = _Patient.DateOfBirth;

            lblRemove.Visible = false;

            if (_Patient.ImagePath != "")
            {
                ppProfilePicture.Load(_Patient.ImagePath);
                lblRemove.Visible = true;

            }

        }

        bool _AddNewPatient()
        {

            if (_Patient.Save())
            {
                MessageBox.Show("Patient Added Successfully.");
                return true;
            }

            return false;
        }

        bool _UpdatePatientInfo()
        {
            

            if (_Patient.Save()) { 
                MessageBox.Show("Patient Updated Successfully.");
                return true;
            }

            MessageBox.Show("Faild to update Patient Info!");
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _Patient.PatientID = _PatientID;

            _Patient.FirstName = txtFirstName.Text.ToString();
            _Patient.LastName = txtLastName.Text;
            _Patient.Phone = txtPhone.Text;
            _Patient.Address = txtAddress.Text;
            _Patient.EmergencyContact = txtEmergencyCall.Text;

            _Patient.Gender = rbMale.Tag.ToString();
            _Patient.DateOfBirth = dtDateOfBirth.Value;

            if (_Mode == enMode.AddNew)
            {
                DialogResult mBoxResult = MessageBox.Show("Are you sure you want to Add this patient?", "Confirm", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);


                if(mBoxResult == DialogResult.Yes)
                {

                    if(_AddNewPatient())
                    {
                        _Mode = enMode.Update;
                        lblAddEditPatient.Text = "Edit Patient Info";
                        lblPatientID.Text = _Patient.PatientID.ToString();
                    }
                }

            }
            else
            {
                DialogResult mBoxResult = MessageBox.Show("Are you sure you want to update this patient?", "Confirm",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);


                if(mBoxResult == DialogResult.Yes)
                {
                    _UpdatePatientInfo();
                       
                }                               

            }                    

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateImgePath()
        {
            openFileDialog1.InitialDirectory = @"E:\";
            openFileDialog1.Title = "Choose Image";
            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.Filter = "images (*.jpg) |*.jpg| All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                _Patient.ImagePath = openFileDialog1.FileName;

            }
            if (_Patient.ImagePath != "")
            {
                ppProfilePicture.Load(_Patient.ImagePath);
                lblRemove.Visible = true;
            }

        }
            private void lblUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                UpdateImgePath();
            }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result =  MessageBox.Show("Are you sure uou want to remove profile Picture?","Confirm",MessageBoxButtons.OKCancel, MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            if(result == DialogResult.OK)
            {
                _Patient.ImagePath = "";
                ppProfilePicture.Load(@"C:\Users\42052\Downloads\Images\user.png");
                lblRemove.Visible = false;

            }
        }

    }
}
