namespace LeetCode.Solutions;

public class Solution1980
{
    /// <summary>
    /// 1980. Find Unique Binary String - Medium
    /// <a href="https://leetcode.com/problems/find-unique-binary-string">See the problem</a>
    /// </summary>
    public string FindDifferentBinaryString(string[] nums)
    {
        int n = nums.Length;
        char[] result = new char[n];

        for (int i = 0; i < n; i++)
        {
            result[i] = nums[i][i] == '0' ? '1' : '0';
        }

        return new string(result);
    }
}
