namespace LeetCode.Solutions;

public class Solution496
{
    /// <summary>
    /// 496. Next Greater Element I - Easy
    /// <a href="https://leetcode.com/problems/next-greater-element-i">See the problem</a>
    /// </summary>
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        Dictionary<int, int> nextGreater = [];
        Stack<int> stack = new();

        foreach (int num in nums2)
        {
            while (stack.Count > 0 && stack.Peek() < num)
            {
                nextGreater[stack.Pop()] = num;
            }

            stack.Push(num);
        }

        int[] result = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            result[i] = nextGreater.GetValueOrDefault(nums1[i], -1);
        }

        return result;
    }
}
