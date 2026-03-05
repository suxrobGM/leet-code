namespace LeetCode.Solutions;

public class Solution2053
{
    /// <summary>
    /// 2053. Kth Distinct String in an Array - Easy
    /// <a href="https://leetcode.com/problems/kth-distinct-string-in-an-array">See the problem</a>
    /// </summary>
    public string KthDistinct(string[] arr, int k)
    {
        var count = new Dictionary<string, int>();
        foreach (var s in arr)
            count[s] = count.GetValueOrDefault(s, 0) + 1;

        foreach (var s in arr)
        {
            if (count[s] == 1 && --k == 0)
                return s;
        }

        return string.Empty;
    }
}
