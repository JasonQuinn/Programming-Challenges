using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Problem20
{
    class Program
    {
        /// <summary>
        /// n! means n × (n  − 1) × ... × 3 × 2 × 1
        /// Find the sum of the digits in the number 100!
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Returns the sum of the digits
            Func<BigInteger, int> SumOfDigits = n => n.ToString().Select(u => int.Parse(u.ToString())).Sum(u => u);


            Func<BigInteger, BigInteger> Factorial = Fix<BigInteger, BigInteger>(fac => n => n == 0 ? 1 : n * fac(n - 1));
            var test = SumOfDigits(Factorial(100));

            Console.WriteLine(SumOfDigits(Factorial(100)));
            Console.Read();
        }

        /// <summary>
        /// Allows Recursive Func
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        static Func<R, T> Fix<R, T>(Func<Func<R, T>, Func<R, T>> f)
        {
            FuncRec<R, T> fRec = r => t => f(r(r))(t);
            return fRec(fRec);
        }
        delegate Func<T, R> FuncRec<T, R>(FuncRec<T, R> f);

        ///// <summary>
        ///// Calculate Large Factotial
        ///// </summary>
        ///// <param name="n"></param>
        ///// <returns></returns>
        //public static BigInteger Factorial(BigInteger n)
        //{
        //    return ((n == 0) ? 1 : n * Factorial(n - 1));
        //}

    }
}
