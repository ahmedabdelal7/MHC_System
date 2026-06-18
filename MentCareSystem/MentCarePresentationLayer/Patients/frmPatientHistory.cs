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
    public partial class frmPatientHistory : Form
    {

        int _PatientID;
        public frmPatientHistory(int patientID)
        {
            InitializeComponent();

            _PatientID = patientID;
        }

        private void frmPatientHistory_Load(object sender, EventArgs e)
        {

            _LoadData();
        }

        private void _LoadPatientDetails()
        {
           


        }

        private void _LoadData() {
            
            clsPatient patient = clsPatient.FindByID(_PatientID);

            lblPatientID.Text = $"(#{_PatientID})";
            lblPatientName.Text = $"{patient.FirstName} {patient.LastName}";

            //Quick Statics:
            lblConsultations.Text = clsConsultation.GetConsultationsCount(_PatientID).ToString();

            DataRow statisticsrow = clsAppointment.GetAppointmentsStatistics(_PatientID).Rows[0];

            lblAppointments.Text = statisticsrow["TotalAppointments"].ToString();
            lblCompleted.Text = statisticsrow["Completed"].ToString();
            lblCancelled.Text = statisticsrow["Cancelled"].ToString();
            lblNoShow.Text = statisticsrow["NoShow"].ToString();


            clsConsultation lastConsultation = clsConsultation.GetLastConsultation(_PatientID);

            if(lastConsultation != null)
            {
                txtDoctorName.FastText = patient.FirstName + " " + patient.LastName;
                txtDiagnosis.FastText  = lastConsultation.Diagnosis;
                txtTreatment.FastText = lastConsultation.TreatmentPlan;
                txtDate.FastText = lastConsultation.ConsultationDate.ToString();
            } 

            //Appointments - Consultatons DGV


            dgvConsultations.Columns.Clear();
            dgvAppointments.Columns.Clear();
            dgvAppointments.DataSource = clsAppointment.ListAllPatientAppointments(_PatientID);
            dgvConsultations.DataSource = clsConsultation.ListAllPatientConsultations(_PatientID);
            s

        }

        private void pnlPatientDetails_Paint(object sender, PaintEventArgs e)
        {
            _LoadData();
        }

        private void fuiTable1_Load(object sender, EventArgs e)
        {

        }
    }
}
