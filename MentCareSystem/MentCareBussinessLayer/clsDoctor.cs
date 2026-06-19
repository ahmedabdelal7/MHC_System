using MentCareDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MentCareBussinessLayer
{
    public class clsDoctor
    {
        private enum enMode
        {
           AddNew = 0, Update = 1
        }
        enMode _Mode;
        public int DoctorID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Specialization { get; set; }
        public DateTime HireDate { get; set; }
        public string ImagePath { get; set; }

        public clsDoctor()
        {
            DoctorID = -1;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Specialization = string.Empty;
            HireDate = DateTime.Now;
            ImagePath = string.Empty;

            _Mode = enMode.AddNew;
        } 

        private clsDoctor(int DoctorID,string FirstName,string LastName,string Email, string Phone, string Specialization, DateTime HireDate, string ImagePath)
        {
            this.DoctorID = DoctorID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Specialization = Specialization;
            this.HireDate = HireDate;
            this.ImagePath = ImagePath;

            this._Mode = enMode.Update;
        }

        private bool _AddNewDoctor()
        {
            clsDoctorData.stDoctor stDoctor = new clsDoctorData.stDoctor();
            stDoctor.FirstName = FirstName;
            stDoctor.LastName = LastName;
            stDoctor.Email = Email;
            stDoctor.Phone = Phone;
            stDoctor.Specialization = Specialization;
            stDoctor.HireDate= HireDate;
            stDoctor.ImagePath = ImagePath;
            this.DoctorID = clsDoctorData.AddNewDoctor(stDoctor);

            return this.DoctorID != -1;

        }
        private bool _Update()
        {
            clsDoctorData.stDoctor stDoctor = new clsDoctorData.stDoctor();
            stDoctor.DoctorID= DoctorID;
            stDoctor.FirstName = FirstName;
            stDoctor.LastName = LastName;
            stDoctor.Email = Email;
            stDoctor.Phone = Phone;
            stDoctor.Specialization = Specialization;
            stDoctor.HireDate = HireDate;
            stDoctor.ImagePath = ImagePath;

            return clsDoctorData.UpdateDoctor(stDoctor); // Return (rowsAffected > 0)?
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDoctor())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else return false;
                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static clsDoctor FindByID(int DoctorID)
        {
            clsDoctorData.stDoctor stDoctor = new clsDoctorData.stDoctor();

            if(clsDoctorData.GetDoctorByID(DoctorID,ref stDoctor))
            {
                return new clsDoctor(DoctorID, stDoctor.FirstName,stDoctor.LastName,stDoctor.Email,stDoctor.Phone,stDoctor.Specialization,stDoctor.HireDate, stDoctor.ImagePath);
            }
            return null;  
        }

        public static DataTable FindByID(string DoctorID)
        {
            return clsDoctorData.GetDoctorByID(DoctorID);
        }
        public static DataTable FindByName(string SearchName)
        {
            return  clsDoctorData.GetDoctorByName(SearchName);

        }

        public static bool IsDoctorExist(int ID)
        {
            return clsDoctorData.IsDoctorExist(ID);
        }
        public static bool Delete(int DoctorID)
        {
            return clsDoctorData.Delete(DoctorID);
        }

        public static DataTable ListAllDoctors()
        {
            return clsDoctorData.GetAllDoctors();

        }
    }
}
