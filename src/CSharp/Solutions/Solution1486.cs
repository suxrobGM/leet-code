using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1486
{
    /// <summary>
    /// 1486. XOR Operation in an Array - Easy
    /// <a href="https://leetcode.com/problems/xor-operation-in-an-array">See the problem</a>
    /// </summary>
    public int XorOperation(int n, int start)
    {
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            result ^= start + 2 * i;
        }
        return result;
    }
}
