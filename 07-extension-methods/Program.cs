using System;

namespace _07_extension_methods
{
    class Foo {
        internal Foo(string id, int age) {
            Id = id;
            Age = age;
        }
        internal string Id { get; }
        internal int Age { get; }
    }

    static class FooExtensions {
        // Extension method
        internal static string Print(this Foo foo) {
            return String.Format("{0} is a{1}", foo.Id, foo.Age < 18 ? " minor" : "n adult");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var foo1 = new Foo("Adult Foo", 34);
            var foo2 = new Foo("Child Foo", 8);
            Console.WriteLine("foo1: {0}", foo1.Print());
            Console.WriteLine("foo2: {0}", foo2.Print());
        }
    }
}
