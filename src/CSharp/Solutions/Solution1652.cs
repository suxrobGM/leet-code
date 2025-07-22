using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1652
{
    /// <summary>
    /// 1652. Defuse the Bomb - Easy
    /// <a href="https://leetcode.com/problems/defuse-the-bomb">See the problem</a>
    /// </summary>
    public int[] Decrypt(int[] code, int k)
    {
        int n = code.Length;
        int[] result = new int[n];

        if (k == 0)
        {
            Array.Fill(result, 0);
            return result;
        }

        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            for (int j = 1; j <= Math.Abs(k); j++)
            {
                int index = (i + j * (k > 0 ? 1 : -1) + n) % n;
                sum += code[index];
            }
            result[i] = sum;
        }

        return result;
    }
}
