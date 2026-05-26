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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
           

        }


    /*    private void _LoadAllPatients()
        {
            DataTable PatientsDT = clsPatient.ListAllPatients();

            listView1.Items.Clear();
            foreach (DataRow recordRow in PatientsDT.Rows) {

                
                ListViewItem item = new ListViewItem(recordRow["PatientID"].ToString());
                item.SubItems.Add(recordRow["FirstName"].ToString());
                item.SubItems.Add(recordRow["LastName"].ToString());
                item.SubItems.Add(recordRow["Gender"].ToString());
                item.SubItems.Add(recordRow["DateOfBirth"].ToString());
                item.SubItems.Add(recordRow["Phone"].ToString());
                item.SubItems.Add(recordRow["Address"].ToString());
                item.SubItems.Add(recordRow["EmergencyContact"].ToString());

                listView1.Items.Add(item);

            }          

        }*/
   
       /* private void DeletePatient()
        {
            try
            {
                //int patientID = clsPatient.Find(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text)).PatientID;

                DialogResult mBoxResult = MessageBox.Show("Are you sure you want to Delete this patient?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (mBoxResult == DialogResult.Yes)
                {

                    if (clsPatient.DeletePatient(patientID))
                    {
                        _LoadAllPatients();

                        MessageBox.Show("Patient Deleted Successfully.");
                    }
                    else
                        MessageBox.Show("Faild to Delete Patient");

                }
            }
            catch
            {
                MessageBox.Show("Please Select Patient First.");
            }
        }*/

        private void EditPatient()
        {
            try
            {
                /*int patientID = clsPatient.Find(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text)).PatientID;

                Form frmEdit = new frmAddEditPatient(patientID);
                frmEdit.ShowDialog();
                _LoadAllPatients();*/

            }
            catch
            {
                MessageBox.Show("Please Select Patient First.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            EditPatient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //_LoadAllPatients();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            /*Form frmEdit = new frmAddEditPatient(-1);
            frmEdit.ShowDialog();
            _LoadAllPatients();*/
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            //DeletePatient();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DeletePatient();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EditPatient();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            pnlContainer.Controls.Clear();
            ucPatientscs Patients = new ucPatientscs();
            Patients.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(Patients);
        }
    }
}
