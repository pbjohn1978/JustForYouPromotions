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

            if (HelperDB.IsUserNameTaken(nuser) > 0)
                return 1;

            if (HelperDB.IsEmailTaken(nuser) > 0)
                return 3;

            return 0;
        }

        public static int IsValidUserUpdating(RegisterViewModel nu)
        {
            if (!(nu.Password.Equals(nu.ConfirmPassword)))
                return 2;

            if ( HelperDB.IsUserNameTaken(nu) > 1)
                return 1;

            if (HelperDB.IsEmailTaken(nu) > 1)
                return 3;

            return 0;
        }
    }
}