using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MentCareDataAccessLayer;

namespace MentCareBussinessLayer
{
    public class clsAppointment
    {

        enum enMode
        {
            AddNew = 0, Update
        }

        enMode _Mode;

        public enum enStatus
        {
            Scheduled = 1,
            Completed = 2,
            Cancelled = 3,
            NoShow = 4
        }
        public int AppointmentID {  get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Reason { get; set; }
        public string Notes { get; set; }
        public enStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }


        public clsAppointment()
        {
            AppointmentID = 0;
            PatientID = 0;
            DoctorID = 0;
            AppointmentDateTime = DateTime.Now;
            Reason = string.Empty;
            Notes = string.Empty;
            CreatedDate = DateTime.Now;
            Status = enStatus.Scheduled;

            _Mode = enMode.AddNew;
        }

        private clsAppointment(int AppointmentID, int PatientID, int DoctorID, DateTime AppointmentDateTime, enStatus Status, string Reason, string Notes, DateTime CreatedDate)
        {
            this.AppointmentID=AppointmentID;
            this.PatientID=PatientID;
            this.DoctorID =DoctorID;
            this.AppointmentDateTime =AppointmentDateTime;
            this.Reason =Reason;
            this.Notes =Notes;
            this.Status = Status;
            this.CreatedDate = CreatedDate;

            _Mode=enMode.Update;
        }

        private bool _AddNew()
        {

            if(!IsDoctorAvilable(DoctorID,AppointmentDateTime))
                return false;

            clsAppointmentData.stAppointment appointment = new clsAppointmentData.stAppointment();
            appointment.AppointmentID = AppointmentID;
            appointment.PatientID = PatientID;
            appointment.DoctorID = DoctorID;
            appointment.AppointmentDateTime = AppointmentDateTime;
            appointment.Reason = Reason;
            appointment.Notes = Notes;
            appointment.Status = (byte)Status;
            appointment.CreatedDate = CreatedDate;


            int ID = clsAppointmentData.AddNewAppointment(appointment);

            return ID >0;
        }

        private bool _Update() {

            /*if (!IsDoctorAvilable(DoctorID, AppointmentDateTime))
                return false;*/

            clsAppointmentData.stAppointment appointment = new clsAppointmentData.stAppointment();
            appointment.AppointmentID = AppointmentID;
            appointment.PatientID = PatientID;
            appointment.DoctorID = DoctorID;
            appointment.AppointmentDateTime = AppointmentDateTime;
            appointment.Reason = Reason;
            appointment.Notes = Notes;
            appointment.Status= (byte)Status;
            appointment.CreatedDate = CreatedDate;

            return clsAppointmentData.UpdateAppointment(appointment);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if(_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }return false;
                case enMode.Update:
                    return _Update();
            }
            return false;
        }


        public static clsAppointment FindByID(int ID)
        {
            clsAppointmentData.stAppointment stAppointment = new clsAppointmentData.stAppointment();  

            if(clsAppointmentData.FindAppointmentByID(ID,ref stAppointment))
            {
                return new clsAppointment(stAppointment.AppointmentID,stAppointment.PatientID,stAppointment.DoctorID,stAppointment.AppointmentDateTime,
                    (enStatus)stAppointment.Status,stAppointment.Reason,stAppointment.Notes,stAppointment.CreatedDate);
            }

            return null;
        }

        public static bool IsExist(int ID)
        {
            return clsAppointmentData.IsExist(ID);
        }
        public static bool Delete(int ID)
        {
            
            return (clsAppointmentData.DeleteAppointment(ID));
        }

        public static DataTable ListAllAppointments()
        {
            return clsAppointmentData.GetAllAppointments();
        }

        public static DataTable FindByPatientName(string PatientName)
        {
            return clsAppointmentData.FindAppointmentByPatientName(PatientName);
        }
        public static DataTable FindByDoctorName(string DoctorName)
        {
            return clsAppointmentData.FindAppointmentByDoctorName(DoctorName);
        }

        public static DataTable FindByID(string DoctorName)
        {
            return clsAppointmentData.FindAppointmentByID(DoctorName);
        }

        public static bool IsDoctorAvilable(int DoctorID, DateTime dateTime)
        {
            return clsAppointmentData.IsDoctorAvilable(DoctorID, dateTime);
        }

        public bool CancelAppointment()
        {
            if (_SetAppointmentStatus(enStatus.Cancelled))
                return Save();
            return false;
        }
        public bool CompleteAppointment()
        {
            if (_SetAppointmentStatus(enStatus.Completed))
                return Save();
            return false;
        }

        public bool MarkAppointmentAsNoShow()
        {
            if (_SetAppointmentStatus(enStatus.NoShow))
                return Save();
            return false;
        }

        public bool ReScheduleAppointment(DateTime NewAppoDateTime)
        {
            this.AppointmentDateTime = NewAppoDateTime;
            if( _SetAppointmentStatus(enStatus.Scheduled))
                return Save();
            return false;
        }
        private bool _SetAppointmentStatus(enStatus NewStatus)
        {
            //Here we Re schudule the appointment
            if (NewStatus == enStatus.Scheduled && this.Status == enStatus.NoShow)
            {
                this.Status = enStatus.Scheduled;
                return true;
            }
             
            //Set object status from schuduled to (Completed or Cancelled or NoShow)
            if(this.Status == enStatus.Scheduled)
            {
                this.Status= NewStatus;
                return true;
            }
            return false;
        }

        public static DataTable GetAppointmentsStatistics(int Patient)
        {
            return clsAppointmentData.GetAppointmentsStatisticsForPatient(Patient);
        }

        public static DataTable ListAllPatientAppointments(int PatientID)
        {
            return clsAppointmentData.GetAppointmentsByPatientID(PatientID);
        }

    }
}
