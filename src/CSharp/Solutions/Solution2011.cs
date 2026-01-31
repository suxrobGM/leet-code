namespace LeetCode.Solutions;

public class Solution2011
{
    /// <summary>
    /// 2011. Final Value of Variable After Performing Operations - Easy
    /// <a href="https://leetcode.com/problems/final-value-of-variable-after-performing-operations">See the problem</a>
    /// </summary>
    public int FinalValueAfterOperations(string[] operations)
    {
        int x = 0;
        foreach (var op in operations)
        {
            x += op.Contains('+') ? 1 : -1;
        }
        return x;
    }
}
