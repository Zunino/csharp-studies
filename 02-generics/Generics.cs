using System;
using System.Collections.Generic;

namespace DotnetStudies {

    class Generics {

        private static void PrintSeparator() {
            Console.Out.WriteLine("===============");
        }

        private static void PlayWithAList() {
            IList<string> names = new List<string>();
            names.Add("Andre Zunino");
            names.Add("John Marston");
            names.Add("Michael Jordan");
            for (int i = 0; i < names.Count; ++i) {
                Console.WriteLine("Name {0}: {1}", i, names[i]);
            }
        }

        private static void PlayWithACustomGenericCollectionOfInt() {
            CircularBuffer<int> buffer = new CircularBuffer<int>(3);
            Console.Out.WriteLine("Buffer: {0}", buffer.ToString());
            buffer.Add(10);
            buffer.Add(20);
            buffer.Add(30);
            buffer.Add(40);
            buffer.Add(50);
            Console.WriteLine("Buffer: {0}", buffer.ToString());
        }

        private static void PlayWithACustomGenericCollectionOfString() {
            CircularBuffer<string> buffer = new CircularBuffer<string>(4);
            Console.Out.WriteLine("Buffer: {0}", buffer.ToString());
            buffer.Add("red");
            buffer.Add("green");
            buffer.Add("blue");
            buffer.Add("black");
            buffer.Add("white");
            Console.WriteLine("Buffer: {0}", buffer.ToString());
        }

        private static void PlayWithGenericMethodsAndAListOfInt() {
            List<int> numbers = new List<int>();
            numbers.Add(15);
            numbers.Add(5);
            numbers.Add(8);
            numbers.Add(10);
            numbers.Add(1);
            numbers.Add(4);
            // String.Join is a generic method
            Console.WriteLine(String.Join(" ", numbers));
            // Ditto for BubbleSort.Sort
            BubbleSort.Sort(numbers);
            Console.WriteLine(String.Join(" ", numbers));
        }

        private static void PlayWithGenericMethodsAndAListOfString() {
            List<string> countries = new List<string>();
            countries.Add("Brazil");
            countries.Add("United States of America");
            countries.Add("Argentina");
            countries.Add("Russia");
            countries.Add("Germany");
            countries.Add("England");
            // String.Join is a generic method
            Console.WriteLine(String.Join(" ", countries));
            // Ditto for BubbleSort.Sort
            BubbleSort.Sort(countries);
            Console.WriteLine(String.Join(" ", countries));
        }

        static void Main(string[] args) {
            PlayWithAList();
            PrintSeparator();
            PlayWithACustomGenericCollectionOfInt();
            PrintSeparator();
            PlayWithACustomGenericCollectionOfString();
            PrintSeparator();
            PlayWithGenericMethodsAndAListOfInt();
            PrintSeparator();
            PlayWithGenericMethodsAndAListOfString();
        }

    }

}
