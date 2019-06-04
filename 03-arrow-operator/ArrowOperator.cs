using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrowOperator
{

    class Foo
    {
        // arrow operator in expression-bodied member definition
        public Foo(string name) => this.name = name;
        public Foo(string name, int age) {
            this.name = name;
            this.age = age;
        }
        // ditto
        public override string ToString() =>
            String.Format("A Foo named \"{0}\"{1}", name, IsMinor() ? " (minor)" : "");
        public bool IsMinor() => age < 18;
        private string name;
        private int age;
    }

    class ArrowOperator
    {

        private static string Elements<T>(IEnumerable<T> collection)
        {
            return String.Format("{{{0}}}", String.Join(", ", collection));
        }

        private static void PlayWithLambdas()
        {
            int[] nums = { 3, 8, 1, 7, 2, 10, 9, 12 };
            int greatestOddNumber = nums
                .Where(n => n % 2 != 0)                 // arrow operator in lambda expression
                .Max();
            Console.WriteLine("The greatest odd number in {0} is: {1}",
                    Elements(nums),
                    greatestOddNumber);
            IEnumerable<int> oddNumbersLesserThan5 = nums
                .Where(n => n % 2 != 0)                 // ditto
                .Where(n => n < 5);
            Console.WriteLine("Odd numbers in {0} that are less than 5: {1}",
                    Elements(nums),
                    Elements(oddNumbersLesserThan5));
        }

        private static void PlayWithExpressionBodiedDefinitions()
        {
            Foo john = new Foo("John", 28);
            Console.WriteLine(john);
            Foo mary = new Foo("Mary", 26);
            Console.WriteLine(mary);
            Foo jane = new Foo("Jane", 9);
            Console.WriteLine(jane);
        }

        static void Main(string[] args)
        {
            PlayWithLambdas();
            PlayWithExpressionBodiedDefinitions();
        }

    }

}
