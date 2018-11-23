using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        class A
        {
            public void F() {
                Console.WriteLine("A");
            }
        }
        class B : A
        {
            new public void F()
            {
                Console.WriteLine("B");
            }
        }
        static int aa()
        {
            A a = new B();
            try
            {
                a.F();
                Console.WriteLine("try");
                return 5;
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }
        static void Main()
        {
            Console.WriteLine(aa());
        }
    }
}
