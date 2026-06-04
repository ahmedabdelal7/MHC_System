using MentCareBussinessLayer;
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
            dgvPatients.Rows.Clear();
            DataTable PatientsDT = clsPatient.ListAllPatients();

            foreach (DataRow PatientRecord in PatientsDT.Rows) {



                dgvPatients.Rows.Add(
                    PatientRecord["PatientID"],
                    PatientRecord["FirstName"] + " " + PatientRecord["LastName"],
                    PatientRecord["Phone"],
                    PatientRecord["Gender"]
                );
            }
            dgvPatients.SelectedCells[0].Selected = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPatient frm = new frmAddEditPatient(-1);
            frm.ShowDialog();
            _LoadPatients();
        }
        
        private void Edit()
        {
            int PatientID;
            try
            {
                PatientID = Convert.ToInt32(dgvPatients.SelectedCells[0].Value);
            }
            catch
            {
                MessageBox.Show("Please Select Patient First");
                return;
            }


            frmAddEditPatient frm = new frmAddEditPatient(PatientID);
            frm.ShowDialog();
        }

        private void Delete()
        {
            int PatientID ;
            try
            {
                PatientID = Convert.ToInt32(dgvPatients.SelectedCells[0].Value);
            }
            catch
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
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
        private void SearchByID(int patientID)
        {
            clsPatient patient;

            patient = clsPatient.FindByID(patientID);
            if(patient != null)
            {
                AddPatientToDataGridView(patient);
            }

        }

        private void AddPatientToDataGridView(clsPatient patient)
        {
            dgvPatients.Rows.Add(
                patient.PatientID,
                patient.FirstName +" "+patient.LastName,
                patient.Phone,
                patient.Gender
            );
        }
        private clsPatient FillPatientObjectFromDataRow( DataRow patientRow)
        {
            clsPatient patient = new clsPatient();

            patient.PatientID = (int)patientRow["PatientID"];
            patient.FirstName = patientRow["FirstName"].ToString();

            patient.LastName = (patientRow["LastName"] != DBNull.Value) ? (patientRow["LastName"].ToString()) : (patient.LastName = "");
            patient.Gender = patientRow["Gender"].ToString();
            patient.DateOfBirth = (DateTime)patientRow["DateOfBirth"];
            patient.Phone = patientRow["Phone"].ToString() ;

            patient.Address = (patientRow["Address"] != DBNull.Value) ? (patientRow["Address"].ToString()) : (patient.Address = "");
            patient.EmergencyContact = (patientRow["EmergencyContact"] != DBNull.Value) ? (patientRow["EmergencyContact"].ToString()) : (patient.EmergencyContact = "");

            return patient;

        }
        private void SearchByFirstName(string firstName)
        {
            clsPatient patient;

            DataTable patientsDT = clsPatient.FindByFirstName(firstName);

            if(patientsDT != null)
            {
                foreach(DataRow patientRow in patientsDT.Rows)
                {
                    patient = FillPatientObjectFromDataRow(patientRow);
                    AddPatientToDataGridView(patient);
                }
            }
        }
        private void SearchByPhone(string phoneNumber)
        {
            clsPatient patient;

            DataTable patientsDT = clsPatient.FindByPhone(phoneNumber);

            if (patientsDT != null)
            {
                foreach (DataRow patientRow in patientsDT.Rows)
                {
                    patient = FillPatientObjectFromDataRow(patientRow);
                    AddPatientToDataGridView(patient);
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Thread.Sleep(500);
            string searchText = txtSearch.Text.ToString().Trim();

            if (txtSearch.Text.Length > 0 && !string.IsNullOrWhiteSpace(searchText))
            {
                dgvPatients.Rows.Clear(); //Clear DataGrid From Results

                if (cbSearchBy.SelectedItem.ToString() == "ID")
                {
                    if (int.TryParse(searchText, out int patientID))
                        SearchByID(patientID);                    

                }
                else if (cbSearchBy.SelectedItem.ToString() == "FirstName")
                {
                    SearchByFirstName(searchText.ToLower());
                }
                else if (cbSearchBy.SelectedItem.ToString() == "Phone"){

                    SearchByPhone(searchText);
                }
            }
            else
                _LoadPatients();

            

        }

    }

    
}
