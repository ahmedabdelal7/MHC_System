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
        
            
    }
}
