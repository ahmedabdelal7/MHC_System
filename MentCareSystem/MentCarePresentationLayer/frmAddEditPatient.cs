using MentCareBussinessLayer;
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
                return;
            }

            lblAddEditPatient.Text = "Edit Patient Info";

            _Patient = clsPatient.Find(_PatientID);
            lblPatientID.Text =  _Patient.PatientID.ToString();
            txtFirstName.Text = _Patient.FirstName.ToString();
            txtLastName.Text = _Patient.LastName.ToString();
            txtPhone.Text = _Patient.Phone.ToString();
            txtAddress.Text = _Patient.Address.ToString();
            txtEmergencyContact.Text = _Patient.EmergencyContact.ToString();

            if(_Patient.Gender == rbMale.Tag.ToString()) 
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            dateTimePicker1.Value = _Patient.DateOfBirth;

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
            _Patient.EmergencyContact = txtEmergencyContact.Text;

            _Patient.Gender = rbMale.Tag.ToString();
            _Patient.DateOfBirth = dateTimePicker1.Value;

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
    }
}
