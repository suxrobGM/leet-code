namespace LeetCode.Solutions;

public class Solution599
{
    /// <summary>
    /// 599. Minimum Index Sum of Two Lists - Easy
    /// <a href="https://leetcode.com/problems/minimum-index-sum-of-two-lists">See the problem</a>
    /// </summary>
    public string[] FindRestaurant(string[] list1, string[] list2)
    {
        var dict = new Dictionary<string, int>();
        for (var i = 0; i < list1.Length; i++)
        {
            dict[list1[i]] = i;
        }

        var result = new List<string>();
        var minSum = int.MaxValue;

        for (var i = 0; i < list2.Length; i++)
        {
            if (dict.ContainsKey(list2[i]))
            {
                var sum = i + dict[list2[i]];
                if (sum < minSum)
                {
                    result.Clear();
                    result.Add(list2[i]);
                    minSum = sum;
                }
                else if (sum == minSum)
                {
                    result.Add(list2[i]);
                }
            }
        }
        return [.. result];
    }
}
