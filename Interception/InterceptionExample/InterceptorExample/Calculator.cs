using System;

namespace InterceptorExample
{
    public interface ICalculator
    {
        int AddTwoNumbers(int x, int y);
    }

    public class Calculator : ICalculator
    {
        public int AddTwoNumbers(int x, int y)
        {
            return x + y;
        }
    }
}