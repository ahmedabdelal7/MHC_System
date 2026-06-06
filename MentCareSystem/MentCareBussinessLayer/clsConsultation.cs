using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MentCareBussinessLayer
{
    internal class clsConsultation
    {

        enum enMode
        {
            AddNew =0, Update =1
        }
        enMode _Mode;
        public int ConsultationID { get; set; }
        public int PatientID { get;set; }
        public int DoctorID { get;set; }
        public DateTime ConsultationDate { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }
        public string TreatmentPlan { get; set; }


        public clsConsultation()
        {
            ConsultationID = 0;
            PatientID = 0;
            DoctorID = 0;
            ConsultationDate = DateTime.Now;
            Diagnosis = string.Empty;
            Notes = string.Empty;
            TreatmentPlan = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsConsultation(int ConsultationID, int PatientID, int DoctorID, DateTime ConsultationDate, 
            string Diagnosis, string Notes , string TreatmentPlan)
        {
            this.ConsultationID = ConsultationID;
            this.PatientID = PatientID;
            this.DoctorID = DoctorID;
            this.ConsultationDate = ConsultationDate;
            this.Diagnosis = Diagnosis;
            this.Notes = Notes;
            this.TreatmentPlan = TreatmentPlan;
        }


    }
    
}
