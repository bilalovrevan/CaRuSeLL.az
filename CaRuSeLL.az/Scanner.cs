using System;
using System.Globalization;

namespace CaruSell.az_Project
{
    internal class Scaner
    {

        internal static int ReadInteger(string caption)
        {
        l1:
            Console.Write(caption);

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }
            goto l1;
        }
        internal static string ReadString(string caption)
        {
        l1:
            Console.Write(caption);
            string value = Console.ReadLine();
            if (string.IsNullOrEmpty(value))
                goto l1;

            return value;
        }
        internal static double ReadDouble(string caption)
        {
        l1:
            Console.Write(caption);

            if (double.TryParse(Console.ReadLine(), out double value))
            {
                return value;
            }
            goto l1;
        }
    }
}
