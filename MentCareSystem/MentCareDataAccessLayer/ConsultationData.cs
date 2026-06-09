using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MentCareDataAccessLayer.clsConsultationData;
using static MentCareDataAccessLayer.clsDoctorData;

namespace MentCareDataAccessLayer
{
    public static class clsConsultationData
    {
        public struct stConsultation
        {
            public int ConsultationID;
            public int PatientID;
            public int DoctorID;
            public DateTime ConsultationDate;
            public string Diagnosis;
            public string Notes;
            public string TreatmentPlan;
        }
        public static int AddConsultation(stConsultation consultation)
        {
            int consultationID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Consultations (PatientID,DoctorID,ConsultationDate,Diagnosis,Notes,TreatmentPlan) 
		                    Values (@PatientID,@DoctorID,@ConsultationDate,@Diagnosis,@Notes,@TreatmentPlan);
		                    Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", consultation.PatientID);
            command.Parameters.AddWithValue("@DoctorID", consultation.DoctorID);
            command.Parameters.AddWithValue("@ConsultationDate", consultation.ConsultationDate);

            if (!string.IsNullOrWhiteSpace(consultation.Diagnosis))
                command.Parameters.AddWithValue("@Diagnosis", consultation.Diagnosis);
            else
                command.Parameters.AddWithValue("@Diagnosis", DBNull.Value);

            if (!string.IsNullOrWhiteSpace(consultation.Notes))
                command.Parameters.AddWithValue("@Notes", consultation.Notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            if (!string.IsNullOrWhiteSpace(consultation.TreatmentPlan))
                command.Parameters.AddWithValue("@TreatmentPlan", consultation.TreatmentPlan);
            else
                command.Parameters.AddWithValue("@TreatmentPlan", DBNull.Value);


            try
            {
                connection.Open();

                object value = command.ExecuteScalar();

                if (value != null && int.TryParse(value.ToString(), out int selectedID))
                {
                    consultationID = selectedID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return consultationID;
        }
        public static bool FindConsultationByID(int ConsultationID, ref stConsultation consultation)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Consultations WHERE ConsultationID = @ConsultationID;";

            SqlCommand command = new SqlCommand(query, connection);

            // command.Parameters.AddWithValue("@ConsultationID", ConsultationID);
            command.Parameters.Add("@ConsultationID",SqlDbType.Int).Value = ConsultationID;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    consultation.ConsultationID = ConsultationID;
                    consultation.PatientID = (int)reader["PatientID"];
                    consultation.DoctorID = (int)reader["DoctorID"];
                    consultation.ConsultationDate = (DateTime)reader["ConsultationDate"];

                    consultation.Diagnosis = (reader["Diagnosis"] != DBNull.Value ? reader["Diagnosis"].ToString() : "");
                    consultation.TreatmentPlan = (reader["TreatmentPlan"] != DBNull.Value ? reader["TreatmentPlan"].ToString() : "");
                    consultation.Notes = (reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : "");

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { connection.Close(); }
            return isFound;
        }
        public static bool IsConsultationExist(int ConsultationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found = 1 FROM Consultations WHERE ConsultationID = @ConsultationID;";

            SqlCommand command = new SqlCommand(query, connection);

            // command.Parameters.AddWithValue("@ConsultationID", ConsultationID);
            command.Parameters.Add("@ConsultationID", SqlDbType.Int).Value = ConsultationID;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                isFound = (result != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { connection.Close(); }
            return isFound;
        }
        public static bool UpdateConsultation(stConsultation consultation)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Consultations SET
	                            PatientID = @PatientID,
	                            DoctorID = @DoctorID,
	                            ConsultationDate = @ConsultationDate,
	                            Diagnosis = @Diagnosis,
	                            Notes = @Notes,
	                            TreatmentPlan = @TreatmentPlan
                            WHERE ConsultationID = @ConsultationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@ConsultationID", SqlDbType.Int).Value = consultation.ConsultationID;

            command.Parameters.Add("@PatientID", SqlDbType.Int).Value = consultation.PatientID;
            command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = consultation.DoctorID;
            command.Parameters.Add("@ConsultationDate", SqlDbType.DateTime).Value = consultation.ConsultationDate;

            if (!string.IsNullOrWhiteSpace(consultation.Diagnosis))
                command.Parameters.Add("@Diagnosis", SqlDbType.NVarChar,200).Value = consultation.Diagnosis;
            else command.Parameters.Add("@Diagnosis", SqlDbType.NVarChar,200).Value = DBNull.Value;

            if (!string.IsNullOrWhiteSpace(consultation.Notes))
                command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = consultation.Notes;
            else command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = DBNull.Value;

            if (!string.IsNullOrWhiteSpace(consultation.TreatmentPlan))
                command.Parameters.Add("@TreatmentPlan", SqlDbType.NVarChar,300).Value = consultation.TreatmentPlan;
            else command.Parameters.Add("@TreatmentPlan", SqlDbType.NVarChar,300).Value = DBNull.Value;

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { connection.Close(); }

            return rowsAffected > 0;
        }
        public static bool DeleteConslutation(int ConsultationID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM Consultations
	                        WHERE ConsultationID = @ConsultationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@ConsultationID", SqlDbType.Int).Value = ConsultationID;

            try
            {

                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { connection.Close(); }
            return rowsAffected > 0;
        }
        public static DataTable GetAllConsultations()
        {
            DataTable ConsultstionsDT = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT
                                c.ConsultationID,
                                p.FirstName + ' ' + ISNULL(p.LastName,'') AS PatientName,
                                d.FirstName + ' ' + ISNULL(d.LastName,'') AS DoctorName,
                                c.ConsultationDate
                            FROM Consultations c
                            INNER JOIN Doctors d
                                ON c.DoctorID = d.DoctorID
                            INNER JOIN Patients p
                                ON c.PatientID = p.PatientID;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    ConsultstionsDT.Load(reader);
                }
                reader.Close();

            }catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }
            return ConsultstionsDT;

        }
        //Search Methodes.

        //Patient Name
        //Doctor Name
        //Consultation ID

        public static DataTable FindConsultationByID(string ConsultationID)
        {
            DataTable ConsultstionsDT = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT
                                c.ConsultationID,
                                p.FirstName + ' ' + ISNULL(p.LastName,'') AS PatientName,
                                d.FirstName + ' ' + ISNULL(d.LastName,'') AS DoctorName,
                                c.ConsultationDate
                            FROM Consultations c
                            INNER JOIN Doctors d
                                ON c.DoctorID = d.DoctorID
                            INNER JOIN Patients p
                                ON c.PatientID = p.PatientID
                            WHERE CAST(ConsultationID AS NVARCHAR(20))
                                LIKE '%' + @ConsultationID + '%';";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@ConsultationID", SqlDbType.NVarChar,20).Value = ConsultationID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ConsultstionsDT.Load(reader);

                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { connection.Close(); }
            return ConsultstionsDT;
        }
        public static DataTable FindByPatientName(string PatientName)
        {
            DataTable ConsultstionsDT = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT
                                c.ConsultationID,
                                p.FirstName + ' ' + ISNULL(p.LastName,'') AS PatientName,
                                d.FirstName + ' ' + ISNULL(d.LastName,'') AS DoctorName,
                                c.ConsultationDate
                            FROM Consultations c
                            INNER JOIN Doctors d
                                ON c.DoctorID = d.DoctorID
                            INNER JOIN Patients p
                                ON c.PatientID = p.PatientID
                            WHERE p.FirstName+ ' ' + ISNULL(p.LastName,'')
                                LIKE '%' + @PatientName + '%'";

            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.Add("@PatientName",SqlDbType.NVarChar,100).Value = PatientName;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ConsultstionsDT.Load(reader);

                reader.Close();
            }catch(Exception ex) { Console.WriteLine(ex); }
            finally { connection.Close(); }
            return ConsultstionsDT;

        }
        public static DataTable FindByDoctorName(string DoctorName)
        {
            DataTable ConsultstionsDT = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT
                                c.ConsultationID,
                                p.FirstName + ' ' + ISNULL(p.LastName,'') AS PatientName,
                                d.FirstName + ' ' + ISNULL(d.LastName,'') AS DoctorName,
                                c.ConsultationDate
                            FROM Consultations c
                            INNER JOIN Doctors d
                                ON c.DoctorID = d.DoctorID
                            INNER JOIN Patients p
                                ON c.PatientID = p.PatientID
                            WHERE d.FirstName + ' ' + ISNULL(d.LastName,'')
                                LIKE '%' + @DoctorName + '%';";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@DoctorName", SqlDbType.NVarChar, 100).Value = DoctorName;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ConsultstionsDT.Load(reader);

                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { connection.Close(); }
            return ConsultstionsDT;

        }

    }
}
