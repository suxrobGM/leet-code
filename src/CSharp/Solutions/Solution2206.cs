namespace LeetCode.Solutions;

public class Solution2206
{
    /// <summary>
    /// 2206. Divide Array Into Equal Pairs - Easy
    /// <a href="https://leetcode.com/problems/divide-array-into-equal-pairs">See the problem</a>
    /// </summary>
    public bool DivideArray(int[] nums)
    {
        var count = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!count.ContainsKey(num))
            {
                count[num] = 0;
            }

            count[num]++;
        }

        foreach (var kvp in count)
        {
            if (kvp.Value % 2 != 0)
            {
                return false;
            }
        }

        return true;
    }
}
