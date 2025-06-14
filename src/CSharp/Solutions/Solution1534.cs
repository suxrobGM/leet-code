using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1534
{
    private readonly Dictionary<(int, char, int, int), int> memo = [];

    /// <summary>
    /// 1534. Count Good Triplets - Easy
    /// <a href="https://leetcode.com/problems/count-good-triplets">See the problem</a>
    /// </summary>
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        int n = arr.Length;
        int count = 0;

        for (int i = 0; i < n - 2; i++)
        {
            for (int j = i + 1; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    if (Math.Abs(arr[i] - arr[j]) <= a &&
                        Math.Abs(arr[j] - arr[k]) <= b &&
                        Math.Abs(arr[i] - arr[k]) <= c)
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
}
