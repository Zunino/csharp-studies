/**
 * This example explores value and reference semantics as well as the 'in', 'out' and 'ref' modifiers.
 *
 * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/passing-parameters
 * https://docs.microsoft.com/en-us/dotnet/csharp/write-safe-efficient-code
 *
 * Andre Zunino <neyzunino@gmail.com>
 * 12 August 2019
 */

using System;

namespace _12_val_ref_semantics
{
    class Program
    {
        private static void Trace(string message)
        {
            Trace<string>($"\n{message}", null);
        }

        private static void Trace<T>(string message, T value)
        {
            if (value != null)
            {
                Console.WriteLine($"{message}: {value}");
            } else {
                Console.WriteLine(message);
            }
        }

        private static void TestValueTypeArg(int value)
        {
            value++;
        }

        private static void TestReferenceTypeArg(string[] colors)
        {
            colors[2] = "silver";
        }

        private static void TestInModifier(in string s)
        {
            Console.WriteLine($"Got '{s}'; can't modify it");
            //s = "BAR"; // in parameters are readonly
        }

        private static void TestOutModifier(string s, out int value)
        {
            value = s.Length * 2;
        }

        private static void TestRefModifier(ref string s, ref int v)
        {
            Console.WriteLine("Uppercasing 's' and doubling 'v'");
            s = s.ToUpper();
            v *= 2;
        }

        static void Main(string[] args)
        {
            Trace("Value type");
            int i = 42;
            Trace("int i (before)", i);
            TestValueTypeArg(i);
            Trace("int i (after)", i);

            Trace("Reference type");
            string[] colors = {"red", "green", "blue"};
            Trace("string[] colors (before)", string.Join(", ", colors));
            TestReferenceTypeArg(colors);
            Trace("string[] colors (after)", string.Join(", ", colors));

            Trace("In modifier");
            var s = "FOO";
            Trace("string s", s);
            TestInModifier(s);

            Trace("Out modifier");
            s = "FOO";
            Trace("string s", s);
            int sLen;
            TestOutModifier(s, out sLen);
            Trace("sLen", sLen);

            Trace("Ref modifier");
            s = "bar";
            i = 8;
            Trace("string s", s);
            Trace("int i", i);
            TestRefModifier(ref s, ref i);
            Trace("string s", s);
            Trace("int i", i);
        }
    }
}
