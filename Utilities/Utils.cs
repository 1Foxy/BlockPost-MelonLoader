using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;

namespace e.Utilities
{
    internal class Utils
    {
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            Random random = new Random();
            char[] randomString = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomString[i] = chars[random.Next(0, chars.Length)];
            }

            return new string(randomString);
        }

        public static string GenerateSwastik(int length)
        {
            const string swastika = "卐";

            if (length <= 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(swastika);
            }

            return sb.ToString();
        }

        public static string ConvertRotToString(Il2CppStructArray<float> rot)
        {
            if (rot != null)
            {
                return string.Join(", ", rot);
            }
            else
            {
                return "null";
            }
        }
    }
}
