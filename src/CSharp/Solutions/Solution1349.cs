using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1349
{
    /// <summary>
    /// 1349. Maximum Students Taking Exam - Hard
    /// <a href="https://leetcode.com/problems/maximum-students-taking-exam">See the problem</a>
    /// </summary>
    public int MaxStudents(char[][] seats)
    {
        int rows = seats.Length;
        int cols = seats[0].Length;
        int allMasks = 1 << cols;
        Dictionary<int, int> previous = new() { [0] = 0 };

        for (int row = 0; row < rows; row++)
        {
            int available = 0;
            for (int col = 0; col < cols; col++)
            {
                if (seats[row][col] == '.')
                {
                    available |= 1 << col;
                }
            }

            Dictionary<int, int> current = new();
            for (int mask = 0; mask < allMasks; mask++)
            {
                if ((mask & ~available) != 0 || (mask & (mask << 1)) != 0)
                {
                    continue;
                }

                int students = CountBits(mask);
                foreach ((int previousMask, int previousStudents) in previous)
                {
                    if ((mask & (previousMask << 1)) != 0 || (mask & (previousMask >> 1)) != 0)
                    {
                        continue;
                    }

                    int candidate = previousStudents + students;
                    if (!current.TryGetValue(mask, out int best) || candidate > best)
                    {
                        current[mask] = candidate;
                    }
                }
            }

            previous = current;
        }

        return previous.Values.Max();
    }

    private static int CountBits(int mask)
    {
        int count = 0;
        while (mask != 0)
        {
            mask &= mask - 1;
            count++;
        }

        return count;
    }
}
