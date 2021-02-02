using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotNetFramework.Test
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void ConstructorCallSequenceTest()
        {
            //var t = new Child();
            //public Parent()
            //public Child()

            Console.WriteLine();
            Console.WriteLine("var t = new Child();");
            var t = new Child();

            //var t1 = new Child(");
            //public Parent()
            //public Child(string tmp)
            Console.WriteLine();
            Console.WriteLine(@"var t1 = new Child("");");
            var t1 = new Child("");

            //var t2 = new Child(0);
            //public Parent()
            //public Child()
            //public Child(int tmp) : this()
            Console.WriteLine();
            Console.WriteLine("var t2 = new Child(0);");
            var t2 = new Child(0);

            //var t3 = new Child(0f);
            //public Parent()
            //public Child(float tmp) : base()
            Console.WriteLine();
            Console.WriteLine("var t3 = new Child(0f);");
            var t3 = new Child(0f);

            //var t4 = new Child(0d);
            //public Parent(string tmp)
            //public Child(double tmp) : base(")
            Console.WriteLine();
            Console.WriteLine("var t4 = new Child(0d);");
            var t4 = new Child(0d);
        }
    }

    public class Parent
    {
        public Parent() => Console.WriteLine("public Parent()");

        public Parent(string tmp) => Console.WriteLine("public Parent(string tmp)");
    }

    public class Child : Parent
    {
        public Child() => Console.WriteLine("public Child()");

        public Child(string tmp) => Console.WriteLine("public Child(string tmp)");

        public Child(int tmp) : this() => Console.WriteLine("public Child(int tmp) : this()");

        public Child(float tmp) : base() => Console.WriteLine("public Child(float tmp) : base()");

        public Child(double tmp) : base("") => Console.WriteLine(@"public Child(double tmp) : base("")");
    }
}
