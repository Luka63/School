using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AAIT_Common {
    public class DBAccess {
        string Str = null;
        public DBAccess() {

        }
        public DBAccess(string Str) {
             Str = Str;
        }

        internal DataTable GetTeacher(int? classID = null) {
            DataTable dt = null;

            using (SqlConnection cn = new SqlConnection()) {
                cn.ConnectionString = Str;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("P_GetTeacher")) {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
                    cmd.ExecuteNonQuery();
                    dt = LoadTable(cmd);
                }
                cn.Close();
            }
            return dt;
        }

        #region 
        //public DataTable GetKittyInfo(int kittyId)
        //{
        //    DataTable dt = null;
        //    using (SqlConnection cn = new SqlConnection())
        //    {
        //        cn.ConnectionString = GetConnectionStr();
        //        cn.Open();

        //        using (SqlCommand cmd = new SqlCommand("P_GetKittyInfo"))
        //        {
        //            cmd.Connection = cn;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@KittyId", SqlDbType.Int).Value = kittyId;
        //            dt = LoadTable(cmd);
        //        }
        //        cn.Close();
        //    }

        //    return dt;
        //}

        //public DataTable GetKitty(int? catId = null, int? kittyId = null)
        //{
        //    DataTable dt = null;
        //    using (SqlConnection cn = new SqlConnection())
        //    {
        //        cn.ConnectionString = GetConnectionStr();
        //        cn.Open();

        //        using (SqlCommand cmd = new SqlCommand("P_GetKitty"))
        //        {
        //            cmd.Connection = cn;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@CatId", SqlDbType.Int).Value = catId;
        //            cmd.Parameters.Add("@KittyId", SqlDbType.Int).Value = kittyId;
        //            dt = LoadTable(cmd);
        //        }
        //        cn.Close();
        //    }

        //    return dt;
        //}

        //public DataTable GetCat(int? catId = null)
        //{
        //    DataTable dt = null;
        //    using (SqlConnection cn = new SqlConnection())
        //    {
        //        cn.ConnectionString = GetConnectionStr();
        //        cn.Open();

        //        using (SqlCommand cmd = new SqlCommand("P_GetCat"))
        //        {
        //            cmd.Connection = cn;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@CatId", SqlDbType.Int).Value = catId;
        //            dt = LoadTable(cmd);
        //        }
        //        cn.Close();
        //    }

        //    return dt;
        //}
        //public int SetCat(string name, string dob, int genderId, int sizeId, string address,
        //    string city, string stateId, string zipcode)
        //{
        //    int Id = 0;
        //    SqlConnection cn = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    try
        //    {
        //        cn.ConnectionString = GetConnectionStr();
        //        cn.Open();

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "P_SetCat";
        //        cmd.Connection = cn;
        //        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
        //        cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = dob;
        //        cmd.Parameters.Add("@GenderId", SqlDbType.Int).Value = genderId;
        //        cmd.Parameters.Add("@SizeId", SqlDbType.Int).Value = sizeId;
        //        cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
        //        cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = city;
        //        cmd.Parameters.Add("@StateId", SqlDbType.VarChar).Value = stateId;
        //        cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = zipcode;
        //        cmd.Parameters.Add("@CatId", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        cmd.ExecuteNonQuery();

        //        Id = (int)cmd.Parameters["@CatId"].Value;
        //        cn.Close();
        //    }

        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //    return Id;
        //}

        //public DataSet GetLookup()
        //{
        //    DataSet ds = null;

        //    // Create an object of SqlConnection in order to use members of the class  
        //    using (SqlConnection cn = new SqlConnection())
        //    {
        //        //using object we can use SQLConnection class members  
        //        cn.ConnectionString = GetConnectionStr();
        //        cn.Open();

        //        using (SqlCommand cmd = new SqlCommand("P_GetLookup"))
        //        {
        //            cmd.Connection = cn;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            ds = LoadDataSet(cmd);
        //        }
        //        cn.Close();
        //    }
        //    return ds;
        //}

        //public int SetGender(string action, string gender = "", int GID = 0)
        //{
        //    int Id = 0;
        //    SqlConnection cn = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    try
        //    {
        //        cn.ConnectionString = GetConnectionStr();
        //        cn.Open();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "P_SetGender";
        //        cmd.Connection = cn;
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = action;
        //        cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = gender;
        //        cmd.Parameters.Add("@GId", SqlDbType.Int).Value = GID;
        //        cmd.Parameters.Add("@GenderID", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        cmd.ExecuteNonQuery();

        //        //  Id = (int)cmd.Parameters[1].Value;
        //        Id = (int)cmd.Parameters["@GenderID"].Value;
        //        cn.Close();
        //    }

        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //    return Id;
        //}

        //public DataTable GetGender()
        //{
        //    DataTable dt = null;

        //    // Create an object of SqlConnection in order to use members of the class  
        //    using (SqlConnection cn = new SqlConnection())
        //    {
        //        //using object we can use SQLConnection class members  
        //        cn.ConnectionString = GetConnectionStr();
        //        cn.Open();

        //        using (SqlCommand cmd = new SqlCommand("P_GetGender"))
        //        {
        //            cmd.Connection = cn;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            dt = LoadTable(cmd);
        //        }
        //        cn.Close();
        //    }

        //    return dt;
        //}


        //public void SetState(string stateId, string state)
        //{
        //    using (SqlConnection cn = new SqlConnection())
        //    {
        //        cn.ConnectionString = GetConnectionStr();
        //        cn.Open();

        //        using (SqlCommand cmd = new SqlCommand("P_SetState"))
        //        {
        //            cmd.Connection = cn;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@StateID", DbType.String)).Value = stateId;
        //            cmd.Parameters.Add(new SqlParameter("@State", SqlDbType.VarChar)).Value = state;
        //            cmd.ExecuteNonQuery();
        //        }
        //        cn.Close();
        //    }
        //}

        #endregion

        public DataTable GetStudent(int? studentID = null) {
            DataTable dt = null;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try {
                cn.ConnectionString = Str;
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "P_GetStudent";
                cmd.Connection = cn;
                cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = studentID;
                dt = LoadTable(cmd);
                cn.Close();
            } catch (Exception ex) {
                return null;
            }
            return dt;
        }


        public int SetStudent(string action, string firstname, string lastname, int genderID, int RaceID, int classID, int teacherID, string diploma, string diplomatype, string address, string city, string stateID, string zip, int? Id = null) {
            int studentId = 0;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try {
                cn.ConnectionString = Str;
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "P_SetStudent";
                cmd.Connection = cn;
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = action;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = firstname;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lastname;
                cmd.Parameters.Add("@GenderID", SqlDbType.Int).Value = genderID;
                cmd.Parameters.Add("@RaceID", SqlDbType.Int).Value = RaceID;
                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
                cmd.Parameters.Add("@TeacherID", SqlDbType.Int).Value = teacherID;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = city;
                cmd.Parameters.Add("@StateID", SqlDbType.VarChar).Value = stateID;
                cmd.Parameters.Add("@Zip", SqlDbType.VarChar).Value = zip;
                cmd.Parameters.Add("@Diploma", SqlDbType.VarChar).Value = diploma;
                cmd.Parameters.Add("@DiplomaType", SqlDbType.VarChar).Value = diplomatype;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@StudentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                //  Id = (int)cmd.Parameters[1].Value;
                studentId = (int)cmd.Parameters["@StudentID"].Value;
                cn.Close();
            } catch (Exception ex) {
                return 0;
            }
            return studentId;
        }

        public int DeleteStudent(int Id) {
            int studentId;
            try {
                using (SqlConnection cn = new SqlConnection()) {
                    cn.ConnectionString = Str;
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("P_SetStudent")) {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "Delete";
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                        cmd.Parameters.Add("@StudentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        studentId = (int)cmd.Parameters["@StudentID"].Value;
                    }
                    cn.Close();
                }
                return studentId;
            } catch (Exception) {
                return 0;
            }
        }

        public int AdminLogin(string user, string pass) {
            int AdminID = 0;
            using (SqlConnection cn = new SqlConnection()) {
                cn.ConnectionString = Str;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("P_AuthenticateUser")) {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = user;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = pass;
                    cmd.Parameters.Add("@AdminID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    try {
                        AdminID = (int)cmd.Parameters["@AdminID"].Value;
                    } catch (Exception ex) {
                        AdminID = 0;
                    }
                }
                cn.Close();
            }
            return AdminID;
        }

        public DataTable GetState() {
            DataTable dt = null;
            // Create an object of SqlConnection in order to use members of the class  
            using (SqlConnection cn = new SqlConnection()) {
                //using object we can use SQLConnection class members  
                cn.ConnectionString = Str;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("P_GetState")) {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    dt = LoadTable(cmd);
                }
                cn.Close();
            }
            return dt;
        }

        private DataTable LoadTable(SqlCommand cmd) {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataSet GetLookup() {
            DataSet ds = null;

            // Create an object of SqlConnection in order to use members of the class  
            using (SqlConnection cn = new SqlConnection()) {
                //using object we can use SQLConnection class members  
                cn.ConnectionString = Str;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("P_GetLookup")) {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    ds = LoadDataSet(cmd);
                }
                cn.Close();
            }
            return ds;
        }

        private DataSet LoadDataSet(SqlCommand cmd) {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        //private string GetConnectionStr() {
        //    //Go to web.config gets connection string  
        //    string strCon = ConfigurationManager.ConnectionStrings["SQL_Connection"].ConnectionString;
        //    return strCon;
        //}



    }
}