using System;
using System.Text.RegularExpressions;

namespace DLLValidation
{
    public class clsValidation
    {
        // Do it need this??
        public static bool ValidateEmpty(string str)
        {
            //Get rid of this
            if (String.IsNullOrEmpty(str))
            { Console.Out.WriteLine("Empty");}

            return !String.IsNullOrEmpty(str);
        }

        public static bool ValidateLength(string str, int maxlen)
        {
            //Get rid of this
            if (str.Length <= maxlen)
                Console.Out.WriteLine("Not too long");

            return (str.Length <= maxlen) ? true : false;
        }

        public static bool ValidateLength(string str, int minlen, int maxlen)
        {
            //Get rid of this
            if (str.Length > minlen && str.Length < maxlen)
                Console.Out.WriteLine("Right length");

            return (str.Length > minlen && str.Length < maxlen) ? true : false;
        }

        public static bool ValidateNumeric(string str)
        {
            try
            {
                Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidateAnyNonSpecialCharacters(string str)
        {
            string strRegex = "[^a-z]";
            Regex RgxUrl = new Regex(strRegex, RegexOptions.IgnoreCase);
            //Console.WriteLine("There are no special characters " + RgxUrl.IsMatch(str));
            return (RgxUrl.IsMatch(str));
        }

        public static bool ValidateEmail(string str)
        {
            Regex RgxUrl = new(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            return (RgxUrl.IsMatch(str));
        }



        // Do I need this??
        //public static bool ValidateNumLength(string str, int len, int maxlen)
        //{

        //    return true;
        //}

        //Dont think i need this

        //public class clsValidation1
        //{
        //    public static bool ValidateEmpty(string str)
        //    {
        //        if (String.IsNullOrEmpty(str))
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //}
    }
}
