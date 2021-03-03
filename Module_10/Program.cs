using System;
using System.Collections;

namespace Test
{
    public class Program
    {
        static ICalculator Calculator { get; set; }

        static void Main()
        {
            var calc = new Calculator();
            calc.Write();

            calc.Solve(calc.Read());
            Console.ReadKey();
        }
    }

    public interface ICalculator
    {
        void Write();

        (int, int) Read();

        void Solve((int a, int b) t);
    }

    public class Calculator : ICalculator
    {
        public void Write()
        {
            Console.WriteLine("Запишите число a и b");
        }

        public (int, int) Read()
        {
            int a;
            int b;
            try
            {
                a = Convert.ToInt32(Console.ReadLine());
                b = Convert.ToInt32(Console.ReadLine());

            }
            catch (Exception ex)
            {
                if (ex is FormatException) Console.WriteLine("Введено некорректное значение");
                else Console.WriteLine("Произошла непредвиденная ошибка в приложении");
                a = 0;
                b = 0;
            }
            finally
            {
                Console.WriteLine("Блок Finally сработал!");
            }
            return (a, b);
        }

        public void Solve((int a, int b) t)
        {
            int result = t.a + t.b;
            Console.WriteLine(result);
        }
    }
}
