using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1331
{
    /// <summary>
    /// 1331. Rank Transform of an Array - Easy
    /// <a href="https://leetcode.com/problems/rank-transform-of-an-array">See the problem</a>
    /// </summary>
    public int[] ArrayRankTransform(int[] arr)
    {
        int n = arr.Length;
        var sortedArr = (int[])arr.Clone();
        Array.Sort(sortedArr);
        var rankMap = new Dictionary<int, int>();
        int rank = 1;

        foreach (int num in sortedArr)
        {
            if (!rankMap.ContainsKey(num))
            {
                rankMap[num] = rank++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            arr[i] = rankMap[arr[i]];
        }

        return arr;
    }
}
