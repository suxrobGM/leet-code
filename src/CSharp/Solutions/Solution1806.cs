using System.Text;

namespace LeetCode.Solutions;

public class Solution1806
{
    /// <summary>
    /// 1806. Minimum Number of Operations to Reinitialize a Permutation - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-operations-to-reinitialize-a-permutation">See the problem</a>
    /// </summary>
    public int ReinitializePermutation(int n)
    {
        int pos = 1;
        int steps = 0;

        do
        {
            if (pos < n / 2)
            {
                pos = pos * 2;
            }
            else
            {
                pos = (pos - n / 2) * 2 + 1;
            }
            steps++;
        } while (pos != 1);

        return steps;
    }
}

