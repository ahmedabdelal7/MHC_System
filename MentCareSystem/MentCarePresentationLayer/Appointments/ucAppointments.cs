using MentCareBussinessLayer;
using MentCarePresentationLayer.Appointments;
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

        private clsAppointment GetSelectedAppointment()
        {
            return clsAppointment.FindByID(Convert.ToInt32(dgvAppointments.SelectedCells[0].Value));
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


        private bool CompleteAppointment(clsAppointment appointment)
        {

            DialogResult dialogResult = MessageBox.Show($"Are You Sure You Want To Complete This Appointment [{appointment.AppointmentID}] ?",
                "Confirm Message", MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


            if (dialogResult != DialogResult.Yes)
                return false;

            if (!clsAppointment.IsExist(appointment.AppointmentID))
                return false;

            return (appointment.CompleteAppointment());

        }

        private bool CancelAppointment(clsAppointment appointment)
        {

            DialogResult dialogResult = MessageBox.Show($"Are You Sure You Want To Cancel This Appointment [{appointment.AppointmentID}] ?",
                "Confirm Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


            if (dialogResult != DialogResult.Yes)
                return false;

            if (!clsAppointment.IsExist(appointment.AppointmentID))
                return false;

            return (appointment.CancelAppointment());

        }

        private bool MarkAppointmentAsNoShow(clsAppointment appointment)
        {

            DialogResult dialogResult = MessageBox.Show($"Are You Sure You Want To Mark This Appointment As NoShow [{appointment.AppointmentID}] ?",
                "Confirm Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


            if (dialogResult != DialogResult.Yes)
                return false;

            if (!clsAppointment.IsExist(appointment.AppointmentID))
                return false;

            return (appointment.MarkAppointmentAsNoShow());

        }

        private bool ReSceduleAppointment(clsAppointment appointment, DateTime NewAppDateTime)
        {

            DialogResult dialogResult = MessageBox.Show($"Are You Sure You Want To ReScedule This Appointment [{appointment.AppointmentID}] ?",
                "Confirm Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


            if (dialogResult != DialogResult.Yes)
                return false;

            if (!clsAppointment.IsExist(appointment.AppointmentID))
                return false;

            return (appointment.ReScheduleAppointment(NewAppDateTime));

        }

        private void CompleteAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAppointment appointment = GetSelectedAppointment();;


            if (CompleteAppointment(appointment))
                MessageBox.Show($"Appointment [{appointment.AppointmentID}] Marked As (Completed) Successfully.");
            else MessageBox.Show($"Operation Not Succeded!");

            _LoadData();


        }

        private void cancelAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            clsAppointment appointment = GetSelectedAppointment();;


            if (CancelAppointment(appointment))
                MessageBox.Show($"Appointment [{appointment.AppointmentID}] Marked As (Cancelled) Successfully.");
            else MessageBox.Show($"Operation Not Succeded!");

            _LoadData();
        }

        private void markAsNoShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAppointment appointment = GetSelectedAppointment();;


            if (MarkAppointmentAsNoShow(appointment))
                MessageBox.Show($"Appointment [{appointment.AppointmentID}] Marked As (NoShow) Successfully.");
            else MessageBox.Show($"Operation Not Succeded!");

            _LoadData();
        }

        private void rescheduleAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAppointment appointment = GetSelectedAppointment();;

            frmRescheuleAppointment frm = new frmRescheuleAppointment();
            DateTime newDate;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                newDate = frm.NewAppointmentDateTime;
                newDate = new DateTime
                (
                    newDate.Year,
                    newDate.Month,
                    newDate.Day,
                    newDate.Hour,
                    newDate.Minute,
                    0
                );


                if (ReSceduleAppointment(appointment, newDate))
                {
                    MessageBox.Show($"Appointment [{appointment.AppointmentID}] Marked As (Scheduled) Successfully.");
                    _LoadData();

                }

            }
            else MessageBox.Show($"Operation Not Succeded!");

            

        }
        private void _UpdateContextMenu()
        {
            clsAppointment appointment = GetSelectedAppointment();;
            if (appointment == null)
            {
                cmsAppointments.Visible = false;
                return;
            }

            cmComplete.Enabled = appointment.Status == clsAppointment.enStatus.Scheduled;
            cmCancel.Enabled = appointment.Status == clsAppointment.enStatus.Scheduled;
            cmNoShow.Enabled = appointment.Status == clsAppointment.enStatus.Scheduled;

            cmReschedule.Enabled = appointment.Status == clsAppointment.enStatus.NoShow;
        }
        private void cmsAppointments_Opening(object sender, CancelEventArgs e)
        {
            _UpdateContextMenu();

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!");
        }
    }
}
