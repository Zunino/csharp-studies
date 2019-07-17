using System;

namespace _10_strings
{
    class Program
    {
        private static string verbatim = @"I am a verbatim string.

            My white space characters and line breaks are preserved.
        ";

        private static string InterpolatedString(string name, string email)
        {
            return $"{name}'s email is {email}";
        }

        private static string InterpolatedVerbatimString(string name, long amount)
        {
            return $@"Dear {name},

Your payment of US{amount / 100:C} has been transferred
to your checking account.

Regards.
";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("VERBATIM:\n{0}", verbatim);
            Console.WriteLine("INTERPOLATED:\n{0}", InterpolatedString("Zunino", "neyzunino@gmail.com"));
            Console.WriteLine("\nBOTH:\n{0}", InterpolatedVerbatimString("Zunino", 1550000));
        }
    }
}
