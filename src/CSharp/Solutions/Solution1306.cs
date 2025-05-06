using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1306
{
    /// <summary>
    /// 1306. Jump Game III - Medium
    /// <a href="https://leetcode.com/problems/jump-game-iii">See the problem</a>
    /// </summary>
    public bool CanReach(int[] arr, int start)
    {
        if (start < 0 || start >= arr.Length || arr[start] < 0) return false;
        if (arr[start] == 0) return true;

        int jump = arr[start];
        arr[start] = -1; // Mark as visited

        return CanReach(arr, start + jump) || CanReach(arr, start - jump);
    }
}
