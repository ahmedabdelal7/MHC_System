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
                    AddDoctorRowToDataGridView(doctorRow);

                }
            }
            dgvDoctors.SelectedCells[0].Selected = false;
            
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
        private void ShowAddForm()
        {
            Form frm = new frmAddEditDoctor(-1);
            frm.ShowDialog();
        }
        private void ShowEditForm()
        {

            int ID;
            try
            {
                ID = Convert.ToInt32(dgvDoctors.SelectedCells[0].Value);

            }
            catch
            {
                MessageBox.Show("Please select doctor first");
                return;
            }

            Form frm = new frmAddEditDoctor(ID);
            frm.ShowDialog();
        }
        private void ucDoctors_Load(object sender, EventArgs e)
        {
            _LoadDoctors();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
            _LoadDoctors();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
            _LoadDoctors();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            ShowAddForm();
            _LoadDoctors();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditForm();
            _LoadDoctors();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditForm();
            _LoadDoctors();
        }

        private void AddDoctorRowToDataGridView(DataRow doctorRow)
        {
            dgvDoctors.Rows.Add(
                    doctorRow["DoctorID"].ToString(),
                    doctorRow["FirstName"] + " " + doctorRow["LastName"],
                    doctorRow["Specialization"],
                    doctorRow["Phone"],
                    doctorRow["Email"]
                );
        }
        private void SearchByID(int ID)
        {
            clsDoctor doctor = clsDoctor.FindByID(ID);
            if(doctor != null)
            {
                dgvDoctors.Rows.Add(
                    doctor.DoctorID.ToString(),
                    doctor.FirstName + " " + doctor.LastName,
                    doctor.Specialization,
                    doctor.Phone,
                    doctor.Email
                );
            }/*else
                _LoadDoctors();*/
        }
        private void SearchByName(string Name)
        {
            DataTable DoctorsDT = clsDoctor.FindByName(Name);
            if(DoctorsDT != null)
            {
                foreach(DataRow doctorRow in DoctorsDT.Rows)
                {
                    AddDoctorRowToDataGridView(doctorRow);
                }
            }
            
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            string searchText = txtSearch.Text.ToString().Trim();

            if(searchText.Length > 0 && !string.IsNullOrWhiteSpace(searchText)) {

                        dgvDoctors.Rows.Clear();
                if(cbSearchBy.SelectedItem.ToString() == "ID")
                {
                    if (int.TryParse(searchText, out int ID))
                    {
                        SearchByID(ID);
                    }
                }

                if(cbSearchBy.SelectedItem.ToString() == "FirstName")
                {
                    searchText = txtSearch.Text.ToLower();
                    SearchByName(searchText);
                }
            }
            else
            {
                _LoadDoctors();
            }
        }
    }
}
