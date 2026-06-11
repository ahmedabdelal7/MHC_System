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
    public partial class frmAddEditAppointment : Form
    {
        enum enMode
        {
            AddNew =0, Update
        }

        enMode _Mode;

        clsAppointment _Appointment;
        
        int _AppointmentID;


        public frmAddEditAppointment(int AppointmentID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _Mode = (AppointmentID == -1 ? enMode.AddNew : enMode.Update);
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
        private void frmAddEditAppointment_Load(object sender, EventArgs e)
        {

            FillPationtsComboBox();
            FillDoctorsComboBox();

            cbDoctors.SelectedIndex = 0;
            cbPatients.SelectedIndex = 0;

            dtAppointmentDate.Value = DateTime.Now;

            if (_Mode == enMode.AddNew)
            {
                lblAddEditAppointment.Text = "Add New Appointment";
                lblAppointmentID.Text = "N/A";
                cbDoctors.SelectedIndex = -1;
                cbPatients.SelectedIndex = -1;
                _Appointment = new clsAppointment();
                return;
            }

            _Appointment = clsAppointment.FindByID(_AppointmentID);

            cbPatients.SelectedValue = _Appointment.PatientID;
            cbDoctors.SelectedValue = _Appointment.DoctorID;



            lblAddEditAppointment.Text = "Update Appointment";
            lblAppointmentID.Text = _AppointmentID.ToString();

            dtAppointmentDate.Value = _Appointment.AppointmentDateTime;

            txtReason.Text = _Appointment.Reason.ToString();
            txtNotes.Text = _Appointment.Notes.ToString();
        }

        private void UpdateAppointment()
        {
            DialogResult mBoxResult = MessageBox.Show("Are you sure you want to update this Appointment?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (mBoxResult == DialogResult.Yes)
            {
                if (_Appointment.Save())
                {
                    MessageBox.Show("Appointment Updated Successfully");
                }
                else MessageBox.Show("Faild to Update this appointment!");
            }
        }
        private void AddNewAppointment()
        {
            DialogResult mBoxResult = MessageBox.Show("Are you sure you want to Add this Appointment?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


            if (mBoxResult == DialogResult.Yes)
            {

                if (_Appointment.Save())
                {
                    _Mode = enMode.Update;
                    MessageBox.Show("Appointment Added Successfully");
                    lblAddEditAppointment.Text = "Update Appointment";
                    lblAppointmentID.Text = _Appointment.AppointmentID.ToString();  
                }
                else MessageBox.Show("Faild to Add this appointment!");
            }
        }
        private void Save()
        {

            _Appointment.PatientID = (int)cbPatients.SelectedValue;
            _Appointment.DoctorID = (int)cbDoctors.SelectedValue;
            _Appointment.AppointmentDateTime = new DateTime
                (
                    dtAppointmentDate.Value.Year,
                    dtAppointmentDate.Value.Month,
                    dtAppointmentDate.Value.Day,
                    dtAppointmentDate.Value.Hour,
                    dtAppointmentDate.Value.Minute,
                    0
                );
            _Appointment.Reason = txtReason.Text;
            _Appointment.Notes = txtNotes.Text;
            //_Appointment.Status = clsAppointment.enStatus.Scheduled;

            if (_Mode == enMode.AddNew)
            {
                AddNewAppointment();

            }
            else
            {
                UpdateAppointment();

            }
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
