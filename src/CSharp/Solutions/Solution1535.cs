using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1535
{
    /// <summary>
    /// 1535. Find the Winner of an Array Game - Medium
    /// <a href="https://leetcode.com/problems/find-the-winner-of-an-array-game">See the problem</a>
    /// </summary>
    public int GetWinner(int[] arr, int k)
    {
        int n = arr.Length;
        if (n == 1 || k == 0) return arr[0];

        int currentWinner = arr[0];
        int currentCount = 0;

        for (int i = 1; i < n; i++)
        {
            if (arr[i] > currentWinner)
            {
                currentWinner = arr[i];
                currentCount = 1;
            }
            else
            {
                currentCount++;
            }

            if (currentCount == k)
            {
                return currentWinner;
            }
        }

        return currentWinner;
    }
}
