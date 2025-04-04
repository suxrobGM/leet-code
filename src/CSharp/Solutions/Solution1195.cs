using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1195
{
    /// <summary>
    /// 1195. Fizz Buzz Multithreaded - Hard
    /// <a href="https://leetcode.com/problems/fizz-buzz-multithreaded">See the problem</a>
    /// </summary>
    public class FizzBuzz
    {
        private int n;
        private int count = 1;
        private readonly object lockObj = new();

        public FizzBuzz(int n)
        {
            this.n = n;
        }

        // printFizz() outputs "fizz". Do not change or remove this line.
        public void Fizz(Action printFizz)
        {
            while (true)
            {
                lock (lockObj)
                {
                    if (count > n) return;
                    if (count % 3 == 0 && count % 5 != 0)
                    {
                        printFizz();
                        count++;
                    }
                }
            }
        }

        // printBuzz() outputs "buzz". Do not change or remove this line.
        public void Buzz(Action printBuzz)
        {
            while (true)
            {
                lock (lockObj)
                {
                    if (count > n) return;
                    if (count % 5 == 0 && count % 3 != 0)
                    {
                        printBuzz();
                        count++;
                    }
                }
            }
        }

        // printFizzBuzz() outputs "fizzbuzz". Do not change or remove this line.
        public void Fizzbuzz(Action printFizzBuzz)
        {
            while (true)
            {
                lock (lockObj)
                {
                    if (count > n) return;
                    if (count % 3 == 0 && count % 5 == 0)
                    {
                        printFizzBuzz();
                        count++;
                    }
                }
            }
        }

        // printNumber(x) outputs "x", where x is an integer. Do not change or remove this line.
        public void Number(Action<int> printNumber)
        {
            while (true)
            {
                lock (lockObj)
                {
                    if (count > n) return;
                    if (count % 3 != 0 && count % 5 != 0)
                    {
                        printNumber(count);
                        count++;
                    }
                }
            }
        }
    }
}
