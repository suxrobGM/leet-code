namespace LeetCode.Solutions;

public class Solution2149
{
    /// <summary>
    /// 2149. Rearrange Array Elements by Sign - Medium
    /// <a href="https://leetcode.com/problems/rearrange-array-elements-by-sign">See the problem</a>
    /// </summary>
    public int[] RearrangeArray(int[] nums)
    {
        int[] result = new int[nums.Length];
        int posIndex = 0, negIndex = 1;
        foreach (var num in nums)
        {
            if (num > 0)
            {
                result[posIndex] = num;
                posIndex += 2;
            }
            else
            {
                result[negIndex] = num;
                negIndex += 2;
            }
        }
        return result;
    }
}
