namespace LeetCode.Solutions;

public class Solution1441
{
    /// <summary>
    /// 1441. Build an Array With Stack Operations - Medium
    /// <a href="https://leetcode.com/problems/build-an-array-with-stack-operations">See the problem</a>
    /// </summary>
    public IList<string> BuildArray(int[] target, int n)
    {
        var result = new List<string>();
        int j = 0; // index in target

        for (int i = 1; i <= n && j < target.Length; i++)
        {
            result.Add("Push");

            if (i == target[j])
            {
                j++; // matched a target value
            }
            else
            {
                result.Add("Pop"); // discard it
            }
        }

        return result;
    }
}
