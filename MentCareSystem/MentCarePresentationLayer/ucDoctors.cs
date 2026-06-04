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
    public partial class ucDoctors : UserControl
    {
        public ucDoctors()
        {
            InitializeComponent();
        }

        //private int DoctorID = -1;

        private void _LoadDoctors()
        {
            DataTable doctorsDT = clsDoctor.ListAllDoctors();

            dgvDoctors.Rows.Clear();

            if (doctorsDT != null)
            {
                foreach (DataRow doctorRow in doctorsDT.Rows)
                {
                    dgvDoctors.Rows.Add(doctorRow["DoctorID"], doctorRow["FirstName"] + " " + doctorRow["LastName"],
                        doctorRow["Specialization"], doctorRow["Phone"], doctorRow["Email"]);
                }
            }
            dgvDoctors.SelectedCells[0].Selected = false;
            
        }
        private void ucDoctors_Load(object sender, EventArgs e)
        {
            _LoadDoctors();
        }

        private void Delete()
        {
           
            int DoctorID;
            try
            {
                DoctorID = Convert.ToInt32(dgvDoctors.SelectedCells[0].Value);
            }
            catch
            {
                MessageBox.Show("Please Select Doctor First!");
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to Doctor: [{DoctorID}] ?", "Confirm Delete",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (!clsDoctor.IsDoctorExist(DoctorID))
                {
                    MessageBox.Show("Doctor does not exists!");
                    return;
                }
                if (clsDoctor.Delete(DoctorID))
                    MessageBox.Show("Doctor Deleted Successfully.");
                else
                    MessageBox.Show("Faild to Delete");
            }


        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
            _LoadDoctors();


        }

        private void dgvDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
            _LoadDoctors();
        }
    }
}
