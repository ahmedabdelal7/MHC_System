using MentCareBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantCareConsole
{
    internal class Program
    {

        public static void TestAddNewPatient()
        {
            clsPatient patient = new clsPatient();
            patient.FirstName = "Amany";
            patient.LastName = "Ahmed";
            patient.Gender = "F";
            patient.DateOfBirth = DateTime.Now;
            patient.Phone = "01225877789";
            patient.Address = "12 Rom st";
            patient.EmergencyContact = "0225566555";

            if (patient.Save())
            {
                Console.WriteLine($"Patient Saved with ID = {patient.PatientID}");
            }else
                Console.WriteLine("Patient Not Saved");

        }

        public static void TestFindPatient(int PatientID)
        {
            clsPatient patient = clsPatient.Find(PatientID);
            
            if(patient != null)
            {
                //Console.WriteLine($"{patient.PatientID}, {patient.FirstName}, {patient.LastName}, {patient.Gender}, {patient.DateOfBirth}, {patient.Phone}, {patient.Address}, {patient.EmergencyContact}");
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7} ",
                   patient.PatientID, patient.FirstName, patient.LastName, patient.Gender, patient.DateOfBirth, patient.Phone, patient.Address, patient.EmergencyContact);
            }
            else
            {
                Console.WriteLine("Patient not found");
            }

        }

        public static void TestUpdatePatient(int PatientID)
        {

            string FirstName = "Mona";
            string LastName = "Sameh";
            string Gender = "F";
            string Phone = "054545455";
            string Address = "125 GTR st";
            DateTime DateOfBirth = DateTime.Now;
            string EmergencyContact = "01255545458";

            clsPatient patient = clsPatient.Find(PatientID);           

            if (patient != null)
            {

                patient.PatientID = PatientID;
                patient.FirstName = FirstName;
                patient.LastName = LastName;
                patient.Gender = Gender;
                patient.Phone = Phone;
                patient.Address = Address;
                patient.DateOfBirth = DateOfBirth;
                patient.EmergencyContact = EmergencyContact;

                if (patient.Save())
                    Console.WriteLine("Patient Updated");
                else
                    Console.WriteLine("Faild to Update");
            }
            else Console.WriteLine("Patient is not found!");

        }

        public static void TestDeletePatient(int PatientID)
        {
            if (clsPatient.IsPatientExist(PatientID))
            {
                if (clsPatient.DeletePatient(PatientID))
                {
                    Console.WriteLine("Patient Deleted Succsfully");
                }else
                    Console.WriteLine("Patient Not Deleted");
            }else
                Console.WriteLine("Patient not found!");
        }

        public static void TestListAllPatients()
        {
            DataTable patients = clsPatient.ListAllPatients();

            foreach (DataRow RecordRow in patients.Rows)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7} ",
                   RecordRow["PatientID"], RecordRow["FirstName"], RecordRow["LastName"], RecordRow["Gender"],
                   RecordRow["DateOfBirth"], RecordRow["Phone"], RecordRow["Address"], RecordRow["EmergencyContact"]);
            }
        }
        static void Main(string[] args)
        {
            //TestFindPatient(4);
            //TestAddNewPatient();

            //TestUpdatePatient(4);

            //TestFindPatient(2);

            //TestDeletePatient(2);

            //TestListAllPatients();
            Console.ReadLine();
        }
    }
}
