using System.Text;

namespace LeetCode.Solutions;

public class Solution1773
{
    /// <summary>
    /// 1773. Count Items Matching a Rule - Easy
    /// <a href="https://leetcode.com/problems/count-items-matching-a-rule">See the problem</a>
    /// </summary>
    public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
    {
        int index = ruleKey switch
        {
            "type" => 0,
            "color" => 1,
            "name" => 2,
            _ => -1
        };

        if (index == -1) return 0;

        return items.Count(item => item[index] == ruleValue);
    }
}
