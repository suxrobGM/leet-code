namespace LeetCode.Solutions;

public class Solution503
{
    /// <summary>
    /// 503. Next Greater Element II - Medium
    /// <a href="https://leetcode.com/problems/next-greater-element-ii">See the problem</a>
    /// </summary>
    public int[] NextGreaterElements(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];
        Array.Fill(result, -1);
        Stack<int> stack = new();

        for (int i = 0; i < n * 2; i++)
        {
            int num = nums[i % n];

            while (stack.Count > 0 && nums[stack.Peek()] < num)
            {
                result[stack.Pop()] = num;
            }

            if (i < n)
            {
                stack.Push(i);
            }
        }

        return result;
    }
}
