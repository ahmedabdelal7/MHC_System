using System;
using System.Data;
using System.Web;
using MentCareDataAccessLayer;

namespace MentCareBussinessLayer
{
    public class clsConsultation
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

            _Mode = enMode.Update;
        }

        private bool _AddNewConsultation()
        {
            clsConsultationData.stConsultation consultation = new clsConsultationData.stConsultation();

            //consultation.ConsultationID = ConsultationID;
            consultation.PatientID = PatientID;
            consultation.DoctorID= DoctorID;
            consultation.ConsultationDate= ConsultationDate;
            consultation.Diagnosis = Diagnosis;
            consultation.Notes = Notes;
            consultation.TreatmentPlan= TreatmentPlan;

            this.ConsultationID = clsConsultationData.AddConsultation(consultation);
            return this.ConsultationID > 0;
        }
        private bool _UpdateConsultation()
        {
            clsConsultationData.stConsultation consultation = new clsConsultationData.stConsultation();
            consultation.ConsultationID = ConsultationID;
            consultation.PatientID = PatientID;
            consultation.DoctorID = DoctorID;
            consultation.ConsultationDate = ConsultationDate;
            consultation.Diagnosis = Diagnosis;
            consultation.Notes = Notes;
            consultation.TreatmentPlan = TreatmentPlan;

            return clsConsultationData.UpdateConsultation(consultation);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewConsultation())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }return false;
                case enMode.Update:
                    return _UpdateConsultation();

            }
            return false;
        }
        public static bool Delete(int ID)
        {
            return (clsConsultationData.DeleteConslutation(ID));
        }
        public static DataTable ListAllConsultations() {

           return  clsConsultationData.GetAllConsultations(); 
        }
        public static bool IsExist(int ID)
        {
            return clsConsultationData.IsConsultationExist(ID);
        }

        public static clsConsultation FindByID(int ID)
        {
            clsConsultationData.stConsultation consultation = new clsConsultationData.stConsultation();

            if(clsConsultationData.FindConsultationByID(ID,ref consultation))
            {
                return new clsConsultation(consultation.ConsultationID, consultation.PatientID, consultation.DoctorID,
                    consultation.ConsultationDate, consultation.Diagnosis, consultation.Notes, consultation.TreatmentPlan);
            }
            return null;
        }

        public static DataTable FindByID(string ID)
        {
            return clsConsultationData.FindConsultationByID(ID);
        }

        public static DataTable FindByPatientName(string PatientName)
        {
            return clsConsultationData.FindByPatientName(PatientName);
        }
        public static DataTable FindByDoctorName(string DoctorName)
        {
            return clsConsultationData.FindByDoctorName(DoctorName);
        }
    }
    
}
