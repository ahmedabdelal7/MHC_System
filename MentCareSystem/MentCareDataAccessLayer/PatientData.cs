using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentCareDataAccessLayer
{
    public static class clsPatientsData
    {
        public static int AddPatient(string FirstName, string LastName, string Gender, DateTime DateOfBirth,
            string Phone, string Address, string EmergencyContact)
        {

            int PatientID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Patients (FirstName, LastName, Gender, DateOfBirth, Phone, Address, EmergencyContact) 
                            VALUES (@FirstName, @LastName, @Gender, @DateOfBirth, @Phone, @Address, @EmergencyContact);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);

            if (!string.IsNullOrWhiteSpace(LastName))
                command.Parameters.AddWithValue("@LastName", LastName);
            else
                command.Parameters.AddWithValue("@LastName", DBNull.Value);

            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Phone", Phone);

            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            if (!string.IsNullOrWhiteSpace(Address))
                command.Parameters.AddWithValue("@Address", Address);
            else
                command.Parameters.AddWithValue("@Address", DBNull.Value);


            if (!string.IsNullOrWhiteSpace(EmergencyContact))
                command.Parameters.AddWithValue("@EmergencyContact", EmergencyContact);
            else
                command.Parameters.AddWithValue("@EmergencyContact", DBNull.Value);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    PatientID = InsertedID;
                }


            }
            catch (Exception ex) {
                Console.WriteLine("Error "+ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return PatientID;
        }


        public static bool GetPatientByID(int PatientID, ref string FirstName, ref string LastName, ref string Gender, ref DateTime DateOfBirth,
            ref string Phone, ref string Address, ref string EmergencyContact)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Patients WHERE PatientID = @PatientID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PatientID", PatientID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    FirstName = (string)reader["FirstName"];
                    Gender = (string)reader["Gender"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Phone = (string)reader["Phone"];


                    if (reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";

                    if (reader["LastName"] != DBNull.Value)
                        LastName = (string)reader["LastName"];
                    else
                        LastName = "";

                    if (reader["EmergencyContact"] != DBNull.Value)
                        EmergencyContact = (string)reader["EmergencyContact"];
                    else
                        EmergencyContact = "";
                    reader.Close();
                }


            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        public static DataTable GetPatientByID(string PatientID)
        {
            DataTable PatientsDT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT PatientID, FirstName+' '+ ISNULL(LastName,'') AS FullName, Phone, Gender
                            FROM Patients
							WHERE CAST(PatientID AS NVARCHAR(20))
                                LIKE '%' + @PatientID + '%';";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                PatientsDT.Load(reader);
                reader.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally { connection.Close(); }
            return PatientsDT;
        }
        public static DataTable GetPatientByName(string PatientName)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PatientID, FirstName+' '+ ISNULL(LastName,'') AS FullName, Phone, Gender
                            FROM Patients
							WHERE FirstName+ ' ' + ISNULL(LastName,'')
                                LIKE '%' + @PatientName + '%'";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PatientName", "%" + PatientName + "%");


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { connection.Close(); }
            return table;
        }

        public static DataTable GetPatientByPhoneNumber(string Phone)
        {
            
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PatientID, FirstName+' '+ISNULL(LastName,'') AS FullName, Phone, Gender
                            FROM Patients WHERE Phone LIKE '%'+ @Phone +'%'";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Phone", Phone);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                dataTable.Load(reader);
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { connection.Close(); }
            return dataTable;
        }

        public static bool IsPatientExist(int PatientID)
        {
            bool isFound = false;   

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Patients WHERE PatientID = @PatientID;";
            
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    isFound = true;
                }
                reader.Close();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                connection.Close();
            }
            return isFound;    
        }

        public static bool UpdatePatient(int PatientID, string FirstName, string LastName, string Gender, DateTime DateOfBirth,
            string Phone, string Address, string EmergencyContact)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Patients SET FirstName = @FirstName, LastName = @LastName, Gender = @Gender, DateOfBirth = @DateOfBirth, 
                            Phone = @Phone, Address = @Address, EmergencyContact = @EmergencyContact
                            WHERE PatientID = @PatientID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PatientID", PatientID);

            command.Parameters.AddWithValue("@FirstName", FirstName);

            command.Parameters.AddWithValue("@Gender", Gender);

            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            command.Parameters.AddWithValue("@Phone", Phone);

            //Validation on AllowNull Properties
            if (!string.IsNullOrWhiteSpace(LastName))
                command.Parameters.AddWithValue("@LastName", LastName);
            else
                command.Parameters.AddWithValue("@LastName", DBNull.Value);

            if (!string.IsNullOrWhiteSpace(Address))
                command.Parameters.AddWithValue("@Address", Address);
            else
                command.Parameters.AddWithValue("@Address", DBNull.Value);

            if (!string.IsNullOrWhiteSpace(EmergencyContact))
                command.Parameters.AddWithValue("@EmergencyContact", EmergencyContact);
            else
                command.Parameters.AddWithValue("@EmergencyContact", DBNull.Value);


            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;

        }

        public static bool DeletePatient(int PatientID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Patients WHERE PatientID = @PatientID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        public static DataTable GetAllPatient()
        {
            DataTable patientsDT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PatientID, FirstName+' '+ISNULL(LastName,'') AS FullName, Phone, Gender
                            FROM Patients ORDER BY PatientID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                patientsDT.Load(reader);
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return patientsDT;
        }

    }


}
