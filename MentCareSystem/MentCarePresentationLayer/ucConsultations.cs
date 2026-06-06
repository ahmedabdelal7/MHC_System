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
            dgvConsultations.Rows.Clear();

            DataTable ConsultationsDT  = clsConsultation.ListAllConsultations();

            foreach (DataRow consultationRow in ConsultationsDT.Rows)
            {
                AddConsultationRowToDataGridView(consultationRow);
            }
            dgvConsultations.SelectedCells[0].Selected = false;

        }

        private void AddConsultationRowToDataGridView(DataRow row)
        {
            DateTime date = (DateTime)row["ConsultationDate"];
            dgvConsultations.Rows.Add(
                row["ConsultationID"],
                row["PatientName"],
                row["DoctorName"],
                $"{date.ToShortDateString()}  {date.ToShortTimeString()}"
            );
        }


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

        private void AddNew()
        {
            Form frm = new frmAddEditConsultation(-1);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
