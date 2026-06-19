using MentCareBussinessLayer;
using MentCarePresentationLayer.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MentCarePresentationLayer
{
    public partial class ucPatientscs : UserControl
    {

        public ucPatientscs()
        {
            InitializeComponent();
        }

        private void ucPatientscs_Load(object sender, EventArgs e)
        {
            _LoadPatients();
        }

        private void _LoadPatients()
        {
            dgvPatients.Columns.Clear();
            DataTable PatientsDT = clsPatient.ListAllPatients();
            dgvPatients.DataSource = PatientsDT;
            dgvPatients.SelectedCells[0].Selected = false;
        }

        /// Function
        private int GetSelectedPatientID()
        {
            int PatientID;
            try
            {
                PatientID = Convert.ToInt32(dgvPatients.SelectedCells[0].Value);
            }
            catch
            {
                return -1;
            }

            return PatientID;
        }
        private void AddNewPatient()
        {
            frmAddEditPatient frm = new frmAddEditPatient(-1);
            frm.ShowDialog();
        }
        private void Edit()
        {
            int PatientID = GetSelectedPatientID();

            if (PatientID == -1)
            {
                MessageBox.Show("Please Select Patient First");
                return;
            }

            frmAddEditPatient frm = new frmAddEditPatient(PatientID);
            frm.ShowDialog();
        }
        private void Delete()
        {

            int PatientID = GetSelectedPatientID();

            if(PatientID == -1)
            {
                MessageBox.Show("Please Select Patient First");
                return;
            }



            DialogResult result = MessageBox.Show($"Are you sure you want to patient: [{PatientID}] ?", "Confirm Delete",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (!clsPatient.IsPatientExist(PatientID))
                {
                    MessageBox.Show("Patient deos not exists!");
                    return;
                }
                if (clsPatient.DeletePatient(PatientID))
                    MessageBox.Show("Patient Deleted Successfully.");
                else
                    MessageBox.Show("Faild to Delete");
            }
        }
        private void SearchByID(string patientID)
        {
            DataTable patientsDT = clsPatient.FindByID(patientID);
            dgvPatients.DataSource = patientsDT;
        }
        private void SearchByName(string firstName)
        {
            
            DataTable patientsDT = clsPatient.FindByName(firstName);
            dgvPatients.DataSource = patientsDT;
        }
        private void SearchByPhone(string phoneNumber)
        {
            DataTable patientsDT = clsPatient.FindByPhone(phoneNumber);
            dgvPatients.DataSource = patientsDT;
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToString().Trim();

            if (txtSearch.Text.Length > 0 && !string.IsNullOrWhiteSpace(searchText))
            {
                if (cbSearchBy.SelectedItem.ToString() == "ID")
                {
                    if (int.TryParse(searchText, out int patientID))
                        SearchByID(searchText);
                    return;
                }
                else if (cbSearchBy.SelectedItem.ToString() == "Name")
                {
                    SearchByName(searchText.ToLower());
                    return;
                }
                else if (cbSearchBy.SelectedItem.ToString() == "Phone")
                {

                    SearchByPhone(searchText);
                    return;
                }
            }
            else _LoadPatients();
        }
        private void ShowPatientHistory()
        {
            int PatientID = GetSelectedPatientID();

            if (PatientID == -1)
            {
                MessageBox.Show("Please Select Patient First");
                return;
            }
            if (!clsPatient.IsPatientExist(PatientID))
            {
                MessageBox.Show("Patient doest exist!");
                _LoadPatients();
                return;
            }

            Form frmPatientHistory = new frmPatientHistory(PatientID);
            frmPatientHistory.ShowDialog();



        }
        private void ShowPatientDetails()
        {

            int PatientID = GetSelectedPatientID();

            if (PatientID == -1)
            {
                MessageBox.Show("Please Select Patient First");
                return;
            }
            if (!clsPatient.IsPatientExist(PatientID))
            {
                MessageBox.Show("Patient doest exist!");
                _LoadPatients();
                return;
            }

            Form frmPatientDetails = new frmPatientDetails(PatientID);
            frmPatientDetails.ShowDialog();

        }

        /// Events
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
            _LoadPatients();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewPatient();
            _LoadPatients();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
            _LoadPatients();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit();
            _LoadPatients();
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
            _LoadPatients();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Edit();
            _LoadPatients();
        }
        private void patientHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPatientHistory();
        }
        private void patientDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPatientDetails();
        }
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Delete();
            _LoadPatients();
        }
        private void newPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewPatient();
            _LoadPatients();
        }
        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewPatient();
            _LoadPatients();
        }

        private void patientDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowPatientDetails();
        }

        private void patientHistoryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowPatientHistory();
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowPatientDetails();
        }

        private void addNewAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
            
            Form frm = new frmAddEditAppointment(-1);
            frm.ShowDialog();
            _LoadPatients();
        }

        private void newAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditAppointment(-1);
            frm.ShowDialog();
            _LoadPatients();
        }
    }

    
}
