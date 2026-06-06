using Guna.UI2.WinForms;
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
      
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

       

        private void SetNavigationButtonsColor(Guna2Button selectedButton)
        {
            btnDoctors.ForeColor = Color.White;
            btnDoctors.FillColor = Color.Transparent;

            btnPatients.ForeColor = Color.White;
            btnPatients.FillColor = Color.Transparent;

            btnConsultations.ForeColor = Color.White;
            btnConsultations.FillColor = Color.Transparent;

            selectedButton.ForeColor = Color.FromArgb(213, 185, 87);
            selectedButton.FillColor = Color.FromArgb(45, 45, 60);
        }
        private void btnPatients_Click(object sender, EventArgs e)
        {
            pnlContainer.Controls.Clear();
            ucPatientscs Patients = new ucPatientscs();
            Patients.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(Patients);

            SetNavigationButtonsColor((Guna2Button)sender);           

        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            //Initiate doctors user control
            ucDoctors doctors = new ucDoctors();
            doctors.Dock = DockStyle.Fill;

            //clear Contaner panel
            pnlContainer.Controls.Clear();
            //add doctors User Control
            pnlContainer.Controls.Add(doctors);

            SetNavigationButtonsColor((Guna2Button)sender);

        }

        private void btnConsultations_Click(object sender, EventArgs e)
        {

            ucConsultations consultations = new ucConsultations();
            consultations.Dock = DockStyle.Fill;    

            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(consultations);
            SetNavigationButtonsColor((Guna2Button)sender);


        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
