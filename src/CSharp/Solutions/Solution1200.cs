using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1200
{
    /// <summary>
    /// 1200. Minimum Absolute Difference - Easy
    /// <a href="https://leetcode.com/problems/minimum-absolute-difference">See the problem</a>
    /// </summary>
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        Array.Sort(arr);
        var result = new List<IList<int>>();
        var minDiff = int.MaxValue;

        for (var i = 1; i < arr.Length; i++)
        {
            var diff = arr[i] - arr[i - 1];
            if (diff < minDiff)
            {
                minDiff = diff;
                result.Clear();
                result.Add([arr[i - 1], arr[i]]);
            }
            else if (diff == minDiff)
            {
                result.Add([arr[i - 1], arr[i]]);
            }
        }

        return result;
    }
}
