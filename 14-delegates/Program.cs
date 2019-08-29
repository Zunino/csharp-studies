using System;
using System.Linq;

namespace _14_delegates
{

    class Foo {
        internal Foo(string name)
        {
            Name = name;
        }
        internal void Hello() {
            Console.WriteLine($"Hello from {Name}");
        }
        internal static void StaticHello() {
            Console.WriteLine($"Static hello from a Foo");
        }
        internal string Name { get; }
    }

    static class FooExtensions {
        public static void Bye(this Foo foo) {
            Console.WriteLine($"Bye from {foo.Name}");
        }
    }
    
    class Program
    {
        private delegate void FooDelegate();
        private delegate int AggrDelegate(int[] coll);

        static void Main(string[] args)
        {
            var foo1 = new Foo("Foo One");

            FooDelegate del1 = foo1.Hello;
            FooDelegate del2 = Foo.StaticHello;
            FooDelegate del3 = foo1.Bye;

            del1();
            del2();
            del3();
        }
    }

}
