namespace LeetCode.Solutions;

public class Solution2150
{
    /// <summary>
    /// 2150. Find All Lonely Numbers in the Array - Medium
    /// <a href="https://leetcode.com/problems/find-all-lonely-numbers-in-the-array">See the problem</a>
    /// </summary>
    public IList<int> FindLonely(int[] nums)
    {
        var count = new Dictionary<int, int>();
        foreach (int n in nums)
        {
            count[n] = count.GetValueOrDefault(n) + 1;
        }

        var result = new List<int>();
        foreach (int n in nums)
        {
            if (count[n] == 1 && !count.ContainsKey(n - 1) && !count.ContainsKey(n + 1))
            {
                result.Add(n);
            }
        }
        return result;
    }
}
