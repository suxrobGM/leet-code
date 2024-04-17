namespace LeetCode.Solutions;

public class Solution89
{
    /// <summary>
    /// 89. Gray Code - Medium
    /// <a href="https://leetcode.com/problems/gray-code">See the problem</a>
    /// </summary>
    public IList<int> GrayCode(int n)
    {
        var result = new List<int> { 0 };
        
        for (var i = 0; i < n; i++)
        {
            var size = result.Count;
            for (var j = size - 1; j >= 0; j--)
            {
                result.Add(result[j] | 1 << i);
            }
        }
        
        return result;
    }
}
