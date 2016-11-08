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
            return new SqlConnection(ConfigurationManager.ConnectionStrings["jfy_schoolBrucesRoom"].ConnectionString);
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
            bool isAdded = true;

            SqlConnection con = getMeConnected();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"INSERT INTO [dbo].[Users]([UserFName],[UserLName],[UserEmail],[UserPassword],[UserEmailUpdates],[UserAccess])
VALUES(@firstname,@lastname,@email,@password,@useremailupdates,@useraccess)";

            cmd.Parameters.AddWithValue("@firstname", sm.UserFName);
            cmd.Parameters.AddWithValue("@lastname", sm.UserLName);
            cmd.Parameters.AddWithValue("@email", sm.UserEmail);
            cmd.Parameters.AddWithValue("@password", sm.UserPassword);
            cmd.Parameters.AddWithValue("@useremailupdates", sm.UserEmailUpdates);
            cmd.Parameters.AddWithValue("@useraccess", sm.UserAccess);

            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    isAdded = true;
            }
            finally
            {
                con.Close();
            }
            return isAdded;
        }


        /// <summary>
        /// takes in a RegisterViewModel object and will return TRUE (bool) if the username is already taken... 
        /// </summary>
        /// <param name="nuser">RegisterViewModel object</param>
        /// <returns>bool</returns>
        public static bool IsUserNameTaken(RegisterViewModel nuser)
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
        /// takes in a RegisterViewModel object and will return TRUE (bool) if the Email is already taken... 
        /// </summary>
        /// <param name="nuser">RegisterViewModel object</param>
        /// <returns>bool</returns>
        public static bool IsEmailTaken(RegisterViewModel nuser)
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
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                    return true;
                else
                    return false;
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
    }
}