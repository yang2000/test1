using System;
using System.Linq;

namespace Lambda1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            For example, a lambda expression that has two parameters but returns no value corresponds 
            to an Action<T1,T2> delegate. A lambda expression that has one parameter and returns a value 
            corresponds to Func<T,TResult> delegate.-
             */
            Func<int, double> square = x => x * x* 1.1;
            Console.WriteLine(square(5));


            System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
            Console.WriteLine(e);

            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            Console.WriteLine(string.Join(" ", squaredNumbers));



            Console.WriteLine("Hello World!");
        }
    }
}
