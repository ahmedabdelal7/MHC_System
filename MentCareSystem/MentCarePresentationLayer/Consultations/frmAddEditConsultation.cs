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
    public partial class frmAddEditConsultation : Form
    {

        clsConsultation _Consultation;
        int _ConsultationID;
        enum enMode
        {
            AddNew = 0, Update = 1
        }
        enMode _Mode;
        public frmAddEditConsultation(int ID)
        {
            InitializeComponent();
            _Mode = (ID == -1 ? enMode.AddNew : enMode.Update);
            _ConsultationID = ID;
        }
        private void FillPationtsComboBox()
        {
            DataTable patientsDT = clsPatient.ListAllPatients();
            
            cbPatients.DataSource = patientsDT;
            cbPatients.DisplayMember = "FullName";
            cbPatients.ValueMember = "PatientID";

        }

        private void FillDoctorsComboBox()
        {
            DataTable DoctorsDT = clsDoctor.ListAllDoctors();

            cbDoctors.DataSource = DoctorsDT;
            cbDoctors.DisplayMember = "FullName";
            cbDoctors.ValueMember = "DoctorID";

        }
        private void frmAddEditConsultation_Load(object sender, EventArgs e)
        {

            FillPationtsComboBox();
            FillDoctorsComboBox();

            cbDoctors.SelectedIndex = 0;
            cbPatients.SelectedIndex = 0;

            dtConsultationDate.Value = DateTime.Now;

            if(_Mode == enMode.AddNew)
            {
                lblAddEditConsultation.Text = "Add New Consultation";
                lblConsultationID.Text = "N/A";
                _Consultation = new clsConsultation();
                return;
            }

            _Consultation = clsConsultation.FindByID(_ConsultationID);

            cbPatients.SelectedValue = _Consultation.PatientID;
            cbDoctors.SelectedValue = _Consultation.DoctorID;



            lblAddEditConsultation.Text = "Update Consultation";
            lblConsultationID.Text = _ConsultationID.ToString();

            dtConsultationDate.Value = _Consultation.ConsultationDate;

            txtDiagnosis.Text = _Consultation.Diagnosis.ToString();
            txtTreatmentPlan.Text = _Consultation.TreatmentPlan.ToString();
            txtNotes.Text = _Consultation.Notes.ToString();


        }
        private void AddNewConsultation()
        {
            DialogResult mBoxResult = MessageBox.Show("Are you sure you want to Add this Consultation?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (mBoxResult == DialogResult.Yes)
            {

                if (_Consultation.Save())
                {
                    MessageBox.Show("Consultation Added Successfully");
                    _Mode = enMode.Update;
                    lblAddEditConsultation.Text = "Update Consultation Info";
                    lblConsultationID.Text = _Consultation.ConsultationID.ToString();
                }
                else MessageBox.Show("Faild to add this consultation!");
            }
        }
        private void UpdateConsultation()
        {
            DialogResult mBoxResult = MessageBox.Show("Are you sure you want to update this Consultaion?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);


            if (mBoxResult == DialogResult.Yes)
            {

                if (_Consultation.Save())
                {

                    MessageBox.Show("Consultation Updated Successfully");
                }
                else MessageBox.Show("Faild to Update this consultation!");
            }
        }
        private void Save()
        {

            _Consultation.PatientID = (int)cbPatients.SelectedValue;
            _Consultation.DoctorID = (int)cbDoctors.SelectedValue;
            _Consultation.ConsultationDate = new DateTime
            (
                dtConsultationDate.Value.Year,
                dtConsultationDate.Value.Month,
                dtConsultationDate.Value.Day,
                dtConsultationDate.Value.Hour,
                dtConsultationDate.Value.Minute,
                0
            );
            _Consultation.Diagnosis = txtDiagnosis.Text;
            _Consultation.TreatmentPlan = txtTreatmentPlan.Text;
            _Consultation.Notes = txtNotes.Text;

            if (_Mode == enMode.AddNew)
            {
                AddNewConsultation();

            }
            else
            {
                UpdateConsultation();

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
