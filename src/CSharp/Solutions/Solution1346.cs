using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1346
{
    /// <summary>
    /// 1346. Check If N and Its Double Exist - Easy
    /// <a href="https://leetcode.com/problems/check-if-n-and-its-double-exist">See the problem</a>
    /// </summary>
    public bool CheckIfExist(int[] arr)
    {
        var seen = new HashSet<int>();

        foreach (int num in arr)
        {
            if (seen.Contains(num * 2) || (num % 2 == 0 && seen.Contains(num / 2)))
            {
                return true;
            }
            seen.Add(num);
        }

        return false;
    }
}
