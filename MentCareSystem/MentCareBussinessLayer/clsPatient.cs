using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MentCareDataAccessLayer;

namespace MentCareBussinessLayer
{
    public class clsPatient
    {

        enum enMode
        {
            AddNew = 0, Update = 1, Delete = 2
        }

        enMode _Mode;
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone {  get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }

        public clsPatient()
        {
            PatientID = -1;
            FirstName = "";
            LastName = "";
            Gender = "";
            DateTime DateOfBirth = DateTime.MinValue;
            Phone = string.Empty;
            Address = string.Empty;
            EmergencyContact = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsPatient(int PatientID, string FirstName, string LastName, string Gender, DateTime DateOfBirth,
            string Phone, string Address, string EmergencyContact)
        {

            this.PatientID = PatientID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.DateOfBirth = DateOfBirth;
            this.Phone = Phone;
            this.Address = Address;
            this.EmergencyContact = EmergencyContact;

            _Mode = enMode.Update;

        }

        public bool _AddNewPatient()
        {
            this.PatientID = clsPatientsData.AddPatient(this.FirstName,this.LastName,this.Gender,this.DateOfBirth,this.Phone,this.Address,this.EmergencyContact);

            return PatientID > 0;
        }

        public static  clsPatient FindByID(int PatientID)
        {

             string FirstName = "", LastName = "", Gender = "", Phone = "", Address = "", EmergencyContact = ""; 
             DateTime DateOfBirth = DateTime.Now;

             //clsPatient patient = new clsPatient();

            if (clsPatientsData.GetPatientByID(PatientID, ref FirstName, ref LastName, ref Gender, ref DateOfBirth, ref Phone, ref Address, ref EmergencyContact))
            {
                return new clsPatient(PatientID, FirstName, LastName, Gender, DateOfBirth, Phone, Address, EmergencyContact);
            }else
                return null;

        }

        public static DataTable FindByFirstName(string FirstName)
        {
            return clsPatientsData.GetPatientByFirstName(FirstName);
        }

        public static DataTable FindByPhone(string Phone)
        {
            return clsPatientsData.GetPatientByPhoneNumber(Phone);
        }

        public static bool IsPatientExist(int PatientID)
        {
            return clsPatientsData.IsPatientExist(PatientID);
        }

        public bool _UpdatePatient()
        {
            return clsPatientsData.UpdatePatient(this.PatientID,this.FirstName, this.LastName, this.Gender, this.DateOfBirth, this.Phone, this.Address, this.EmergencyContact);
        }

        public static bool DeletePatient(int PatientID)
        {
            return clsPatientsData.DeletePatient(PatientID);
        }

        public static DataTable ListAllPatients()
        {
            return clsPatientsData.GetAllPatient();
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPatient())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }else
                        return false;

                case enMode.Update:
                    return _UpdatePatient();

                    
            }
            return false;

        }

    }
}
