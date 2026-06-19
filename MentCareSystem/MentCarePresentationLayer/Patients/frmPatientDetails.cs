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

namespace MentCarePresentationLayer.Patients
{
    public partial class frmPatientDetails : Form
    {
        int _PatientID;
        public frmPatientDetails(int PatientID)
        {
            InitializeComponent();
            _PatientID = PatientID;
        }


      

        private void _LoadDetails()
        {
            clsPatient patient = clsPatient.FindByID(_PatientID);

            txtFirstName.Text = patient.FirstName;
            txtLastName.Text = patient.LastName;
            txtPhone.Text = patient.Phone;
            txtAddress.Text = patient.Address;
            txtEmergencyCall.Text = patient.EmergencyContact;
            lblPatientID.Text = patient.PatientID.ToString();
            dtDateOfBirth.Value = patient.DateOfBirth;

            rbMale.Checked = (patient.Gender == "M");
            rbFemale.Checked = (patient.Gender == "F");

            //Load Image

            if(patient.ImagePath != "")
                ppProfilePicture.Load(patient.ImagePath);


        }
        private void frmPatientDetails_Load(object sender, EventArgs e)
        {
            _LoadDetails();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
