using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JustForYouPromotions.Models
{
    public class HelperDB
    {   
        /// <summary>
        /// this is da SqlConnection... and stuff... 
        /// </summary>
        /// <returns>SqlConnection</returns>
        public static SqlConnection getMeConnected()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["jfy_home"].ConnectionString);
        }

        internal static bool DeleteMe(int userID)
        {
            SqlConnection con = getMeConnected();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"DELETE FROM [dbo].[Users]
      WHERE [UserID] = @id";

            cmd.Parameters.AddWithValue("@id", userID);

            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        ///  this methoud will add a new SiteMember object to the Just For You Database... MAKE SURE THE SiteMember OBJECT IS VALID BEFORE PASSING IT TO THIS METHOUD!!!!!!!!!!!!!!!!
        ///  
        /// beekerMeMe confirmed this methoud works :)
        /// 
        /// </summary>
        /// <param name="sm">takes in a SiteMember object</param>
        /// <returns>bool true=Added Successfully, false=There was an issue...</returns>
        public static bool AddNewUser(SiteMember sm)
        {
            SqlConnection con = getMeConnected();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"INSERT INTO [dbo].[Users]([UserFName],[UserLName],[UserEmail],[UserPassword],[UserEmailUpdates],[UserAccess],[UserAccessName])
VALUES(@firstname,@lastname,@email,@password,@useremailupdates,@useraccess,@uaccessname)";

            cmd.Parameters.AddWithValue("@firstname", sm.UserFName);
            cmd.Parameters.AddWithValue("@lastname", sm.UserLName);
            cmd.Parameters.AddWithValue("@email", sm.UserEmail);
            cmd.Parameters.AddWithValue("@password", sm.UserPassword);
            cmd.Parameters.AddWithValue("@useremailupdates", sm.UserEmailUpdates);
            cmd.Parameters.AddWithValue("@useraccess", sm.UserAccess);
            cmd.Parameters.AddWithValue("@uaccessname", sm.UserAccessName);

            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    return true;
            }
            finally
            {
                con.Close();
            }
            return false;
            
        }

        /// <summary>
        ///  this methoud will Update a SiteMember object in the Just For You Database... MAKE SURE THE SiteMember OBJECT IS VALID BEFORE PASSING IT TO THIS METHOUD!!!!!!!!!!!!!!!!
        ///  
        /// </summary>
        /// <param name="sm">takes in a SiteMember object</param>
        /// <returns>bool true=Added Successfully, false=There was an issue...</returns>
        public static bool UpdateUserInDB(SiteMember sm)
        {
            SqlConnection con = getMeConnected();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"UPDATE [dbo].[Users]SET [UserAccessName] = @username,[UserFName] = @first,[UserLName] = @last,[UserEmail] = @email,[UserPassword] = @pass,[UserEmailUpdates] = @updates,[UserAccess] = @accesslevel
WHERE [UserID] = @user";

            cmd.Parameters.AddWithValue("@first", sm.UserFName);
            cmd.Parameters.AddWithValue("@last", sm.UserLName);
            cmd.Parameters.AddWithValue("@email", sm.UserEmail);
            cmd.Parameters.AddWithValue("@pass", sm.UserPassword);
            cmd.Parameters.AddWithValue("@updates", sm.UserEmailUpdates);
            cmd.Parameters.AddWithValue("@accesslevel", sm.UserAccess);
            cmd.Parameters.AddWithValue("@username", sm.UserAccessName);
            cmd.Parameters.AddWithValue("@user", sm.UserID);

            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    return true;
            }
            finally
            {
                con.Close();
            }
            return false;
        }


        private static bool IsUserInDBYet(SiteMember sm)
        {
            SqlConnection con = getMeConnected();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT[UserAccessName]
FROM[JustForYou].[dbo].[Users]
where[UserAccessName] = @un";

            cmd.Parameters.AddWithValue("@un", sm.UserAccessName);

            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                    return true;
                else
                    return false;
            }
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        /// takes in a RegisterViewModel object and will return and INT representing the number of rows in the database with a matching UserAccessName
        /// </summary>
        /// <param name="nuser">RegisterViewModel object</param>
        /// <returns>int</returns>
        public static int IsUserNameTaken(RegisterViewModel nuser)
        {
            SqlConnection con = getMeConnected();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT[UserAccessName]
FROM[JustForYou].[dbo].[Users]
where[UserAccessName] = @un";

            cmd.Parameters.AddWithValue("@un", nuser.UserAccessName);

            try
            {
                con.Open();
                int rows = 0;
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                        rows++;
                    return rows;
                }
                else
                    return rows;
            }
            finally
            {
                con.Close();
            }
        }



        /// <summary>
        /// takes in a RegisterViewModel object and will return the number of rows in the database matching the UserEmail with the UserEmail in the RegisterViewModel.
        /// </summary>
        /// <param name="nuser">RegisterViewModel object</param>
        /// <returns>int</returns>
        public static int IsEmailTaken(RegisterViewModel nuser)
        {
            SqlConnection con = getMeConnected();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT[UserEmail]
FROM [JustForYou].[dbo].[Users]
where [UserEmail] = @un";

            cmd.Parameters.AddWithValue("@un", nuser.UserEmail);

            try
            {
                con.Open();
                int rows = 0;
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                        rows++;
                    return rows;
                }
                else
                    return rows;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// takes in a LoginModel object and returns Null if no user is found... If a user is found it will return a full SiteMember object... :)
        /// </summary>
        /// <param name="user">LoginModel object</param>
        /// <returns> SiteMember object (the object can be returned as null so like check for nulls and stuff... :) )</returns>
        public static SiteMember getUserLoggedIn(LoginModel user)
        {
            SiteMember sm = new SiteMember();

            SqlConnection con = getMeConnected();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT [UserID],[UserFName],[UserLName],[UserEmail],[UserPassword],[UserEmailUpdates],[UserAccess],[UserAccessName]
FROM [dbo].[Users]
where [UserAccessName] = @un and [UserPassword] = @ps";

            cmd.Parameters.AddWithValue("@un", user.UserName);
            cmd.Parameters.AddWithValue("@ps", user.Password);

            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    
                    sm.UserFName = rdr["UserFName"].ToString();
                    sm.UserLName = rdr["UserLName"].ToString();
                    sm.UserEmail = rdr["UserEmail"].ToString();
                    sm.UserPassword = rdr["UserPassword"].ToString();
                    sm.UserEmailUpdates = (bool)rdr["UserEmailUpdates"];
                    sm.UserAccess = Convert.ToInt32(rdr["UserAccess"]);
                    sm.UserAccessName = rdr["UserAccessName"].ToString();
                    sm.UserID = Convert.ToInt32(rdr["UserID"]);

                }
            }
            finally
            {
                con.Close();
            }
            return sm;
        }

        /// <summary>
        /// takes in an INT representing the UserID and returns a Full SiteMember Object... :)
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static SiteMember getMember(int userID)
        {
            SiteMember sm = new SiteMember();

            SqlConnection con = getMeConnected();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT [UserID],[UserFName],[UserLName],[UserEmail],[UserPassword],[UserEmailUpdates],[UserAccess],[UserAccessName]
FROM [dbo].[Users]
where [UserID] = @id";

            cmd.Parameters.AddWithValue("@id", userID);

            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    sm.UserFName = rdr["UserFName"].ToString();
                    sm.UserLName = rdr["UserLName"].ToString();
                    sm.UserEmail = rdr["UserEmail"].ToString();
                    sm.UserPassword = rdr["UserPassword"].ToString();
                    sm.UserEmailUpdates = (bool)rdr["UserEmailUpdates"];
                    sm.UserAccess = Convert.ToInt32(rdr["UserAccess"]);
                    sm.UserAccessName = rdr["UserAccessName"].ToString();
                    sm.UserID = Convert.ToInt32(rdr["UserID"]);
                }
            }
            catch
            {
                return sm;
            }
            finally
            {
                con.Close();
            }
            return sm;
        }

        /// <summary>
        /// takes in nothing and returns a list of SiteMember objects...
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>List of SiteMember objects</returns>
        public static List<SiteMember> getAllMembers()
        {
            List<SiteMember> sitemembers = new List<SiteMember>();
            SqlConnection con = getMeConnected();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT [UserID],[UserFName],[UserLName],[UserEmail],[UserPassword],[UserEmailUpdates],[UserAccess],[UserAccessName]
FROM [dbo].[Users]";
            
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SiteMember sm = new SiteMember();
                    sm.UserFName = rdr["UserFName"].ToString();
                    sm.UserLName = rdr["UserLName"].ToString();
                    sm.UserEmail = rdr["UserEmail"].ToString();
                    sm.UserPassword = rdr["UserPassword"].ToString();
                    sm.UserEmailUpdates = (bool)rdr["UserEmailUpdates"];
                    sm.UserAccess = Convert.ToInt32(rdr["UserAccess"]);
                    sm.UserAccessName = rdr["UserAccessName"].ToString();
                    sm.UserID = Convert.ToInt32(rdr["UserID"]);
                    sitemembers.Add(sm);
                }
            }
            catch
            {
                return sitemembers;
            }
            finally
            {
                con.Close();
            }
            return sitemembers;
        }
    }
}