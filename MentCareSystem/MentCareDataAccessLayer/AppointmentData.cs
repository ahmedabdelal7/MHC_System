using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Data;
using static MentCareDataAccessLayer.clsConsultationData;
using System.IO.Pipes;
using static MentCareDataAccessLayer.clsAppointmentData;


namespace MentCareDataAccessLayer
{
    public static class clsAppointmentData
    {

        public struct stAppointment
        {
            public int AppointmentID;
            public int PatientID;
            public int DoctorID;
            public DateTime AppointmentDateTime;
            public byte Status;
            public string Reason;
            public string Notes;
            public DateTime CreatedDate;

        }


        //(Reason - Notes) are Nllable attributes need to validate it first before save in database or export to BLL.

        public static int AddNewAppointment(stAppointment appointment)
        {

            int appointmentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Appointments (DoctorID,PatientID,AppointmentDateTime,Status,Reason,Notes) 
                            VALUES(@DoctorID,@PatientID,@AppointmentDateTime,@Status,@Reason,@Notes);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command   = new SqlCommand(query, connection);

            command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = appointment.DoctorID;
            command.Parameters.Add("@PatientID", SqlDbType.Int).Value = appointment.PatientID;
            command.Parameters.Add("@AppointmentDateTime", SqlDbType.DateTime).Value = appointment.AppointmentDateTime;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = appointment.Status;


            command.Parameters.Add("@Reason", SqlDbType.NVarChar, 200).Value =
                !string.IsNullOrWhiteSpace(appointment.Reason) ? appointment.Reason : (object)DBNull.Value;

            command.Parameters.Add("@Notes", SqlDbType.NVarChar, -1).Value =
                !string.IsNullOrWhiteSpace(appointment.Notes) ? appointment.Notes : (object)DBNull.Value;


            //command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = appointment.CreatedDate;

            try
            {
                connection.Open();

                object result  = command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(),out int insertedID))
                    appointmentID = insertedID;
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return appointmentID;

        }
        public static bool FindAppointmentByID(int appointmentID, ref stAppointment appointment)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Appointments
                            WHERE AppointmentID = @AppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointmentID;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if(reader.Read())
                {
                    isFound = true;

                    appointment.AppointmentID = (int)reader["AppointmentID"];
                    appointment.DoctorID = (int)reader["DoctorID"];
                    appointment.PatientID = (int)reader["PatientID"];
                    appointment.AppointmentDateTime = (DateTime)reader["AppointmentDateTime"];
                    appointment.Status = (byte)reader["Status"];

                    //nullable validation:
                    appointment.Reason = (reader["Reason"] != DBNull.Value ? reader["Reason"].ToString() : "");
                    appointment.Notes = (reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : "");

                    appointment.CreatedDate = (DateTime)reader["CreatedDate"];
                }
                reader.Close();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;
        }
        public static bool UpdateAppointment(stAppointment appointment)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Appointments SET 
					                DoctorID = @DoctorID,
					                PatientID = @PatientID,
					                AppointmentDateTime = @AppointmentDateTime,
					                Status = @Status,
					                Reason = @Reason,
					                Notes = @Notes
                            WHERE AppointmentID = @AppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointment.AppointmentID;
            command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = appointment.DoctorID;
            command.Parameters.Add("@PatientID", SqlDbType.Int).Value = appointment.PatientID;
            command.Parameters.Add("@AppointmentDateTime", SqlDbType.DateTime).Value = appointment.AppointmentDateTime;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = appointment.Status;


            command.Parameters.Add("@Reason", SqlDbType.NVarChar, 200).Value =
                !string.IsNullOrWhiteSpace(appointment.Reason) ? appointment.Reason : (object)DBNull.Value;

            command.Parameters.Add("@Notes", SqlDbType.NVarChar, -1).Value =
                !string.IsNullOrWhiteSpace(appointment.Notes) ? appointment.Notes : (object)DBNull.Value;


           //command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = appointment.CreatedDate;

            try
            {
                connection.Open();

                rowsAffected =  command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return rowsAffected > 0;
        }
        public static bool DeleteAppointment(int appointmentID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM Appointments
                            WHERE AppointmentID = @AppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointmentID;
            

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return rowsAffected > 0;

        }
        public static bool IsExist(int appointmentID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found = 1 FROM Appointments
                            WHERE AppointmentID = @AppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointmentID;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                isFound = (result != null);
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;
        }
        public static DataTable GetAllAppointments()
        {
            DataTable appointmentsDT = new DataTable(); 

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Appointments.AppointmentID,
	                            Patients.FirstName+' '+ ISNULL(Patients.LastName,'') AS PatientName,
	                            Doctors.FirstName+' '+ ISNULL(Doctors.LastName,'') AS DoctorName,
	                            Appointments.AppointmentDateTime,
	                            CASE Appointments.Status
									WHEN 1 THEN 'Scheduled'
									WHEN 2 THEN 'Completed'
									WHEN 3 THEN 'Cancelled'
									WHEN 4 THEN 'No Show'
								END AS Status
                            FROM Appointments INNER JOIN
	                            Doctors ON Appointments.DoctorID = Doctors.DoctorID INNER JOIN
	                            Patients ON Appointments.PatientID = Patients.PatientID;";

            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                appointmentsDT.Load(reader);               

                reader.Close();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return appointmentsDT;  
        }
        public static DataTable FindAppointmentByPatientName(string patientName)
        {
            DataTable appointmentsDT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Appointments.AppointmentID,
	                            Patients.FirstName+' '+ ISNULL(Patients.LastName,'') AS PatientName,
	                            Doctors.FirstName+' '+ ISNULL(Doctors.LastName,'') AS DoctorName,
	                            Appointments.AppointmentDateTime,
	                            CASE Appointments.Status
									WHEN 1 THEN 'Scheduled'
									WHEN 2 THEN 'Completed'
									WHEN 3 THEN 'Cancelled'
									WHEN 4 THEN 'No Show'
								END AS status
                            FROM Appointments INNER JOIN
	                            Doctors ON Appointments.DoctorID = Doctors.DoctorID INNER JOIN
	                            Patients ON Appointments.PatientID = Patients.PatientID
                            WHERE Patients.FirstName+' '+ ISNULL(Patients.LastName,'') LIKE
	                            '%'+ @PatientName +'%';";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PatientName", patientName);
            //command.Parameters.Add("@PatientName",SqlDbType.NVarChar,200).Value = patientName;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                appointmentsDT.Load(reader);


                reader.Close();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return appointmentsDT;
        }
        public static DataTable FindAppointmentByDoctorName(string doctorName)
        {
            DataTable appointmentsDT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Appointments.AppointmentID,
	                            Patients.FirstName+' '+ ISNULL(Patients.LastName,'') AS PatientName,
	                            Doctors.FirstName+' '+ ISNULL(Doctors.LastName,'') AS DoctorName,
	                            Appointments.AppointmentDateTime,
	                            CASE Appointments.Status
									WHEN 1 THEN 'Scheduled'
									WHEN 2 THEN 'Completed'
									WHEN 3 THEN 'Cancelled'
									WHEN 4 THEN 'No Show'
								END AS Status
                            FROM Appointments INNER JOIN
	                            Doctors ON Appointments.DoctorID = Doctors.DoctorID INNER JOIN
	                            Patients ON Appointments.PatientID = Patients.PatientID
                            WHERE Doctors.FirstName+' '+ ISNULL(Doctors.LastName,'') LIKE
	                            '%'+ @DoctorName +'%';";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@DoctorName", SqlDbType.NVarChar,200).Value = doctorName;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                appointmentsDT.Load(reader);

                reader.Close();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return appointmentsDT;
        }
        public static bool IsDoctorAvilable(int DoctorID, DateTime AppointmentDateTime)
        {
            bool isAvilable = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //return 1 if the doctor not avilable.
            string query = @"SELECT Found = 1
                            FROM Appointments
                            WHERE DoctorID = @DoctorID
                            AND AppointmentDateTime = @AppointmentDateTime";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = DoctorID;
            command.Parameters.Add("@AppointmentDateTime", SqlDbType.DateTime).Value = AppointmentDateTime;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                //If not founded rows -> set avilable = true 

                isAvilable = (result == null);
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isAvilable;
        }

        public static DataTable FindAppointmentByID(string appointmentID)
        {
            DataTable appointmentsDT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Appointments.AppointmentID,
	                            Patients.FirstName+' '+ ISNULL(Patients.LastName,'') AS PatientName,
	                            Doctors.FirstName+' '+ ISNULL(Doctors.LastName,'') AS DoctorName,
	                            Appointments.AppointmentDateTime,
	                            CASE Appointments.Status
									WHEN 1 THEN 'Scheduled'
									WHEN 2 THEN 'Completed'
									WHEN 3 THEN 'Cancelled'
									WHEN 4 THEN 'No Show'
								END AS Status
                            FROM Appointments INNER JOIN
	                            Doctors ON Appointments.DoctorID = Doctors.DoctorID INNER JOIN
	                            Patients ON Appointments.PatientID = Patients.PatientID
                            WHERE CAST(AppointmentID AS NVARCHAR) LIKE
	                            '%'+ @AppointmentID +'%';";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@AppointmentID", SqlDbType.NVarChar, 200).Value = appointmentID;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                appointmentsDT.Load(reader);

                reader.Close();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return appointmentsDT;
        }

        public static DataTable GetAppointmentsStatisticsForPatient(int PatientID)
        {
            DataTable appStatisticsDT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT
                                COUNT(*) AS TotalAppointments,

                                ISNULL(SUM(CASE WHEN Status = 2 THEN 1 ELSE 0 END),0) AS Completed,

                                ISNULL(SUM(CASE WHEN Status = 3 THEN 1 ELSE 0 END),0) AS Cancelled,

                                ISNULL(SUM(CASE WHEN Status = 4 THEN 1 ELSE 0 END),0) AS NoShow

                            FROM Appointments
                            WHERE PatientID = @PatientID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@PatientID", SqlDbType.Int).Value = PatientID;


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                //if (reader.HasRows)
                    appStatisticsDT.Load(reader);

                reader.Close();

            }
            catch  { throw; }
            finally { connection.Close(); }

            return appStatisticsDT;
        }

    }
}
