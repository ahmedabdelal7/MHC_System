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

namespace MentCarePresentationLayer.Doctors
{
    public partial class frmDoctorDetails : Form
    {
        int _DoctorID;
        public frmDoctorDetails(int DoctorID)
        {
            InitializeComponent();

            _DoctorID = DoctorID;
        }


        private void _LoadDetails()
        {
            clsDoctor doctor = clsDoctor.FindByID(_DoctorID);
            if (doctor == null)
                return;

            txtFirstName.Text = doctor.FirstName;
            txtLastName.Text = doctor.LastName;
            txtEmail.Text = doctor.Email;
            txtPhone.Text = doctor.Phone;
            txtSpecialization.Text = doctor.Specialization;

            lblDoctorID.Text = doctor.DoctorID.ToString();
            dtHireDate.Value = doctor.HireDate;

            if (doctor.ImagePath != "") { 
                ppProfilePicture.Load(doctor.ImagePath);
            }
        }

        private void frmDoctorDetails_Load(object sender, EventArgs e)
        {
            _LoadDetails();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
