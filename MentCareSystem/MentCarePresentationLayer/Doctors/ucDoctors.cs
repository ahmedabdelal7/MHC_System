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

            dgvDoctors.Columns.Clear();

            dgvDoctors.DataSource = doctorsDT;
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

        private void SearchByID(string ID)
        {
            DataTable DoctorsDT = clsDoctor.FindByID(ID);

            dgvDoctors.DataSource = DoctorsDT;

        }
        private void SearchByName(string Name)
        {
            DataTable DoctorsDT = clsDoctor.FindByName(Name);

            dgvDoctors.DataSource= DoctorsDT;
            
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            string searchText = txtSearch.Text.ToString().Trim();

            if(searchText.Length > 0 && !string.IsNullOrWhiteSpace(searchText)) {

                if(cbSearchBy.SelectedItem.ToString() == "ID")
                {
                    if (int.TryParse(searchText, out int ID))
                        SearchByID(searchText);
                    return;
                }

                if(cbSearchBy.SelectedItem.ToString() == "Name")
                {
                    SearchByName(txtSearch.Text.ToLower());
                }
            }
            else
                _LoadDoctors();

        }

    }
}
