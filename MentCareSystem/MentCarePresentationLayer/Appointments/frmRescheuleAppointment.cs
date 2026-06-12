using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MentCarePresentationLayer.Appointments
{
    public partial class frmRescheuleAppointment : Form
    {
        public frmRescheuleAppointment()
        {
            InitializeComponent();
        }
        public DateTime NewAppointmentDateTime
        {
            get;
            private set;
        }

        private void frmRescheuleAppointment_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            NewAppointmentDateTime = dtAppointmentDate.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
