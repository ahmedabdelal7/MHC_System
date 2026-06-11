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
    public partial class ucAppointments : UserControl
    {
        public ucAppointments()
        {
            InitializeComponent();
        }

        private void ucAppointments_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            dgvAppointments.Columns.Clear();
            dgvAppointments.DataSource = clsAppointment.ListAllAppointments();
        }

        private void ShowAddForm()
        {
            Form frm = new frmAddEditAppointment(-1);
            frm.ShowDialog();
        }
        //Show Edit Consltation Form.
        private void ShowEditForm()
        {

            int ID;
            try
            {
                ID = Convert.ToInt32(dgvAppointments.SelectedCells[0].Value);

            }
            catch
            {
                MessageBox.Show("Please select appointment first");
                return;
            }

            Form frm = new frmAddEditAppointment(ID);
            frm.ShowDialog();
        }

        //Delete Consltation.
        private void Delete()
        {
            if (dgvAppointments.SelectedCells.Count < 1)
            {
                MessageBox.Show("Please Select Appointment First!");
                return;
            }

            int AppointmentID = Convert.ToInt32(dgvAppointments.SelectedCells[0].Value);
            //clsConsultation consultation = clsConsultation.FindByID(ConsultationID);

            DialogResult result = MessageBox.Show($"Are you sure you want to delete this appointment [{AppointmentID}]?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);


            if (result == DialogResult.Yes)
            {
                if (!clsAppointment.IsExist(AppointmentID))
                {
                    MessageBox.Show("Faild, this appointment not founded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (clsAppointment.Delete(AppointmentID))
                    MessageBox.Show("appointment deleted successfully.");
                else MessageBox.Show("Faild to delete appointment", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditForm();
            _LoadData();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
            _LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowAddForm();
            _LoadData();
        }

        private void addNewAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddForm();
            _LoadData();
        }

        private void SearchByID(string consultationID)
        {

            dgvAppointments.DataSource = clsAppointment.FindByID(consultationID);
        }

        private void SearchByPatientName(string patientName)
        {
            dgvAppointments.DataSource = clsAppointment.FindByPatientName(patientName);
        }

        private void SearchByDoctorName(string doctorName)
        {
            dgvAppointments.DataSource = clsAppointment.FindByDoctorName(doctorName);
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToString().Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                _LoadData();
                return;
            }

            if (cbSearchBy.SelectedItem.ToString() == "ID")
            {

                if (int.TryParse(searchText, out int ID))
                    SearchByID(searchText);
                return;
            }

            if (cbSearchBy.SelectedItem.ToString() == "PatientName")
            {
                SearchByPatientName(searchText.ToLower());
                return;
            }

            if ((cbSearchBy.SelectedItem.ToString() == "DoctorName"))
            {

                SearchByDoctorName(searchText.ToLower());
                return;
            }
        }
    }
}
