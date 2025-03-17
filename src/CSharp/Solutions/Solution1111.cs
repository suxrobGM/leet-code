using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1111
{
    /// <summary>
    /// 1111. Maximum Nesting Depth of Two Valid Parentheses Strings - Medium
    /// <a href="https://leetcode.com/problems/maximum-nesting-depth-of-two-valid-parentheses-strings">See the problem</a>
    /// </summary>
    public int[] MaxDepthAfterSplit(string seq)
    {
        var result = new int[seq.Length];
        var depth = 0;
        for (var i = 0; i < seq.Length; i++)
        {
            if (seq[i] == '(')
            {
                depth++;
                result[i] = depth % 2;
            }
            else
            {
                result[i] = depth % 2;
                depth--;
            }
        }
        return result;
    }
}
