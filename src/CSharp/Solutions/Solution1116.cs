using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1116
{
    /// <summary>
    /// 1116. Print Zero Even Odd - Medium
    /// <a href="https://leetcode.com/problems/print-zero-even-odd">See the problem</a>
    /// </summary>
    public class ZeroEvenOdd
    {
        private int n;
        private int currentNumber = 1;

        private object lockObj = new object();
        private bool zeroTurn = true; // Track whose turn it is

        public ZeroEvenOdd(int n)
        {
            this.n = n;
        }

        public void Zero(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i++)
            {
                lock (lockObj)
                {
                    while (!zeroTurn)
                    {
                        Monitor.Wait(lockObj); // Wait until zero's turn
                    }

                    printNumber(0);
                    zeroTurn = false; // Hand control to either even or odd
                    Monitor.PulseAll(lockObj); // Notify other threads
                }
            }
        }

        public void Even(Action<int> printNumber)
        {
            for (int i = 2; i <= n; i += 2)
            {
                lock (lockObj)
                {
                    while (zeroTurn || currentNumber % 2 != 0)
                    {
                        Monitor.Wait(lockObj); // Wait until it's even's turn
                    }

                    printNumber(currentNumber);
                    currentNumber++;
                    zeroTurn = true; // Hand control to zero
                    Monitor.PulseAll(lockObj); // Notify other threads
                }
            }
        }

        public void Odd(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i += 2)
            {
                lock (lockObj)
                {
                    while (zeroTurn || currentNumber % 2 != 1)
                    {
                        Monitor.Wait(lockObj); // Wait until it's odd's turn
                    }

                    printNumber(currentNumber);
                    currentNumber++;
                    zeroTurn = true; // Hand control to zero
                    Monitor.PulseAll(lockObj); // Notify other threads
                }
            }
        }
    }
}
