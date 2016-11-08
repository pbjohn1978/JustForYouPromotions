using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustForYouPromotions.Models
{
    public static class ValidatorClass
    {

        /// <summary>
        /// takes in a RegisterViewModel object and will return and interger value representing the status of the entered data:
        /// 
        ///     Return values codes... :)
        ///     0 = Valid User
        ///     1 = UserName is already taken
        ///     2 = Password and confirm password do not match
        ///     3 = Email Address has already been used
        ///     
        /// </summary>
        /// <param name="nuser"></param>
        /// <returns>int</returns>
        public static int IsValidUser(RegisterViewModel nuser)
        {

            if (!(nuser.Password.Equals(nuser.ConfirmPassword)))
                return 2;
            //TODO: Add UserAccessName column to db... the line below is untested and cant be tested until the column is added... :)
            //////if (HelperDB.IsUserNameTaken(nuser))
            //////    return 1;

            if (HelperDB.IsEmailTaken(nuser))
                return 3;

            return 0;
        }
    }
}