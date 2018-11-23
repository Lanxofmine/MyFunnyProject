using System;
namespace ConsoleApp2
{
    class Program
    {
        public abstract class A
        {
            public virtual static void M()
            {
                Console.WriteLine("AMAMAMAMAM");
            }
            public abstract void F();

            public void G()
            {
                Console.WriteLine("GGGGGGG");
            }
        }
        interface INftr1
        {
            string this[int index] { get; set; }
            event EventHandler Even;
            void Find(int value);
            string Point { get; set; }
        }
        class B : A
        {
            public override static void M()
            {
                Console.WriteLine("BMBMBM");
            }

            public override void F()
            {
                Console.WriteLine("BFBFBFBFBFBF");
            }
        }
        class C : B, INftr1
        {
            public string this[int index] { get => index.ToString(); set => value.ToString(); }

            public string Point { get => Point; set { Point = value; } }

            public event EventHandler Even;

            public override void F()
            {
                Console.WriteLine("CFCFCFCFCF");
            }

            public void Find(int value)
            {
                Console.WriteLine("CFCFCFCFCF");
            }
        }
        static void Main(string[] args)
        {
            B b = (B)new C();
            b.F();
            A.M();
            C c = new C();
            Console.WriteLine(c[5]);
        }
    }
}
