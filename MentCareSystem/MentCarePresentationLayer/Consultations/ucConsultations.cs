using System;
using MentCareBussinessLayer;
using System.Windows.Forms;
using System.Data;

namespace MentCarePresentationLayer
{
    public partial class ucConsultations : UserControl
    {
        public ucConsultations()
        {
            InitializeComponent();
        }

        private void ucConsultations_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            dgvConsultations.Columns.Clear();

            DataTable ConsultationsDT  = clsConsultation.ListAllConsultations();

            dgvConsultations.DataSource = ConsultationsDT;

            //dgvConsultations.SelectedCells[0].Selected = false;

        }


        private void ShowAddForm()
        {
            Form frm = new frmAddEditConsultation(-1);
            frm.ShowDialog();
        }
        //Show Edit Consltation Form.
        private void ShowEditForm()
        {

            int ID;
            try
            {
                ID = Convert.ToInt32(dgvConsultations.SelectedCells[0].Value);

            }
            catch
            {
                MessageBox.Show("Please select consultation first");
                return;
            }

            Form frm = new frmAddEditConsultation(ID);
            frm.ShowDialog();
        }

        //Delete Consltation.
        private void Delete()
        {
            if (dgvConsultations.SelectedCells.Count < 1)
            {
                MessageBox.Show("Please Select Consultation First!");
                return;
            }

            int ConsultationID = Convert.ToInt32(dgvConsultations.SelectedCells[0].Value);
            //clsConsultation consultation = clsConsultation.FindByID(ConsultationID);

            DialogResult result =  MessageBox.Show($"Are you sure you want to delete this consultation [{ConsultationID}]?","Confirm",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);


            if (result == DialogResult.Yes)
            {
                if (!clsConsultation.IsExist(ConsultationID))
                {
                    MessageBox.Show("Faild, this consultation not founded!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                if (clsConsultation.Delete(ConsultationID))
                    MessageBox.Show("Consultation deleted successfully.");
                else MessageBox.Show("Faild to delete consultation","Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
            _LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowAddForm();
            _LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditForm();
            _LoadData();
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

        private void SearchByID(string consultationID)
        {

            dgvConsultations.DataSource = clsConsultation.FindByID(consultationID);
        }

        private void SearchByPatientName(string patientName)
        {
            dgvConsultations.DataSource = clsConsultation.FindByPatientName(patientName);
        }

        private void SearchByDoctorName(string doctorName)
        {
            dgvConsultations.DataSource = clsConsultation.FindByDoctorName(doctorName);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            string searchText = txtSearch.Text.ToString().Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                 _LoadData();
                return;
            }

            if(cbSearchBy.SelectedItem.ToString() == "ID"){

                if (int.TryParse(searchText, out int ID))
                    SearchByID(searchText);
                return;
            }

            if(cbSearchBy.SelectedItem.ToString() == "PatientName")
            {
                SearchByPatientName(searchText.ToLower());
                return;
            }

            if((cbSearchBy.SelectedItem.ToString() == "DoctorName")){

                SearchByDoctorName(searchText.ToLower());
                return;
            }

        }
    }
}
