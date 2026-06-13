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
           

        }

        private void _LoadPatientDetails()
        {
           


        }

        private void _LoadData() {
            
            clsPatient patient = clsPatient.FindByID(_PatientID);

            lblPatientID.Text = $"(#{_PatientID})";
            lblPatientName.Text = $"{patient.FirstName} {patient.LastName}";

            //Quick Statics:



            //


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
