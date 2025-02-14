using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution989
{
    /// <summary>
    /// 989. Add to Array-Form of Integer - Easy
    /// <a href="https://leetcode.com/problems/add-to-array-form-of-integer">See the problem</a>
    /// </summary>
    public IList<int> AddToArrayForm(int[] num, int k)
    {
        var result = new List<int>();
        var i = num.Length - 1;

        while (i >= 0 || k > 0)
        {
            if (i >= 0)
            {
                k += num[i];
            }

            result.Add(k % 10);
            k /= 10;
            i--;
        }

        result.Reverse();

        return result;
    }
}
