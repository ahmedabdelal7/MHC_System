using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentCareDataAccessLayer
{
    public static class clsDoctorData
    {
        public struct stDoctor
        {
            public int DoctorID;
            public string FirstName;
            public string LastName;
            public string Email;
            public string Phone;
            public string Specialization;
            public DateTime HireDate;                       
                
        }

        public static int AddNewDoctor(stDoctor doctorInfo)
        {
            int doctorID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Doctors (FirstName,LastName,Specialization,Email,Phone,HireDate) 
                            VALUES (@FirstName, @LastName,@Specialization,@Email,@Phone,@HireDate);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", doctorInfo.FirstName);

            if(!string.IsNullOrWhiteSpace( doctorInfo.LastName))
                command.Parameters.AddWithValue("@LastName", doctorInfo.LastName);
            else command.Parameters.AddWithValue("@LastName", DBNull.Value);

            command.Parameters.AddWithValue("@Specialization", doctorInfo.Specialization);

            if (!string.IsNullOrWhiteSpace(doctorInfo.Email))
                command.Parameters.AddWithValue("@Email", doctorInfo.Email);
            else command.Parameters.AddWithValue("@Email", DBNull.Value);

            command.Parameters.AddWithValue("@Phone", doctorInfo.Phone);

            if (doctorInfo.HireDate != null)
                command.Parameters.AddWithValue("@HireDate", doctorInfo.HireDate);
            else command.Parameters.AddWithValue("@HireDate", DBNull.Value);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result != DBNull.Value && int.TryParse(result.ToString(),out int insertedID))
                {
                    doctorID = insertedID;
                }

            }catch (Exception ex) { Console.WriteLine(ex); }
            finally { connection.Close(); }
            return doctorID;

        }

        public static bool UpdateDoctor(stDoctor doctorInfo)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Doctors SET FirstName = @FirstName, LastName = @LastName, Specialization = @Specialization,
                            Email = @Email, Phone = @Phone, HireDate = @HireDate WHERE DoctorID = @DoctorID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DoctorID", doctorInfo.DoctorID);

            command.Parameters.AddWithValue("@FirstName", doctorInfo.FirstName);

            if (!string.IsNullOrWhiteSpace(doctorInfo.LastName))
                command.Parameters.AddWithValue("@LastName", doctorInfo.LastName);
            else command.Parameters.AddWithValue("@LastName", DBNull.Value);

            command.Parameters.AddWithValue("@Specialization", doctorInfo.Specialization);

            if (!string.IsNullOrWhiteSpace(doctorInfo.Email))
                command.Parameters.AddWithValue("@Email", doctorInfo.Email);
            else command.Parameters.AddWithValue("@Email", DBNull.Value);

            command.Parameters.AddWithValue("@Phone", doctorInfo.Phone);

            if (doctorInfo.HireDate != null)
                command.Parameters.AddWithValue("@HireDate", doctorInfo.HireDate);
            else command.Parameters.AddWithValue("@HireDate", DBNull.Value);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { connection.Close(); }
            return rowsAffected > 1;
        }

        public static bool FindDoctorByID(int DoctorID, ref stDoctor doctorInfo)
        {
            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Doctors WHERE DoctorID = @DoctorID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DoctorID", DoctorID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    doctorInfo.FirstName = reader["FirstName"].ToString();

                    if (reader["LastName"] != DBNull.Value)
                        doctorInfo.LastName = reader["LastName"].ToString();
                    else doctorInfo.LastName = "";

                    if (reader["Email"] != DBNull.Value)
                        doctorInfo.Email = reader["Email"].ToString();
                    else doctorInfo.Email = "";


                    doctorInfo.Phone = reader["Phone"].ToString();

                    doctorInfo.Specialization  = reader["Specialization"].ToString();

                    if (reader["HireDate"] != DBNull.Value)
                        doctorInfo.HireDate = (DateTime)reader["HireDate"];
                    else doctorInfo.HireDate = new DateTime(0000, 00, 00, 00, 00, 00);


                }
                reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { connection.Close(); }
            return isFound;

        }

        public static DataTable FindDoctorByName(string FirstName)
        {

            DataTable doctorsDT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Doctors WHERE FirstName LIKE @FirtsName;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirtsName", "%" + FirstName + "%");

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    doctorsDT.Load(reader);
                }

                reader.Close();
            }catch (Exception ex) { Console.WriteLine(ex); }
            finally { connection.Close(); }
            return doctorsDT;
        }

        public static bool IsDoctorExist(int DoctorID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Doctors where DoctorID = @DoctorID;";

            SqlCommand command = new SqlCommand(query,connection);

            command.Parameters.AddWithValue("@DoctorID", DoctorID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    isFound = true;
                   
                }
                reader.Close();
            }catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return isFound;
        }
        public static bool Delete(int DoctorID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM Doctors WHERE DoctorID = @DoctorID;";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@DoctorID", DoctorID);

            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery(); 
            }catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return rowsAffected > 0;
        }
        
        public static DataTable GetAllDoctors()
        {
            DataTable doctorsDT = new DataTable(); 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Doctors";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows) {
                    doctorsDT.Load(reader);
                }
                reader.Close();
            }catch(Exception ex) { Console.WriteLine(ex.Message);}
            finally { connection.Close(); }
            return doctorsDT;

        }

    }
}
