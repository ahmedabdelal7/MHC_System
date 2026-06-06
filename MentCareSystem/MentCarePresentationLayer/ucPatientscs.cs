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
            dgvPatients.Columns.Clear();
            DataTable PatientsDT = clsPatient.ListAllPatients();
            dgvPatients.DataSource = PatientsDT;
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
        private void txtSearch_TextChanged(object sender, EventArgs e)
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
                else if (cbSearchBy.SelectedItem.ToString() == "Phone"){

                    SearchByPhone(searchText);
                    return;
                }
            }
            else
                _LoadPatients();            

        }

    }

    
}
