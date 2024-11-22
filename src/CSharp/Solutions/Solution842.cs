using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution842
{
    /// <summary>
    /// 842. Split Array into Fibonacci Sequence - Medium
    /// <a href="https://leetcode.com/problems/split-array-into-fibonacci-sequence">See the problem</a>
    /// </summary>
    public IList<int> SplitIntoFibonacci(string num)
    {
        var result = new List<int>();
        if (Backtrack(num, 0, result))
        {
            return result;
        }
        return [];
    }

    private bool Backtrack(string num, int index, List<int> sequence)
    {
        if (index == num.Length && sequence.Count >= 3)
        {
            return true; // Valid sequence found
        }

        long currentNumber = 0;
        for (int i = index; i < num.Length; i++)
        {
            // Prevent leading zeroes
            if (i > index && num[index] == '0')
            {
                break;
            }

            // Form the current number
            currentNumber = currentNumber * 10 + (num[i] - '0');
            if (currentNumber > int.MaxValue)
            {
                break; // Number exceeds 32-bit integer limit
            }

            int currentInt = (int)currentNumber;

            // Check if the sequence can continue
            if (sequence.Count >= 2)
            {
                long sum = (long)sequence[sequence.Count - 1] + sequence[sequence.Count - 2];
                if (currentNumber < sum)
                {
                    continue; // Current number is too small
                }
                if (currentNumber > sum)
                {
                    break; // Current number is too large
                }
            }

            // Add the current number to the sequence and backtrack
            sequence.Add(currentInt);
            if (Backtrack(num, i + 1, sequence))
            {
                return true;
            }
            sequence.RemoveAt(sequence.Count - 1); // Backtrack
        }

        return false;
    }
}
