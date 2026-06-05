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
    public partial class frmAddEditDoctor : Form
    {
        int DoctorID;
        clsDoctor Doctor;
        enum enMode
        {
            AddNew =0, Update =1
        }
        enMode _Mode;

        public frmAddEditDoctor(int ID)
        {
            InitializeComponent();
            _Mode = (ID == -1 ? enMode.AddNew : enMode.Update);
            DoctorID = ID;
        }

        private void _LoadData()
        {
            //if mode in add new doctor mode:
            if (_Mode == enMode.AddNew) {
                lblAddEditDoctor.Text = "Add New Doctor";
                lblDoctorID.Text = "??";
                Doctor = new clsDoctor();
                return;
            }
            //if mode in add update doctor mode:
            lblAddEditDoctor.Text = $"Update Doctor [{DoctorID}]";
            lblDoctorID.Text = DoctorID.ToString();
            Doctor = clsDoctor.FindByID(DoctorID);

            txtFirstName.Text = Doctor.FirstName;
            txtLastName.Text = Doctor.LastName;
            txtEmail.Text = Doctor.Email;
            txtPhone.Text = Doctor.Phone;
            txtSpecialization.Text = Doctor.Specialization;
            dtHireDate.Value = Doctor.HireDate;

        }

        private void Save()
        {
            if(_Mode == enMode.AddNew)
            {
                DialogResult result =  MessageBox.Show("Are you sure you want to Add this Doctor?","Confirm",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes) { 
                    _Mode = enMode.Update;
                    Doctor.FirstName = txtFirstName.Text;
                    Doctor.LastName = txtLastName.Text;
                    Doctor.Email = txtEmail.Text;
                    Doctor.Phone = txtPhone.Text;
                    Doctor.Specialization = txtSpecialization.Text;
                    Doctor.HireDate = (DateTime)dtHireDate.Value;
                    
                    
                    if(Doctor.Save())
                    {
                       
                        MessageBox.Show("Doctor added successfully.");
                        DoctorID = Doctor.DoctorID;
                        lblAddEditDoctor.Text = $"Update Doctor [{DoctorID}]";
                        lblDoctorID.Text = DoctorID.ToString();

                    }else MessageBox.Show("Faild to add Doctor!");

                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to update this docotor?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes) { 

                    Doctor.DoctorID = DoctorID;
                    Doctor.FirstName = txtFirstName.Text;
                    Doctor.LastName = txtLastName.Text;
                    Doctor.Email = txtEmail.Text;
                    Doctor.Phone = txtPhone.Text;
                    Doctor.Specialization = txtSpecialization.Text;
                    Doctor.HireDate = dtHireDate.Value;

                    if (Doctor.Save()) {
                        MessageBox.Show("Doctor updated successfully.");
                    }else 
                        MessageBox.Show("Faild to update Doctor!");
                }
            }

        }

        private void frmAddEditDoctor_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            _LoadData();
        }
    }
}
